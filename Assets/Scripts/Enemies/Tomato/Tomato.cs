using UnityEngine;

public class Tomato : MonoBehaviour
{
    private Animator animator;
    private TomatoHealth tomatoHealth;

    private Vector3 punchDirection;
    public Vector3 PunchDirection { get { return punchDirection; } }

    [SerializeField]
    private float speed;
    public float Speed { get { return speed; } }

    [SerializeField]
    private float punchFlightTime;
    public float PunchFlightTime { get { return punchFlightTime; } }

    [SerializeField]
    private float punchSpeed;
    public float PunchSpeed { get { return punchSpeed; } }

    [SerializeField] private float damageAmount;

    void Start()
    {
        animator = GetComponent<Animator>();
        tomatoHealth = GetComponent<TomatoHealth>();

        if (tomatoHealth == null)
        {
            Debug.LogError("TomatoHealth не найден на объекте Tomato");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerAttack"))
        {
            animator.SetTrigger("isPunched");
            punchDirection = (Manager.getInstance().Player.transform.rotation * Vector3.forward).normalized;
            tomatoHealth.TakeDamage(damageAmount);
        }
    }
}
