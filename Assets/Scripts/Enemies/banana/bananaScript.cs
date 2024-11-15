using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bananaScript : MonoBehaviour
{


    [SerializeField]
    public float oldSpeed = 10f;
    public float newSpeed = 15f;
    [SerializeField]
    public float triggerDistance = 30f;
    [SerializeField]
    public float detonationRange = 3f;


    private void OnTriggerEnter(Collider other)
    {
        
    }


}
