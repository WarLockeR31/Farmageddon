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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pea"))
        {
            other.GetComponent<Health>()?.TakeDamage(10);
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
