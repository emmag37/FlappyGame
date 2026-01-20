using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject startScreen;
    public AudioSource dingSFX;

    public bool over = false;
    public static bool skipStart = false;

    void Start()
    {
        if (skipStart)
        {
            Time.timeScale = 1f;
        }
        else
        {
            // Open game with the start screen
            startScreen.SetActive(true);

            // "pause" all game logic
            Time.timeScale = 0f;
        }

    }

    public void startGame()
    {
        startScreen.SetActive(false);

        Time.timeScale = 1;   // unpause
    }

    [ContextMenu("Increase Score")]     // can now use while unity is running
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        dingSFX.Play();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // this resets everything, including the bool that you are using to turn off the startscreen
    }

    public void gameOver()
    {
        skipStart = true;
        gameOverScreen.SetActive(true); 
    }

}
