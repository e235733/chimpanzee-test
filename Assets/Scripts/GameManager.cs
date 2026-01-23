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
    [SerializeField] private int startLevel;
    [SerializeField] private int maxLevel;
    // コンテナのオブジェクト
    private GameObject container;
    // numberBoxの数をレベルとする
    private int currentLevel;

    void Start()
    {
        startPanel.SetActive(true);
    } 

    // スタート・リスタートボタンが押されたときの処理
    public void OnClickStartButton()
    {
        // パネルを非表示にする
        endPanel.SetActive(false);
        startPanel.SetActive(false);
        currentLevel = startLevel;
        StartLevel();
    }

    // 各レベルの実行
    private void StartLevel()
    {
        // 既存のコンテナを破壊する
        Destroy(container);
        // コンテナを作成する
        container = Instantiate(containerPrefab, objectContainer);
        ContainerManager containerManager = container.GetComponent<ContainerManager>();
        containerManager.Setup(this, currentLevel);
    }

    // 各レベルの結果が返ってきたときの処理
    public void IsLevelCleard(bool isCleard)
    {
        if (isCleard)
        {
            // 全クリ判定
            if (currentLevel == maxLevel)
            {
                Success();
            }
            // 次のレベル
            else 
            {
                currentLevel++;
                StartLevel();
            }
        }
        // 失敗
        else
        {
            Failure();
        }
    }


    // 成功したときの処理
    private void Success()
    {
        resultText.text = "Success!";
        endPanel.SetActive(true);
    }

    // 失敗したときの処理
    private void Failure()
    {
        resultText.text = "Failure!";
        endPanel.SetActive(true);
    }
}
