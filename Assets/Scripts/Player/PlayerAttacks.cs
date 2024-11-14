using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Manager.getInstance().animator.SetTrigger("bat_attack");
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Manager.getInstance().animator.SetTrigger("katana");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Manager.getInstance().animator.SetTrigger("coin");
        }

        // testing intems abils
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Manager.getInstance().ActivateItem(new RedHeal());
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Manager.getInstance().ActivateItem(new SpeedUp());
        }
    }
}
