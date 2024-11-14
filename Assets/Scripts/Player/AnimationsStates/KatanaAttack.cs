using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaAttack : StateMachineBehaviour
{
    private void Katana(Interactable interactable)
    {
        interactable.KatanaBeat(Camera.main.transform.forward);
    }
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Manager.getInstance().attackControl.attack += Katana;
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Manager.getInstance().attackControl.attack -= Katana;
    }
}
