using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField]
    private PlayerHealth playerHealth;

    private Text healthText;

    private void Start()
    {
        healthText = GetComponent<Text>();

        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged.AddListener(UpdateHealthUI);
            UpdateHealthUI(playerHealth.CurrentHealth / playerHealth.MaxHealth);
        }
    }

    private void UpdateHealthUI(float healthPercent)
    {
        int currentCells = Mathf.RoundToInt(healthPercent * 10);
        healthText.text = $"{currentCells}/10";
    }

    private void OnDestroy()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged.RemoveListener(UpdateHealthUI);
        }
    }
}
