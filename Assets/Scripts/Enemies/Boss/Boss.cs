using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]
    public float dashSpeed;

    [SerializeField]
    private GameObject hitbox = null;

    public GameObject Hitbox
    {
        get { return hitbox; }
    }

    public BossHealth health;
    public bool isStunned = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            isStunned = true;
        }
        if (other.gameObject.CompareTag("PlayerAttack"))
        {
            health.TakeDamage(1);
        }
    }

}
