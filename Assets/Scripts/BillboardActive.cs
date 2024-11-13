using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Повесь этот класс на активный объект, если хочешь чтоб он смотрел в камеру
/// </summary>
public class BillboardActive : MonoBehaviour
{
    void Update()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
