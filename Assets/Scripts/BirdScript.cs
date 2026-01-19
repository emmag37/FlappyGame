using UnityEngine;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{
    // public objects
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;

    float topOfScreen;
    float bottomOfScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Runs once
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        topOfScreen = Camera.main.transform.position.y + Camera.main.orthographicSize;
        bottomOfScreen = Camera.main.transform.position.y - Camera.main.orthographicSize;
    }

    // Update is called once per frame
    // Runs over and over again
    void Update()
    {
        // runs when user hits the space bar
            // do not let bird go above the top of the screen
        if (Keyboard.current.spaceKey.wasPressedThisFrame && birdIsAlive && transform.position.y < topOfScreen)
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
        }

        // check if the bird fell off screen
        if (transform.position.y < bottomOfScreen)
        {
            birdDied();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        birdDied();
    }

    private void birdDied()
    {
        logic.gameOver();
        birdIsAlive = false;
    }

}
