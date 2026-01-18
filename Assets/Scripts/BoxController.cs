using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoxController : MonoBehaviour
{
    [SerializeField] private Image boxImage;
    [SerializeField] private TextMeshProUGUI numberText;

    private int number = 0;
    private GameManager gameManager;

    // instantiate 時に呼び出す設定
    public void Setup(int _number, GameManager _gameManager)
    {
        number = _number;
        gameManager = _gameManager;

        numberText.text = number.ToString();
    }

    public void OnClickBox()
    {
        gameManager.onNumberReceived(number);
    }
}
