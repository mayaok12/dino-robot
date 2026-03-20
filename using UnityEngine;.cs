using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class GameLoopManager : MonoBehaviour
{
    [Header("Settings")]
    public float playDuration = 60f; 
    
    [Header("UI Elements")]
    public GameObject gameOverPanel; 
    public TextMeshProUGUI timerText; 

    private float timeRemaining;
    private bool isGameActive = false;

    void Start()
    {
        StartGame();
    }

    void Update()
    {
        if (isGameActive)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerUI();
            }
            else
            {
                EndGame();
            }
        }

private bool isPaused = false;
public GameObject pauseMenuPanel; 

public void TogglePause()
{
    isPaused = !isPaused; 

    if (isPaused)
    {
        Time.timeScale = 0f; 
        pauseMenuPanel.SetActive(true);
        isGameActive = false; 
    }
    else
    {
        Time.timeScale = 1f; 
        pauseMenuPanel.SetActive(false);
        isGameActive = true; 
    }
}
    }

    public void StartGame()
    {
        timeRemaining = playDuration;
        isGameActive = true;
        gameOverPanel.SetActive(false);
        Time.timeScale = 1f; 
    }

    void EndGame()
    {
        isGameActive = false;
        timeRemaining = 0;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f; 
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
        
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = $"Time: {Mathf.CeilToInt(timeRemaining)}s";
        }
    }
}