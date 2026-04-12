using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // how fast the ball moves
    public float speed = 10f;

    // how high the ball jumps
    public float jumpForce = 5f;

    // this stores the Rigidbody on the ball
    private Rigidbody rb;

    // checks if the player is touching the ground
    private bool isGrounded;

    void Start()
    {
        // gets the Rigidbody from the ball
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // gets left/right movement from A and D
        float moveX = Input.GetAxis("Horizontal");

        // gets forward/back movement from W and S
        float moveZ = Input.GetAxis("Vertical");

        // adds force to move the ball
        rb.AddForce(new Vector3(moveX, 0, moveZ) * speed);

        // makes the ball jump when space is pressed and it is on the ground
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // if the ball touches something with the Ground tag, it can jump
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // if the ball leaves the ground, it cannot jump
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}