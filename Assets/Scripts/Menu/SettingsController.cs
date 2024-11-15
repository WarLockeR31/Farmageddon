using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SettingsController : MonoBehaviour
{
    [Header("Mouse Settings")]
    public Slider mouseSensitivitySlider;

    [Header("Graphics Settings")]
    public Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;

    [Header("Sound Settings")]
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;

    [Header("References")]
    public GameObject settingsMenuUI;
    public GameObject pauseMenuUI;

    private Resolution[] resolutions;

    void Start()
    {
        // Настройка разрешений экрана
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
               resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // Загрузка сохраненных настроек
        mouseSensitivitySlider.value = PlayerPrefs.GetFloat("MouseSensitivity", 1f);
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
        fullscreenToggle.isOn = Screen.fullScreen;
    }

    // Методы для настроек

    public void SetMouseSensitivity(float sensitivity)
    {
        // Предполагается, что есть скрипт для управления камерой или персонажем
        PlayerPrefs.SetFloat("MouseSensitivity", sensitivity);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetMusicVolume(float volume)
    {
        // Предполагается наличие аудиомикшера или аудио менеджера
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    // Методы для переключения между меню

    public void OpenSettings()
    {
        settingsMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void CloseSettings()
    {
        settingsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
}
