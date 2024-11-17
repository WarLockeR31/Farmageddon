using UnityEngine;

public class BananaHealth : Health
{
    protected override void Die()
    {
        base.Die();
        Destroy(gameObject); 
    }
}
