using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    public GameObject CanvasSettings;

    private bool isPaused = false;
    private PlayerHealth playerHealth;

    void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void Update()
    {
        if (playerHealth != null && playerHealth.IsDead)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        SetCursorVisible(true);
    }

    public void ResumeGame()
    {
        pauseMenuCanvas.SetActive(false);
        CanvasSettings.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        SetCursorVisible(false);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public bool IsPaused()
    {
        return isPaused;
    }

    private void SetCursorVisible(bool visible)
    {
        Cursor.lockState = visible ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = visible;
    }
}
