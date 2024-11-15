using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueGame : MonoBehaviour
{
    public PauseMenuController pauseMenuController;
    public GameObject CanvasSettings;

    public void Continue()
    {
        CanvasSettings.SetActive(false);
        if (pauseMenuController != null)
        {
            pauseMenuController.ResumeGame(); 
        }
    }
}
