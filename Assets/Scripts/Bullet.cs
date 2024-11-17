using System.Collections;
using UnityEngine;

public class Bullet : Interactable
{
    [SerializeField]
    private float speed;

    public Vector3 target;

    [SerializeField]
    private float activeTime;

    private bool isParried = false;
    private bool hasDealtDamage = false; 
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
        Manager.getInstance().PlayerSounds.katanaHit.Play();
        isParried = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasDealtDamage) return;

        if (isParried && other.CompareTag("Pea"))
        {
            var health = other.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(10);
                Debug.Log($"Пуля нанесла 10 урона врагу: {other.name}. Текущее здоровье: {health.CurrentHealth}");
                hasDealtDamage = true;
            }
            DestroyObj();
        }

        if (other.CompareTag("Wall") || other.CompareTag("Terrain"))
        {
            DestroyObj();
        }

        if (other.CompareTag("Player"))
        {
            Manager.getInstance().PlayerHealth.TakeDamage(2, HealthType.Green);
            hasDealtDamage = true;
            DestroyObj();
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
