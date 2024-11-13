using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Повесь этот класс на активный объект, если хочешь чтоб он смотрел в камеру
/// </summary>
public class BillboardActive : MonoBehaviour
{
    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);
        transform.LookAt(targetPosition);
    }
}
