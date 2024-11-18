using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    public void StartNewGame()
    {
        Time.timeScale = 1f; 
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
