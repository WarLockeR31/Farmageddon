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
        Vector3 targetPosition = new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);
        transform.LookAt(targetPosition);
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
