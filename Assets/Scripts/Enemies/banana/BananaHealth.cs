using UnityEngine;

public class BananaHealth : Health
{
    protected override void Die()
    {
        base.Die();
        ArenaManager.getInstance().DecEnemyCount();
        GetComponent<ItemDroper>().DropItem();
        gameObject.SetActive(false); 
    }
}
