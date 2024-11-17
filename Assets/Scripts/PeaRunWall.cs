using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaRunWall : StateMachineBehaviour
{
    GameObject player;
    PeaScript peaScript;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = Manager.getInstance().Player;
        peaScript = animator.gameObject.GetComponent<PeaScript>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!peaScript.RunSound.isPlaying)
        {
            peaScript.RunSound.Play();
        }

        if (Vector3.Distance(animator.transform.position, player.transform.position) > peaScript.Scare_range)
        {
            animator.SetTrigger("Shoot");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        peaScript.RunSound.Stop();
        animator.ResetTrigger("OffTheWall");
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
