using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    // lets this script talk to the game manager
    public GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        // checks if the player entered the win area
        if (other.CompareTag("Player"))
        {
            // shows the win message
            gameManager.ShowWin();
        }
    }
}