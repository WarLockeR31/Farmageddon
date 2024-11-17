using UnityEngine;

public class CoinDamage : MonoBehaviour
{
    public float damageAmount = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Banana"))
        {
            Health enemyHealth = other.GetComponent<Health>();
            if (enemyHealth != null)
                enemyHealth.TakeDamage(damageAmount);
            Debug.Log($"Нанесено {damageAmount} урона {other.name}.");
            Destroy(gameObject);
        }
    }
}
