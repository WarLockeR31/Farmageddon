using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : Interactable
{
    [SerializeField]
    private float speed;

    public Vector3 target;

    [SerializeField]
    float activeTime;

    bool isParried = false;

    private void Start()
    {
        StartCoroutine(DelayedDestroy());
    }

    private void Update()
    {
        transform.position += target * speed * Time.deltaTime;
    }

    public override void BatBeat(Vector3 newTarget)
    {
        target = newTarget;
        isParried = true;
        speed*=6;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            Manager.getInstance().PlayerHealth.TakeDamage(5, HealthType.Red);
        }
    }

    private IEnumerator DelayedDestroy()
    {
        yield return new WaitForSeconds(activeTime);

        DestroyObj();
    }

    private void DestroyObj()
    {
        Destroy(gameObject);
    }
}
