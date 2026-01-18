using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject numberBoxPrefab;
    [SerializeField] private Transform canvas;

    void Start()
    {
        GameObject numberBox = Instantiate(numberBoxPrefab, canvas);
        BoxController boxController = numberBox.GetComponent<BoxController>();
        boxController.Setup(1, this);
    } 

    public void onNumberReceived(int number)
    {
        Debug.Log($"received: {number}");
    }
}
