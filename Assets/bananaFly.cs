using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.EventSystems;

public class bananaFly : StateMachineBehaviour
{

    private GameObject player;
    
    private bananaScript bananaScr;
    
    private GameObject banana;
    


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!player)
        {
            player = Manager.getInstance().Player;
        }
        
        if(!banana)
        {
            banana = animator.gameObject;
        }
        if (!bananaScr)
        {
            bananaScr =banana.GetComponent<bananaScript>();
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!bananaScr.Fly.isPlaying)
        {
            bananaScr.Fly.Play();
        }
        Vector3 MoveDir = (player.transform.position - banana.transform.position).normalized;
        float distance = Vector3.Distance(player.transform.position, banana.transform.position);
        if (distance > bananaScr.triggerDistance)
        {
            banana.transform.position += new Vector3(MoveDir.x, 0, MoveDir.z)*bananaScr.oldSpeed*Time.deltaTime;
        }
        else
            {
                if (distance <= bananaScr.detonationRange)
                animator.SetTrigger("boom");
            banana.transform.position += MoveDir*bananaScr.newSpeed * Time.deltaTime;
            }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

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
