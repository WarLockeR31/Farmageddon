using UnityEngine;

public class TomatoHealth : Health
{
    protected override void Awake()
    {
        base.Awake();
        OnHealthChanged.AddListener(LogHealth);
    }

    protected override void Die()
    {
        base.Die();
        gameObject.SetActive(false); 
        ArenaManager.getInstance().DecEnemyCount();
    }

    private void LogHealth(float healthPercent)
    {
        Debug.Log($"{gameObject.name} HP: {CurrentHealth}/{MaxHealth}");
    }

    private void OnDestroy()
    {
        OnHealthChanged.RemoveListener(LogHealth);
    }
}
