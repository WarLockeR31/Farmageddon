using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss : MonoBehaviour
{


    [SerializeField]
    public float dashSpeed;
    [SerializeField]
    public GameObject Hitbox = null;
    public BossHealth health;
    public bool isStunned=false;



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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
