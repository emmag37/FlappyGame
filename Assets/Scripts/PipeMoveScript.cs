using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    // public variables
    public float moveSpeed = 5;
    public float deadZone = -45;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.left * moveSpeed) * Time.deltaTime;

        // destroy the pipe once out of frame
        if (transform.position.x < deadZone)
        {
            Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }
    }
}
