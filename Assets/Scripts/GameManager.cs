using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // how many batteries the player has collected
    public int batteryCount = 0;

    // how many batteries are in the level
    public int totalBatteries = 5;

    // the text on the screen
    public TextMeshProUGUI batteryText;

    // the door that blocks the exit
    public GameObject exitDoor;

    // the win text on the screen
    public GameObject winText;

    // the player object
    public GameObject player;

    void Start()
    {
        // shows the starting battery text
        batteryText.text = "Power Restored: 0 / " + totalBatteries;

        // hides the win text at the start
        winText.SetActive(false);
    }

    public void AddBattery()
    {
        // adds 1 to the battery count
        batteryCount++;

        // updates the text
        batteryText.text = "Power Restored: " + batteryCount + " / " + totalBatteries;

        // if all batteries are collected, open the door
        if (batteryCount == totalBatteries)
        {
            exitDoor.SetActive(false);
        }
    }

    public void ShowWin()
    {
        // shows the win text
        winText.SetActive(true);

        // gets the Rigidbody from the player
        Rigidbody rb = player.GetComponent<Rigidbody>();

        // stops the player from moving
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // turns off the movement script
        player.GetComponent<PlayerMovement>().enabled = false;
    }
}