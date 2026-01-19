using UnityEngine;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{
    // public objects
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Runs once
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    // Runs over and over again
    void Update()
    {
        // runs when user hits the space bar
        if (Keyboard.current.spaceKey.wasPressedThisFrame && birdIsAlive)
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }

}
