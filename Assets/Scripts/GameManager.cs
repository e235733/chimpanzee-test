using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject endPanel;

    // スタートボタンが押されたときの処理
    public void OnClickStartButton()
    {
        startPanel.SetActive(false);
    }

    // リスタートボタンが押されたときの処理
    public void OnClickRestartButton()
    {
        endPanel.SetActive(false);
    }
}
