using UnityEngine;

public class OpenSettings : MonoBehaviour
{
    public GameObject settingsCanvas;
    public GameObject pauseMenuCanvas;

    public void Open()
    {
        settingsCanvas.SetActive(true);
        pauseMenuCanvas.SetActive(false);
    }
}
