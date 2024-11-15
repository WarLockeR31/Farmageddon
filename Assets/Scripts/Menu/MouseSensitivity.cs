using UnityEngine;
using UnityEngine.UI;

public class MouseSensitivity : MonoBehaviour
{
    public Slider sensitivitySlider;
    public Text sensitivityText;
    public static float sensitivity = 500;

    void Start()
    {
        sensitivitySlider.value = sensitivity;
        UpdateSensitivityText(sensitivity);
        sensitivitySlider.onValueChanged.AddListener(ChangeSensitivity);
    }

    void ChangeSensitivity(float value)
    {
        sensitivity = value;
        UpdateSensitivityText(value);
    }

    private void UpdateSensitivityText(float value)
    {
        if (sensitivityText != null)
        {
            value = (value - 500) / (sensitivitySlider.maxValue - 500);
            sensitivityText.text = value.ToString("F2");
        }
    }

    private void OnEnable()
    {
        sensitivitySlider.value = sensitivity;
        UpdateSensitivityText(sensitivity);
        sensitivitySlider.onValueChanged.AddListener(ChangeSensitivity);
    }

    private void OnDisable()
    {
        sensitivitySlider.onValueChanged.RemoveListener(ChangeSensitivity);
    }
}
