using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class Pea_run : StateMachineBehaviour
{
    private GameObject player;
    private GameObject pea;
    private Rigidbody rb;
    private PeaScript peaScript;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!player)
        {
            player = Manager.getInstance().Player;
        }

        if (!pea)
        {
            pea = animator.gameObject;
        }

        rb = animator.GetComponent<Rigidbody>();

        if (!peaScript)
        {
            peaScript = pea.GetComponent<PeaScript>();
        }
    }
    float Dist(Rigidbody dest, GameObject beg)
    {
        return (float)Math.Sqrt((Math.Pow(dest.position.x - beg.transform.position.x, 2)) + Math.Pow(dest.transform.position.z-beg.transform.position.z, 2));

    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Dist(rb, player) > peaScript.Scare_range)
        {
            animator.SetTrigger("Shoot");
        }
        Vector3 moveDirection = -(player.transform.position - rb.position).normalized;
        peaScript.moveDir.x = moveDirection.x;
        peaScript.moveDir.z = moveDirection.z;

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Run");
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
