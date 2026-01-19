using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject numberBoxPrefab;
    [SerializeField] private RectTransform canvas;
    [SerializeField] private float padding;
    [SerializeField] private float space;
    [SerializeField] private int spawnCount;

    // 置かれた場所を記録
    List<Vector2> placedPositions = new List<Vector2>();

    float rangeX;
    float rangeY;

    void Start()
    {    
        // キャンバスから中心からの範囲を計算
        float areaWidth = canvas.rect.width;
        float areaHeight = canvas.rect.height;
        rangeX = (areaWidth / 2) - (padding / 2);
        rangeY = (areaHeight / 2) - (padding / 2);
        // GenerateTest();
        GenerateBoxes();
    }

    private void GenerateBoxes()
    {

        for (int i = 0; i < spawnCount; i++)
        {
            // インスタンス化
            GameObject numberBox = Instantiate(numberBoxPrefab, canvas);
            // コンポーネントの取得
            BoxController boxController = numberBox.GetComponent<BoxController>();
            RectTransform rectT = numberBox.GetComponent<RectTransform>();

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
        Debug.Log($"received: {number}");
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
