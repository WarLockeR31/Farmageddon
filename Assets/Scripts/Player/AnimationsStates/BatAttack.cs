using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class BatAttack : StateMachineBehaviour
{
    private void Bat(Interactable interactable)
    {
        interactable.BatBeat(Camera.main.transform.forward);
    }
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Manager.getInstance().attackControl.attack += Bat;
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Manager.getInstance().attackControl.attack -= Bat;
    }
}
