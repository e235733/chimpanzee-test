using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoxController : MonoBehaviour
{
    [SerializeField] private Image boxImage;
    [SerializeField] private TextMeshProUGUI numberText;

    private int number = 0;
    private ContainerManager containerManager;
    // クリックされたか
    private bool hasClicked = true;

    // instantiate 時に呼び出す設定
    public void Setup(ContainerManager _containerManager, int _number)
    {
        number = _number;
        containerManager = _containerManager;
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
            containerManager.OnNumberReceived(number);
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
