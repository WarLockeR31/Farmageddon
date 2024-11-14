using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControl : MonoBehaviour
{
    public Action<Interactable> attack;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) return;
        var interact = other.GetComponent<Interactable>();
        if (interact == null) return;
        attack?.Invoke(interact);
    }
}
