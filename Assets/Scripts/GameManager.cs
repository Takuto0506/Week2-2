using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text scoreText;
    public GameObject gameOverText;
    public Button retryButton;

    private int score = 0;
    public bool isGameOver = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Time.timeScale = 1f;
        UpdateScoreText();
        gameOverText.SetActive(false);
        retryButton.gameObject.SetActive(false);
        retryButton.onClick.AddListener(RestartGame);
    }

    public void AddScore(int amount)
    {
        if (isGameOver) return;

        score += amount;
        UpdateScoreText();

        if (score < -5)
        {
            GameOver();
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score : " + score;
    }

    void GameOver()
    {
        isGameOver = true;
        gameOverText.SetActive(true);
        retryButton.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
