using UnityEngine;

public class Tomato : Interactable
{
    private Animator animator;
    private TomatoHealth tomatoHealth;
    private GameObject player;
    private PlayerHealth playerHealth;
    private CharacterController playerController;
    private Rigidbody rb;

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

    [SerializeField] 
    private float damageAmount;

    [SerializeField]
    private float punchRecoilPower;

    [SerializeField]
    private float punchRecoilTime;

    [SerializeField]
    private float visionRadius;
    public float VisionRadius { get { return visionRadius; } }

    private bool isPunched = false;
    public void isPunchedFalse()
    {
        isPunched = false;
    }

    void Start()
    {
        player = Manager.getInstance().Player;
        animator = GetComponent<Animator>();
        tomatoHealth = GetComponent<TomatoHealth>();
        playerHealth = player.GetComponent<PlayerHealth>();
        playerController = player.GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();

        if (tomatoHealth == null)
        {
            Debug.LogError("TomatoHealth �� ������ �� ������� Tomato");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isPunched && other.gameObject.CompareTag("Wall"))
        {
            animator.Play("Running");
            tomatoHealth.TakeDamage(damageAmount);
            Debug.Log(tomatoHealth.CurrentHealth);
            return;
        }

        if (isPunched && (other.gameObject.CompareTag("Enemy")||other.gameObject.CompareTag("Pea")))
        {
            animator.Play("Running");
            tomatoHealth.TakeDamage(damageAmount);
            other.GetComponent<Health>().TakeDamage(200);
            
            return;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(damageAmount, HealthType.Red);
            StartCoroutine(PlayerRecoil());
            
            return;
        }
    }

    System.Collections.IEnumerator PlayerRecoil()
    {
        float timer = punchRecoilTime;
        Vector3 recoilDirection = (player.transform.position - transform.position).normalized;

        while (timer > 0)
        {
            playerController.Move(recoilDirection * punchRecoilPower * Time.deltaTime);

            timer -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

    public override void BatBeat(Vector3 dir)
    {
        base.BatBeat(dir);
        tomatoHealth.TakeDamage(damageAmount);
        animator.SetTrigger("isPunched");
        isPunched = true;
        punchDirection = dir;
    }
}
