using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoxController : MonoBehaviour
{
    [SerializeField] private Image boxImage;
    [SerializeField] private TextMeshProUGUI numberText;

    private int number = 0;
    private LevelManager levelManager;
    // クリックされたか
    private bool hasClicked = true;

    // instantiate 時に呼び出す設定
    public void Setup(int _number, LevelManager _levelManager)
    {
        number = _number;
        levelManager = _levelManager;
        // 数値を Text に設定
        numberText.text = number.ToString();
        // box を非表示
        boxImage.gameObject.SetActive(false);
    }

    // ボックスがクリックされた時の処理
    public void OnClickBox()
    {
        // クリックは一回だけ可能
        if (!hasClicked)
        {
            // 数値を送信
            levelManager.OnNumberReceived(number);
            // box を非表示
            boxImage.gameObject.SetActive(false);
            // クリック済みにする
            hasClicked = true; 
        }
    }

    // 数値を公開する
    public void ShowNumber()
    {
        // box を非表示
        boxImage.gameObject.SetActive(false);
    }

    // 数値を隠す
    public void HideNumber()
    {
        // box を表示
        boxImage.gameObject.SetActive(true);
        hasClicked = false;
    }
}
