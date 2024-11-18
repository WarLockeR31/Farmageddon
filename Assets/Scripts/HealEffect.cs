using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEffect : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        Manager.getInstance().PlayerHealth.OnRedHeal.AddListener(RedHeal);
        Manager.getInstance().PlayerHealth.OnGreenHeal.AddListener(GreenHeal);
        Manager.getInstance().PlayerHealth.OnYellowHeal.AddListener(YellowHeal);
    }

    public void RedHeal()
    {
        animator.Play("RedHeal");
    }

    public void GreenHeal()
    {
        animator.Play("GreenHeal");
    }

    public void YellowHeal()
    {
        animator.Play("YellowHeal");
    }
}
