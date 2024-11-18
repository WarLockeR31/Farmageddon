using UnityEngine;
using UnityEngine.UI;

public class BossHealthUI : MonoBehaviour
{
    [SerializeField]
    private Image healthFill;

    [SerializeField]
    private Boss bossPrefab;

    private void Start()
    {
        if (bossPrefab == null)
        {
            Debug.LogError("Префаб босса не назначен!");
            return;
        }

        if (healthFill == null)
        {
            Debug.LogError("Заполнение полоски здоровья не назначено!");
            return;
        }

        bossPrefab.health.OnHealthChanged.AddListener(UpdateHealthBar);

        UpdateHealthBar(bossPrefab.health.CurrentHealth / bossPrefab.health.MaxHealth);
    }

    private void UpdateHealthBar(float healthPercent)
    {
        if (healthFill != null)
        {
            healthFill.fillAmount = healthPercent;
        }
    }

    private void OnDestroy()
    {
        if (bossPrefab != null)
        {
            bossPrefab.health.OnHealthChanged.RemoveListener(UpdateHealthBar);
        }
    }
}
