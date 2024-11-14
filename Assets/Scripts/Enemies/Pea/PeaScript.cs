using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaScript : MonoBehaviour
{

    [SerializeField]
    public float Scare_range = 10f;

    [SerializeField]
    public float Speed = 4f;


    private PlayerHealth playerHealth;
    private Animator animator;
    private TomatoHealth peaHealth;
    private GameObject player;
    private CharacterController playerController;
    public Vector3 moveDir;
    private Rigidbody rb;





    void Start()
    {
        player = Manager.getInstance().Player;
        animator = GetComponent<Animator>();
        peaHealth = GetComponent<TomatoHealth>();
        playerHealth = player.GetComponent<PlayerHealth>();
        playerController = player.GetComponent<CharacterController>();
        moveDir = Vector3.zero;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.position += moveDir * Speed * Time.fixedDeltaTime;
    }

    void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Wall")) return;
        var item = other.contacts[0];
        moveDir = Quaternion.Euler(0, 180f - Vector3.Angle(item.normal, moveDir), 0) * item.normal;
        animator.SetTrigger("OffTheWall");
        Debug.Log(Vector3.Angle(item.normal, moveDir));
    }
}
