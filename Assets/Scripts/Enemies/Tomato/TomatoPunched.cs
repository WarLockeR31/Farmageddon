using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoPunched : StateMachineBehaviour
{
    private GameObject tomatoObj;
    private Tomato tomatoScript;
    private float timer;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!tomatoObj)
        {
            tomatoObj = animator.gameObject;
        }

        if (!tomatoScript)
        {
            tomatoScript = tomatoObj.GetComponent<Tomato>();
        }

        timer = tomatoScript.PunchFlightTime;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            animator.SetTrigger("isStopped");
        }
        timer -= Time.deltaTime;
        tomatoObj.transform.position += tomatoScript.PunchDirection * tomatoScript.PunchSpeed * Time.deltaTime;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tomatoScript.isPunchedFalse();
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
