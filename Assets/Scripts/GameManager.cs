using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject endPanel;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private TextMeshProUGUI resultText;

    void Start()
    {
        startPanel.SetActive(true);
    } 

    // スタートボタンが押されたときの処理
    public void OnClickStartButton()
    {
        startPanel.SetActive(false);
        levelManager.StartGame();
    }

    // 成功したときの処理
    public void Success()
    {
        resultText.text = "Success!";
        endPanel.SetActive(true);
    }

    // 失敗したときの処理
    public void Failed()
    {
        resultText.text = "Failed!";
        endPanel.SetActive(true);
    }

    // リスタートボタンが押されたときの処理
    public void OnClickRestartButton()
    {
        endPanel.SetActive(false);
    }
}
