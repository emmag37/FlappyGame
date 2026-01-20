using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;
    public Text highScoreText;

    public GameObject gameOverScreen;
    public GameObject startScreen;
    public AudioSource dingSFX;

    public bool over = false;
    public static bool skipStart = false;

    void Start()
    {
        // set the high score text (every time the game is run)
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();

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
        // update the current game score
        playerScore = playerScore + scoreToAdd;
        scoreText.text = "Score: " + playerScore.ToString();
        dingSFX.Play();

        // update the high score
        if (playerScore > PlayerPrefs.GetInt("HighScore"))
        {
            highScoreText.text = "High Score: " + playerScore.ToString();

            PlayerPrefs.SetInt("HighScore", playerScore);
        }
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
