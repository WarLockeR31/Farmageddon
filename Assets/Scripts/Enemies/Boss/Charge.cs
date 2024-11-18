using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Charge : StateMachineBehaviour
{
    private GameObject player;
    private GameObject boss;
    private Boss bossScript;
    private Vector3 direction;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!player)
        {
            player = Manager.getInstance().Player;
        }
        if (!boss)
        {
            boss = animator.gameObject;
        }
        if (!bossScript)
        {
            bossScript = boss.GetComponent<Boss>();
        }
        bossScript.isStunned = false;

        BossSounds.getInstance().charge.Play();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(!bossScript.Hitbox.activeSelf)
        {
            direction = (player.transform.position-boss.transform.position).normalized;
            if (bossScript.isStunned)
            {
                animator.SetTrigger("Stun");
            }
        }
        if (bossScript.Hitbox.activeSelf)
        {
            boss.transform.position+=new Vector3(direction.x, 0, direction.z)*bossScript.dashSpeed*Time.deltaTime;
        }
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossScript.isStunned = false;
        animator.ResetTrigger("Stun");
        animator.ResetTrigger("Charge");
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
