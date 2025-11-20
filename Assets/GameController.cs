using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI statusText;
    public GameObject player;

    public float timeToWin = 10f;
    private float elapsedTime = 0f;
    private bool gameEnded = false;

    void Start()
    {
        Time.timeScale = 1f;
        statusText.text = "Survive for " + timeToWin + " seconds!";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (gameEnded)
        {
            return;
        }

        elapsedTime += Time.deltaTime;

        if (elapsedTime >= timeToWin)
        {
            WinGame();
        }
    }

    public void WinGame()
    {
        gameEnded = true;
        statusText.text = "You Win! Press 'R' to Restart.";
        statusText.color = Color.green;
        Time.timeScale = 0f;
    }

    public void LoseGame()
    {
        if (gameEnded)
        {
            return;
        }
        gameEnded = true;
        statusText.text = "You Lose! Press 'R' to Restart.";
        statusText.color = Color.red;
        Time.timeScale = 0f;
    }

}
