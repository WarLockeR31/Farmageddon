using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class BatAttack : StateMachineBehaviour
{
    private void Bat(Interactable interactable)
    {
        interactable.BatBeat(new Vector3(Camera.main.transform.forward.x,
            0, 
            Camera.main.transform.forward.z));
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
