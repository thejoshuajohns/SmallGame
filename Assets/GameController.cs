using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    // ---------------------------------------

    [Header("UI Components")]
    public TextMeshProUGUI statusText;
    public GameObject pauseMenuUI;

    [Header("Game Settings")]
    public float timeToWin = 10f;

    private float timer = 0f;
    private bool isGameActive = false;
    private bool isPaused = false;

    void Start()
    {
        Time.timeScale = 0f;
        isGameActive = false;

        statusText.text = "Cube Dodger\nPress SPACE to Start";

        if (pauseMenuUI != null) pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        if (!isGameActive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartGame();
            }
            return;
        }

        if (statusText.text.Contains("Win") || statusText.text.Contains("Lost"))
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            return;
        }

        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

        if (!isPaused)
        {
            timer += Time.deltaTime;

             statusText.text = "Time: " + Mathf.Round(timer);

            if (timer >= timeToWin)
            {
                WinGame();
            }
        }
    }

    void StartGame()
    {
        isGameActive = true;
        Time.timeScale = 1f; 
        statusText.text = "";
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            if (pauseMenuUI != null) pauseMenuUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            if (pauseMenuUI != null) pauseMenuUI.SetActive(false);
        }
    }

    public void WinGame()
    {
        Time.timeScale = 0f;
        statusText.text = "You Win!\nPress R to Restart";
        statusText.color = Color.green;
    }

    public void LoseGame()
    {
        Time.timeScale = 0f;
        statusText.text = "You Lost!\nPress R to Restart";
        statusText.color = Color.red;
    }
}