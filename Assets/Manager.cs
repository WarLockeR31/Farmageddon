using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private static Manager instance;


    public Animator animator;
    private void Start()
    {
        instance = this;
    }
    public static Manager getInstance()
    {
        if (instance == null)
        {
            instance = new Manager();
        }
        return instance;
    }
}
