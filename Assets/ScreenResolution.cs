using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;

    private Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            int refreshRate = Mathf.RoundToInt((float)resolutions[i].refreshRateRatio.numerator / resolutions[i].refreshRateRatio.denominator);

            string option = $"{resolutions[i].width}x{resolutions[i].height} @ {refreshRate}Hz";
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height &&
                resolutions[i].refreshRateRatio.Equals(Screen.currentResolution.refreshRateRatio))
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        resolutionDropdown.onValueChanged.AddListener(SetResolution);
        fullscreenToggle.onValueChanged.AddListener(SetFullscreen);

        LoadSettings(currentResolutionIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Debug.Log($"Setting fullscreen to: {isFullscreen}");
        Screen.fullScreen = isFullscreen;
        SaveSettings();
    }

    public void SetResolution(int resolutionIndex)
    {
        if (resolutions != null && resolutionIndex >= 0 && resolutionIndex < resolutions.Length)
        {
            Resolution resolution = resolutions[resolutionIndex];
            int refreshRate = Mathf.RoundToInt((float)resolution.refreshRateRatio.numerator / resolution.refreshRateRatio.denominator);
            Debug.Log($"Setting resolution to: {resolution.width}x{resolution.height} @ {refreshRate}Hz");

            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

            SaveSettings();
        }
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
        PlayerPrefs.SetInt("FullscreenPreference", fullscreenToggle.isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void LoadSettings(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey("ResolutionPreference"))
        {
            int savedResolutionIndex = PlayerPrefs.GetInt("ResolutionPreference");
            resolutionDropdown.value = savedResolutionIndex;
            SetResolution(savedResolutionIndex);
        }
        else
        {
            resolutionDropdown.value = currentResolutionIndex;
            SetResolution(currentResolutionIndex);
        }

        if (PlayerPrefs.HasKey("FullscreenPreference"))
        {
            bool isFullscreen = PlayerPrefs.GetInt("FullscreenPreference") == 1;
            fullscreenToggle.isOn = isFullscreen;
            Screen.fullScreen = isFullscreen;
        }
        else
        {
            fullscreenToggle.isOn = true;
            Screen.fullScreen = true;
        }
    }

    public void LoadScene(string sceneName)
    {
        Debug.Log($"Loading scene: {sceneName}");
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneAsync(string sceneName)
    {
        Debug.Log($"Asynchronously loading scene: {sceneName}");
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    private IEnumerator<AsyncOperation> LoadSceneCoroutine(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        while (!operation.isDone)
        {
            Debug.Log($"Loading progress: {operation.progress * 100}%");
            yield return operation;
        }
    }
}
