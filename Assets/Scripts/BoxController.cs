using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Image boxImage;
    [SerializeField] private TextMeshProUGUI numberText;

    private int number = 0;

    public void OnClickBox()
    {
        gameManager.onNumberReceived(number);
    }
}
