using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ ���� ����� �� �������� ������, ���� ������ ���� �� ������� � ������
/// </summary>
public class BillboardActive : MonoBehaviour
{
    void Update()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
