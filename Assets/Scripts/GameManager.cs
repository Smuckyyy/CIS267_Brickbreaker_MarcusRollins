using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Gameplay Values")]
    public int score = 0;
    public int lives = 3;

    [Header("UI References")]
    public GameObject startScreen;
    public GameObject gameOverScreen;
    public GameObject gameWonScreen;
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI livesText;

    [Header("Final Score UI")]
    public TMPro.TextMeshProUGUI gameOverFinalScoreText;
    public TMPro.TextMeshProUGUI gameWonFinalScoreText;

    void Awake()
    {
        //Singleton makes one instance of GameManager that can be accessed by every other script, defined above
        if (Instance == null)
        {
            Instance = this;
        }
            
    }

    void Start()
    {
        //Show start screen
        if (startScreen != null)
        {
            startScreen.SetActive(true);
            Time.timeScale = 0f;
        }
            
        //Hide game over screen until needed
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
        }

        //Hide game won screen until needed
        if (gameWonScreen != null)
        {
            gameWonScreen.SetActive(false);
        }
            
        UpdateUI();
    }

    // Called from Start Button
    public void StartGame()
    {
        Time.timeScale = 1f;

        if (startScreen != null)
        {
            startScreen.SetActive(false);
        }
            
        UpdateUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    //When ball goes out of bounds
    public void LoseLife()
    {
        lives--;
        UpdateUI();

        if (lives <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);

            if( gameOverFinalScoreText != null)
            {
                gameOverFinalScoreText.text = "Final Score: " + score;
            }

            Time.timeScale = 0f;
        }

    }

    public void GameWon()
    {
        if(gameWonScreen != null)
        {
            gameWonScreen.SetActive(true);

            if( gameWonFinalScoreText != null)
            {
                gameWonFinalScoreText.text = "Final Score: " + score;
            }
        }

        Time.timeScale = 0f;
    }

    //Called from Restart Button
    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Called from Exit Button
    public void ExitGame()
    {
        Application.Quit();
    }

    void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
            
        if (livesText != null)
        {
            livesText.text = "Lives: " + lives;
        }
            
    }

    
}