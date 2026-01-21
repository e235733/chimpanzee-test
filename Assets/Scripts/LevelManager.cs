using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject numberBoxPrefab;
    [SerializeField] private RectTransform canvas;
    [SerializeField] private float padding;
    [SerializeField] private float space;
    [SerializeField] private int spawnCount;
    [SerializeField] private GameManager gameManager;

    // numberBox の場所とスクリプト
    private List<Vector2> placedPositions = new List<Vector2>();
    private List<BoxController> boxControllers = new List<BoxController>();

    private float rangeX;
    private float rangeY;

    // 正解の値
    private int expectedNumber;

    void Start()
    {
        // キャンバスから中心からの範囲を計算
        float areaWidth = canvas.rect.width;
        float areaHeight = canvas.rect.height;
        rangeX = (areaWidth / 2) - padding;
        rangeY = (areaHeight / 2) - padding;
    }

    // ゲームをスタートする
    public void StartGame()
    {
        // numberBox　を作成
        GenerateBoxes();
        // 期待される数値をリセット
        expectedNumber = 1;

        // 3秒後に全ての数字を隠す
        Invoke(nameof(HideAllNumbers), 3f);
    }

    private void GenerateBoxes()
    {
        for (int i = 1; i <= spawnCount; i++)
        {
            // インスタンス化
            GameObject numberBox = Instantiate(numberBoxPrefab, canvas);
            // コンポーネントの取得
            BoxController boxController = numberBox.GetComponent<BoxController>();
            RectTransform rectT = numberBox.GetComponent<RectTransform>();
            // スクリプトの参照を保存
            boxControllers.Add(boxController);

            float x;
            float y;
            Vector2 position = new Vector2(0, 0);

            bool isOverlapping = true;
            while (isOverlapping) {
                // 範囲内でランダムに座標を決定
                x = Random.Range(-rangeX, rangeX);
                y = Random.Range(-rangeY, rangeY);

                // ここまでに生成したインスタンスと比較
                isOverlapping = false;
                foreach (Vector2 p in placedPositions)
                {
                    // シェビチェフ距離を計算
                    float chebDist = Mathf.Max(Mathf.Abs(p.x - x), Mathf.Abs(p.y - y));
                    // 間隔が指定したより小さければやり直し
                    if (chebDist < space)
                    {
                        isOverlapping = true;
                        break;
                    }
                    else
                    {
                        isOverlapping = false;
                    }
                }

                position.x = x;
                position.y = y;
            }
            rectT.anchoredPosition = position;
            placedPositions.Add(position);

            boxController.Setup(i, this);
        }
    }

    // 数値が送られてきたときの処理
    public void OnNumberReceived(int number)
    {
        Debug.Log($"received: {number}, expected: {expectedNumber}");
        // 正解した場合
        if (number == expectedNumber)
        {
            Debug.Log("Correct!");
            // 次の数値を設定
            expectedNumber++;
            // 最後まで連続正解したら成功
            if (number == spawnCount)
            {
                gameManager.Success();
            }
        }
        // 不正解の場合
        else
        {
            Debug.Log("Incorrect!");
            ShowAllNumbers();
            // 失敗
            gameManager.Failed();
        }
    }

    // すべての数値を隠す
    [ContextMenu("Hide All Numbers")]
    private void HideAllNumbers()
    {
        foreach(BoxController bc in boxControllers)
        {
            bc.HideNumber();
        }
    }

    // すべての数値を公開する
    [ContextMenu("Show All Numbers")]
    private void ShowAllNumbers()
    {
        foreach(BoxController bc in boxControllers)
        {
            bc.ShowNumber();
        }
    }

    [ContextMenu("Run Layout Test")]
    private void GenerateTest()
    {
        // padding テスト用で四隅に配置
        GameObject topLeft = Instantiate(numberBoxPrefab, canvas);
        GameObject topRight = Instantiate(numberBoxPrefab, canvas);
        GameObject bottomLeft = Instantiate(numberBoxPrefab, canvas);
        GameObject bottomRight = Instantiate(numberBoxPrefab, canvas);
        topLeft.GetComponent<RectTransform>().anchoredPosition = new Vector2(-rangeX, rangeY);
        topRight.GetComponent<RectTransform>().anchoredPosition = new Vector2(rangeX, rangeY);
        bottomLeft.GetComponent<RectTransform>().anchoredPosition = new Vector2(-rangeX, -rangeY);
        bottomRight.GetComponent<RectTransform>().anchoredPosition = new Vector2(rangeX, -rangeY);

        // space テスト用で左上の隣に配置
        GameObject nextTopLeft = Instantiate(numberBoxPrefab, canvas);
        nextTopLeft.GetComponent<RectTransform>().anchoredPosition = new Vector2(-rangeX + space, rangeY);
    }
}
