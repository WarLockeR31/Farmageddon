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
        speed*=2;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isParried && other.CompareTag("Boss"))
        {
            other.gameObject.GetComponent<BossHealth>()?.TakeDamage(1);
            DestroyObj();
        }
        if (other.CompareTag("Player"))
        {
            Manager.getInstance().PlayerHealth.TakeDamage(1, HealthType.Red);
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
