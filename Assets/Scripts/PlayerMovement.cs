using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // how fast the ball moves
    public float speed = 8f;

    // how high the ball jumps
    public float jumpForce = 6f;

    // stops the ball going too fast
    public float maxSpeed = 6f;

    // how far down the script checks for the ground
    public float groundCheckDistance = 0.7f;

    // this stores the Rigidbody on the ball
    private Rigidbody rb;

    // checks if the player is touching the ground
    private bool isGrounded;

    // this stores the camera
    public Transform cameraTransform;

    void Start()
    {
        // gets the Rigidbody from the ball
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // checks if there is ground under the ball
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);

        // gets movement input
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // gets the direction the camera is facing
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // stops the camera movement from pushing the ball up or down
        forward.y = 0f;
        right.y = 0f;

        // makes sure the directions stay normal length
        forward.Normalize();
        right.Normalize();

        // works out movement based on the camera direction
        Vector3 moveDirection = forward * moveZ + right * moveX;

        // only adds movement if the ball is not already too fast
        if (rb.linearVelocity.magnitude < maxSpeed)
        {
            rb.AddForce(moveDirection * speed);
        }

        // makes the ball jump when space is pressed and it is on the ground
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}