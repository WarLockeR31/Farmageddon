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

        Vector3 bul_pos = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
        var obj = Instantiate(bullet, bul_pos, Quaternion.identity);
        
        var scr = obj.GetComponent<Bullet>();
        scr.target = (Manager.getInstance().Player.transform.position - bul_pos).normalized;
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

    void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Wall")) return;
        var item = other.contacts[0];
        moveDir = Vector3.Reflect(moveDir, item.normal);
        animator.SetTrigger("OffTheWall");
        Debug.Log(Vector3.Angle(item.normal, moveDir));
    }
}
