using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // the player the camera follows
    public Transform player;

    // how fast the mouse moves the camera
    public float mouseSensitivity = 3f;

    // stores the up/down camera angle
    private float verticalRotation = 20f;

    void Start()
    {
        // locks the mouse in the middle of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // makes the camera holder stay on the player
        transform.position = player.position;

        // gets mouse movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // rotates left and right with the mouse
        transform.Rotate(0, mouseX, 0);

        // changes up and down rotation
        verticalRotation -= mouseY;

        // stops the camera from going too far up or down
        verticalRotation = Mathf.Clamp(verticalRotation, 5f, 60f);

        // applies the up and down rotation to the camera
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }
}