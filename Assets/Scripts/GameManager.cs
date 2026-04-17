using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // how many batteries the player has collected
    public int batteryCount = 0;

    // how many batteries are in the level
    public int totalBatteries = 8;

    // the text on the screen
    public TextMeshProUGUI batteryText;

    void Start()
    {
        // shows the starting text
        batteryText.text = "Power Restored: 0 / " + totalBatteries;
    }

    public void AddBattery()
    {
        // adds 1 to the battery count
        batteryCount++;

        // updates the text
        batteryText.text = "Power Restored: " + batteryCount + " / " + totalBatteries;
    }
}