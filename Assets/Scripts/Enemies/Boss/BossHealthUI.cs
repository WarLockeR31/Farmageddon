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
            Debug.LogError("������ ����� �� ��������!");
            return;
        }

        if (healthFill == null)
        {
            Debug.LogError("���������� ������� �������� �� ���������!");
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
