using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SmokeBomb : StateMachineBehaviour
{
    private GameObject player;
    
    private GameObject boss;
    
    private Boss bossScript;
    
    private int randomAttack;
    
    private int dashDirRand;
    
    private SpriteRenderer Teleport;
    
    private float teleportDistance;
    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if(!player)
        {
            player = Manager.getInstance().Player;
        }
        if(!boss)
        {
            boss = animator.gameObject;
        }
        if (!bossScript)
        {
            bossScript = boss.GetComponent<Boss>();
        }
        Teleport = boss.GetComponentInChildren<SpriteRenderer>();
        randomAttack = Random.Range(1, 4); //Выбор рандомной атаки
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!Teleport.isVisible)
        {
            switch(randomAttack)
            {
                case 1: animator.SetTrigger("Charge");
                    teleportDistance = 5f;
                    break;
                case 2: animator.SetTrigger("Shoot");
                    teleportDistance = 20f;
                    break;
                case 3: animator.SetTrigger("Slash");
                    teleportDistance = 15f;
                    break;
                      
            }
        }
    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossScript.isStunned = false;
        animator.ResetTrigger("Charge");
        animator.ResetTrigger("Shoot");
        animator.ResetTrigger("Slash");
        dashDirRand = Random.Range(1, 4); //Выбор рандомного направления дэша
        
        switch (dashDirRand)
        {
            case 1:

                boss.transform.position = new Vector3(player.transform.position.x + teleportDistance, 0, player.transform.position.z);
                break;

            case 2:
                boss.transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z + teleportDistance);
                break;

            case 3:
                boss.transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z - teleportDistance);
                break;

        }
    } 

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
