using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaHealth : Health
{
    public override void Heal(float amount)
    {
        base.Heal(amount);
    }

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
    }

    protected override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }
}
