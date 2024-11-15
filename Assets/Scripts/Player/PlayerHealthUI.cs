using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField]
    private PlayerHealth playerHealth;
    [SerializeField]
    private Text redHealthText;
    [SerializeField]
    private Text blueHealthText;
    [SerializeField]
    private Text yellowHealthText;
    [SerializeField]
    private Text greenHealthText;

    private void Start()
    {
        if (playerHealth != null)
        {
            playerHealth.OnRedHealthChanged.AddListener(UpdateRedHealthUI);
            playerHealth.OnBlueHealthChanged.AddListener(UpdateBlueHealthUI);
            playerHealth.OnYellowHealthChanged.AddListener(UpdateYellowHealthUI);
            playerHealth.OnGreenHealthChanged.AddListener(UpdateGreenHealthUI);

            UpdateRedHealthUI(playerHealth.CurrentRedHealth / playerHealth.maxRedHealth);
            UpdateBlueHealthUI(playerHealth.CurrentBlueHealth / playerHealth.maxOrangeHealth);
            UpdateYellowHealthUI(playerHealth.CurrentYellowHealth / playerHealth.maxYellowHealth);
            UpdateGreenHealthUI(playerHealth.CurrentGreenHealth / playerHealth.maxGreenHealth);
        }
    }

    private void UpdateRedHealthUI(float healthPercent)
    {
        redHealthText.text = $"Red Health: {playerHealth.CurrentRedHealth}/{playerHealth.maxRedHealth}";
    }

    private void UpdateBlueHealthUI(float healthPercent)
    {
        blueHealthText.text = $"Orange Health: {playerHealth.CurrentBlueHealth}/{playerHealth.maxOrangeHealth}";
    }

    private void UpdateYellowHealthUI(float healthPercent)
    {
        yellowHealthText.text = $"Yellow Health: {playerHealth.CurrentYellowHealth}/{playerHealth.maxYellowHealth}";
    }

    private void UpdateGreenHealthUI(float healthPercent)
    {
        greenHealthText.text = $"Green Health: {playerHealth.CurrentGreenHealth}/{playerHealth.maxGreenHealth}";
    }

    private void OnDestroy()
    {
        if (playerHealth != null)
        {
            playerHealth.OnRedHealthChanged.RemoveListener(UpdateRedHealthUI);
            playerHealth.OnBlueHealthChanged.RemoveListener(UpdateBlueHealthUI);
            playerHealth.OnYellowHealthChanged.RemoveListener(UpdateYellowHealthUI);
            playerHealth.OnGreenHealthChanged.RemoveListener(UpdateGreenHealthUI);
        }
    }
}
