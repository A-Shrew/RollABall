using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float ballSpeed = 2f;
    [SerializeField] private float jumpPower = 5f;
    private bool isGrounded;
    public void MoveBall(Vector3 input)
    {
        Vector3 movementVector = new(input.x, 0, input.y);
        rb.AddForce(movementVector * ballSpeed);

        Vector3 jumpVector = new(0, input.z, 0);

        if (isGrounded)
        {
            rb.AddForce(movementVector * jumpPower);
            isGrounded = false;
        }

    }

    public bool IsGrounded()
    {
        return false;
    }

}
