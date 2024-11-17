using System.Collections; // Äëÿ IEnumerator
using UnityEngine;

public class PeaScript : MonoBehaviour
{
    [SerializeField]
    public float Scare_range = 10f;

    [SerializeField]
    public float Speed = 20f;

    [SerializeField]
    private GameObject bullet;

    private Animator animator;
    private Rigidbody rb;
    private PeaHealth peaHealth;
    public Vector3 moveDir = Vector3.zero;

    public bool isDead = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        peaHealth = GetComponent<PeaHealth>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (isDead) return;

        rb.position += moveDir * Speed * Time.fixedDeltaTime;
    }

    public void Shoot()
    {
        if (isDead) return;

        bullet.transform.position = new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z);
        var obj = Instantiate(bullet);
        var scr = obj.GetComponent<Bullet>();
        scr.target = (Manager.getInstance().Player.transform.position - transform.position).normalized;
    }

    public void Die()
    {
        if (isDead) return;
        isDead = true;

        animator.Play("Pea_death", 0, 0);

        rb.velocity = Vector3.zero;
        moveDir = Vector3.zero;

        StartCoroutine(DisableAnimatorAfterAnimation());
    }

    private IEnumerator DisableAnimatorAfterAnimation()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        animator.enabled = false;
        Destroy(gameObject);
    }
}
