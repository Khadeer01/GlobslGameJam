using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Win Condition")]
    public int collectiblesToWin = 10;

    [Header("UI")]
    public GameObject gameOverPanel;
    public GameObject constantUI;
    public GameObject pauseMenuPanel;

    private int collectedCount = 0;
    private bool isPaused = false;

    void Start()
    {
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (pauseMenuPanel != null) pauseMenuPanel.SetActive(false);
        if (constantUI != null) constantUI.SetActive(true);

        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (isPaused) ResumeGame();
            else PauseGame();
        }
    }

    public void Collect()
    {
        collectedCount++;

        if (collectedCount >= collectiblesToWin)
        {
            WinGame();
        }
    }

   public void WinGame()
    {
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
        Time.timeScale = 0f;

        // Show cursor so buttons can be clicked
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void PauseGame()
    {
        isPaused = true;
        if (pauseMenuPanel != null) pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;

        // Unlock cursor for UI interaction
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        isPaused = false;
        if (pauseMenuPanel != null) pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;

        // Lock cursor again for gameplay
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game"); // works in Editor
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
