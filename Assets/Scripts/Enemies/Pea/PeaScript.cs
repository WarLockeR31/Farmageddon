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






    void Start()
    {
        player = Manager.getInstance().Player;
        animator = GetComponent<Animator>();
        peaHealth = GetComponent<TomatoHealth>();
        playerHealth = player.GetComponent<PlayerHealth>();
        playerController = player.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
