using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform pos1;
    [SerializeField] private Transform pos2;
    [SerializeField] private Transform pos3;
    [SerializeField] private float cameraSpeed = 3f;
    public GameObject ball;
 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.transform.position.x < -5f && ball.transform.position.z > 5f)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(pos3.position.x, pos3.position.y, pos3.position.z), cameraSpeed * Time.deltaTime);
        }
        if (ball.transform.position.x < -5f && ball.transform.position.z < 5f)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(pos2.position.x, pos2.position.y, pos2.position.z), cameraSpeed * Time.deltaTime);
        }
        if (ball.transform.position.x > -5f && ball.transform.position.z < 5f)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(pos1.position.x, pos1.position.y, pos1.position.z), cameraSpeed * Time.deltaTime);
        }
    }
}
