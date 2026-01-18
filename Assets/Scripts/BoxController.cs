using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoxController : MonoBehaviour
{
    [Header("UI 参照")]
    [SerializeField] private Image boxImage;
    [SerializeField] private TextMeshProUGUI numberText;


    private void Update()
    {
        
    }

    // 数字の設定
    public void SetNumber(int number)
    {
        numberText.text = number.ToString();
        boxImage.gameObject.SetActive(false);
    }

    // 表示・非表示を切り替えるトグルメソッド
    public void ToggleVisibility()
    {
        // 現在の状態を調べ、反転させる
        bool isBoxVisibly = boxImage.gameObject.activeSelf;
        boxImage.gameObject.SetActive(!isBoxVisibly);
    }
}
