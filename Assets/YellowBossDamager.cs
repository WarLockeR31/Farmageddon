using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBossDamager : MonoBehaviour
{
    private PlayerHealth ph;
    
    private void Start()
    {
        ph = Manager.getInstance().Player.GetComponent<PlayerHealth>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ph.TakeDamage(2, HealthType.Yellow);
        }
    }
}
