using UnityEngine;

public class TomatoHealth : Health
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponentInParent<Animator>();
    }
    protected override void Awake()
    {
        base.Awake();
        OnHealthChanged.AddListener(LogHealth);
    }

    protected override void Die()
    {
        animator.SetBool("isDead", true);
        animator.Play("loshok_death");
        base.Die();
        ArenaManager.getInstance().DecEnemyCount();
        HouseArenaManager.getInstance().DecEnemyCount();
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
