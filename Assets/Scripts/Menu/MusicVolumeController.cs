using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeController : MonoBehaviour
{
    public Slider volumeSlider;
    public Text volumeText;
    public List<AudioSource> musicSources;

    private void Start()
    {
        if (musicSources.Count > 0)
        {
            volumeSlider.value = GetAverageVolume();
            UpdateVolumeText(volumeSlider.value);
        }
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    private void ChangeVolume(float value)
    {
        foreach (AudioSource source in musicSources)
        {
            source.volume = value;
        }
        UpdateVolumeText(value);
    }

    private void UpdateVolumeText(float value)
    {
        if (volumeText != null)
        {
            volumeText.text = (value * 100).ToString("F2");
        }
    }

    private float GetAverageVolume()
    {
        float totalVolume = 0f;
        foreach (AudioSource source in musicSources)
        {
            totalVolume += source.volume;
        }
        return totalVolume / musicSources.Count;
    }

    private void OnEnable()
    {
        if (musicSources.Count > 0)
        {
            volumeSlider.value = GetAverageVolume();
            UpdateVolumeText(volumeSlider.value);
        }
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        volumeSlider.onValueChanged.RemoveListener(ChangeVolume);
    }
}
