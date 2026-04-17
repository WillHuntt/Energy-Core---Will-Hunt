using UnityEngine;
using UnityEngine.SceneManagement;

public class HazardReset : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // checks if the player touched the hazard
        if (other.CompareTag("Player"))
        {
            // reloads the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}