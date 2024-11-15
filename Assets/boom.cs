using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom : MonoBehaviour
{
    private bananaScript bs;
    private void Start()
    {
        bs = GetComponentInParent<bananaScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Manager.getInstance().PlayerHealth.TakeDamage(bs.damage, HealthType.Yellow);
        }
    }
}
