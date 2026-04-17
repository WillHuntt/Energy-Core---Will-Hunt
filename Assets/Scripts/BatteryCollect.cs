using UnityEngine;

public class BatteryCollect : MonoBehaviour
{
    // lets this script talk to the game manager
    public GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        // checks if the player touched the battery
        if (other.CompareTag("Player"))
        {
            // adds 1 to the battery count
            gameManager.AddBattery();

            // deletes the battery
            Destroy(gameObject);
        }
    }
}