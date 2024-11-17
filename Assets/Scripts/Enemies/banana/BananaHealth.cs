using UnityEngine;

public class BananaHealth : Health
{
    protected override void Die()
    {
        base.Die();
        ArenaManager.getInstance().DecEnemyCount();
        Destroy(gameObject); 
    }
}
