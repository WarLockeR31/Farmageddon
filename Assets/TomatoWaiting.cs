using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoWaiting : StateMachineBehaviour
{
    private GameObject playerObj;
    private GameObject tomatoObj;
    private Tomato tomatoScript;
    private float visionRadius;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!playerObj)
        {
            playerObj = Manager.getInstance().Player;
        }

        if (!tomatoObj)
        {
            tomatoObj = animator.gameObject;
        }

        if (!tomatoScript)
        {
            tomatoScript = tomatoObj.GetComponent<Tomato>();
        }

        visionRadius = tomatoScript.VisionRadius;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if ((playerObj.transform.position - tomatoObj.transform.position).magnitude <= visionRadius)
        {
            animator.SetTrigger("isTargeted");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
