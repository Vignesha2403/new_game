using UnityEngine;

public class player : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpForce = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Move player left and right using arrow keys
        float move = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(move, 0, 0);

        // Jump at 80-degree angle when mouse button is pressed and player is grounded
        if (Input.GetMouseButtonDown(0) && IsGrounded())
        {
            // 80 degrees from the ground, in the forward (z) direction
            float angleRad = 80f * Mathf.Deg2Rad;
            Vector3 jumpDir = new Vector3(0, Mathf.Sin(angleRad), Mathf.Cos(angleRad));
            rb.AddForce(jumpDir * jumpForce, ForceMode.Impulse);
        }
    }

    // Simple ground check using a raycast
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
