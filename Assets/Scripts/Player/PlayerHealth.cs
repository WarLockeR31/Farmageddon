using UnityEngine;

public class PlayerHealth : Health
{
    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    TakeDamage(1f); 
        //}
    }

    protected override void Die()
    {
        base.Die();
    }
}
