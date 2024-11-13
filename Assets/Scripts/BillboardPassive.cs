using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Повесь этот класс на объект, если хочешь чтоб он смотрел в камеру
/// </summary>
public class BillboardPassive : MonoBehaviour
{
    void OnEnable()
    {
        if (!GetComponent<Renderer>().isVisible)
        {
            enabled = false;
        }
    }

    void LateUpdate()
    {
        transform.forward = Camera.main.transform.forward;
    }

    void OnBecameVisible()
    {
        enabled = true;
    }

    void OnBecameInvisible()
    {
        enabled = false;
    }
}
