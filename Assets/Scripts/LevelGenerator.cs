using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject numberBoxPrefab;
    [SerializeField] private RectTransform canvas;
    [SerializeField] private float padding;
    [SerializeField] private int spawnCount;

    // 置かれた場所を記録
    List<Vector2> placedPositions = new List<Vector2>();

    void Start()
    {
        GenerateBoxes();
    }

    private void GenerateBoxes()
    {
        // キャンバスから中心からの範囲を計算
        float areaWidth = canvas.rect.width;
        float areaHeight = canvas.rect.height;
        float rangeX = (areaWidth / 2) - (padding / 2);
        float rangeY = (areaHeight / 2) - (padding / 2);

        for (int i = 0; i < spawnCount; i++)
        {
            // インスタンス化
            GameObject numberBox = Instantiate(numberBoxPrefab, canvas);
            // コンポーネントの取得
            BoxController boxController = numberBox.GetComponent<BoxController>();
            RectTransform rectT = numberBox.GetComponent<RectTransform>();

            // 範囲内でランダムに座標を決定
            float x = Random.Range(-rangeX, rangeX);
            float y = Random.Range(-rangeY, rangeY);

            rectT.anchoredPosition = new Vector2(x, y);

            boxController.Setup(i, this);
        }

        // テスト用で四隅に配置
        GameObject topLeft = Instantiate(numberBoxPrefab, canvas);
        GameObject topRight = Instantiate(numberBoxPrefab, canvas);
        GameObject bottomLeft = Instantiate(numberBoxPrefab, canvas);
        GameObject bottomRight = Instantiate(numberBoxPrefab, canvas);
        topLeft.GetComponent<RectTransform>().anchoredPosition = new Vector2(-rangeX, rangeY);
        topRight.GetComponent<RectTransform>().anchoredPosition = new Vector2(rangeX, rangeY);
        bottomLeft.GetComponent<RectTransform>().anchoredPosition = new Vector2(-rangeX, -rangeY);
        bottomRight.GetComponent<RectTransform>().anchoredPosition = new Vector2(rangeX, -rangeY);
    }

    public void OnNumberReceived(int number)
    {
        Debug.Log($"received: {number}");
    }
}
