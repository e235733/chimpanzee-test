using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoxController : MonoBehaviour
{
    [SerializeField] private Image boxImage;
    [SerializeField] private TextMeshProUGUI numberText;

    private int number = 0;
    private LevelManager levelManager;

    // instantiate 時に呼び出す設定
    public void Setup(int _number, LevelManager _levelManager)
    {
        number = _number;
        levelManager = _levelManager;

        numberText.text = number.ToString();
    }

    // ボックスがクリックされた時の処理
    public void OnClickBox()
    {
        levelManager.OnNumberReceived(number);
        ToggleVisibility();
    }

    // ボックスの表示・非表示を切り替える
    private void ToggleVisibility()
    {
        bool isVisible = boxImage.gameObject.activeSelf;
        if (isVisible)
        {
            boxImage.gameObject.SetActive(false);
        }
        else
        {
            boxImage.gameObject.SetActive(true);
        }
    }
}
