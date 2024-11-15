using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Interactable
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

    public override void KatanaBeat(Vector3 newTarget)
    {
        target = newTarget;
        isParried = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isParried && other.CompareTag("Pea"))
        {
            other.GetComponent<Health>()?.TakeDamage(10);
            DestroyObj();
        }
        if (other.CompareTag("Wall") || other.CompareTag("Terrain"))
        {
            DestroyObj();
        }
        if (other.CompareTag("Player"))
        {
            Manager.getInstance().PlayerHealth.TakeDamage(2, HealthType.Green);
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
