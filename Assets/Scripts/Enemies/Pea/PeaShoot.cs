using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pea_shoot : StateMachineBehaviour
{
    private GameObject player;
    private GameObject pea;
    private PeaScript peaScript;
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

        if (!peaScript)
        {
            peaScript = pea.GetComponent<PeaScript>();
        }

        peaScript.moveDir = Vector3.zero;
    }

    float Dist(GameObject dest, GameObject beg)
    {
        return (float)Math.Sqrt((Math.Pow(dest.transform.position.x - beg.transform.position.x, 2)) + Math.Pow(dest.transform.position.z-beg.transform.position.z, 2));

    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Vector3.Distance(player.transform.position, pea.transform.position) <= peaScript.Scare_range)
        {
            animator.SetTrigger("Run");
        }
    }

   
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Run");
    }
}
