using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ゲームの画面となるコンテナ
    [SerializeField] private RectTransform objectContainer;
    // スタート画面
    [SerializeField] private GameObject startPanel;
    // 終了画面
    [SerializeField] private GameObject endPanel;
    // 終了画面に表示する結果のテキスト
    [SerializeField] private TextMeshProUGUI resultText;
    // 数字表示するコンテナのプレハブ
    [SerializeField] private GameObject containerPrefab;
    // コンテナのオブジェクト
    private GameObject container;

    void Start()
    {
        startPanel.SetActive(true);
    } 

    // スタート・リスタートボタンが押されたときの処理
    public void OnClickStartButton()
    {
        // 既存のコンテナを破壊する
        Destroy(container);
        // パネルを非表示にする
        endPanel.SetActive(false);
        startPanel.SetActive(false);
        // コンテナを作成する
        container = Instantiate(containerPrefab, objectContainer);
        ContainerManager containerManager = container.GetComponent<ContainerManager>();
        containerManager.Setup(this, 8);
    }

    // 成功したときの処理
    public void Success()
    {
        resultText.text = "Success!";
        endPanel.SetActive(true);
    }

    // 失敗したときの処理
    public void Failure()
    {
        resultText.text = "Failure!";
        endPanel.SetActive(true);
    }
}
