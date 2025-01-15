using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float ballSpeed = 5f;
    [SerializeField] private float jumpPower = 2f;
    private float raycastDistance;

    private void Start()
    {
        raycastDistance = transform.localScale.z / 2f + 0.1f;
    }
    public void MoveBall(Vector3 input)
    {
        Vector3 movementVector = new(input.x, 0, input.z);
        Vector3 jumpVector = new(0, input.y, 0);

        rb.AddForce(movementVector * ballSpeed);

        if (IsGrounded())
        {   
            rb.AddForce(jumpVector * jumpPower, ForceMode.Impulse);
        }

    }
    
    public bool IsGrounded()
    {
        Debug.DrawRay(transform.position, Vector3.down * raycastDistance, Color.red);

        if (Physics.Raycast(transform.position, Vector3.down, raycastDistance))
        {
            return true;
        }
        return false;

    }

}
