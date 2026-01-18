using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject numberBoxPrefab;
    [SerializeField] private RectTransform canvas;
    [SerializeField] private float padding;

    private float areaWidth;
    private float areaHeight;

    private float rangeX;
    private float rangeY;

    void Start()
    {
        // キャンバスから中心からの範囲を計算
        areaWidth = canvas.rect.width;
        areaHeight = canvas.rect.height;
        rangeX = (areaWidth / 2) - (padding / 2);
        rangeY = (areaHeight / 2) - (padding / 2);

        SpawnNumberBoxes();
    }

    private void SpawnNumberBoxes()
    {
        // インスタンス化
        GameObject numberBox = Instantiate(numberBoxPrefab, canvas);
        // コンポーネントの取得
        BoxController boxController = numberBox.GetComponent<BoxController>();
        RectTransform rectT = numberBox.GetComponent<RectTransform>();

        float x = Random.Range(-rangeX, rangeX);
        float y = Random.Range(-rangeY, rangeY);

        rectT.anchoredPosition = new Vector2(x, y);

        boxController.Setup(1, this);
    }

    public void OnNumberReceived(int number)
    {
        Debug.Log($"received: {number}");
    }
}
