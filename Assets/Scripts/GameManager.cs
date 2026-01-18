using UnityEngine;

public class GameManager : MonoBehaviour
{

    public void onNumberReceived(int number)
    {
        Debug.Log($"received: {number}");
    }
}
