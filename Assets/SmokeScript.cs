using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeScript : MonoBehaviour
{
    [SerializeField]
    private GameObject smoke;

    private void OnEnable()
    {
        smoke.transform.position = transform.position;
        Instantiate(smoke);
    }
}
