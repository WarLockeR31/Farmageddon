using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : Health
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
    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
    }
    protected override void Die()
    {
        //animator.Play("loshok_death");
        base.Die();
        Destroy(gameObject);
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
