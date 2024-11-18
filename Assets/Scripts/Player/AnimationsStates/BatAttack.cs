using System.Collections;
using System.Collections.Generic;
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
        Manager.getInstance().PlayerSounds.batStart.Play();
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Manager.getInstance().attackControl.attack -= Bat;
    }
}
