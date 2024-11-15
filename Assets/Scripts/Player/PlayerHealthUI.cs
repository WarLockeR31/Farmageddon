using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField]
    private PlayerHealth playerHealth;
    [SerializeField]
    private Text redHealthText;
    [SerializeField]
    private Text yellowHealthText;
    [SerializeField]
    private Text greenHealthText;

    private void Start()
    {
            playerHealth.OnRedHealthChanged.AddListener(UpdateRedHealthUI);
            playerHealth.OnYellowHealthChanged.AddListener(UpdateYellowHealthUI);
            playerHealth.OnGreenHealthChanged.AddListener(UpdateGreenHealthUI);

            UpdateRedHealthUI();
            UpdateYellowHealthUI();
            UpdateGreenHealthUI();
    }

    private void UpdateRedHealthUI()
    {
        redHealthText.text = $"{playerHealth.CurrentRedHealth}";
    }

    private void UpdateYellowHealthUI()
    {
        yellowHealthText.text = $"{playerHealth.CurrentYellowHealth}";
    }

    private void UpdateGreenHealthUI()
    {
        greenHealthText.text = $"{playerHealth.CurrentGreenHealth}";
    }

    private void OnDestroy()
    {
        if (playerHealth != null)
        {
            playerHealth.OnRedHealthChanged.RemoveListener(UpdateRedHealthUI);
            playerHealth.OnYellowHealthChanged.RemoveListener(UpdateYellowHealthUI);
            playerHealth.OnGreenHealthChanged.RemoveListener(UpdateGreenHealthUI);
        }
    }
}
