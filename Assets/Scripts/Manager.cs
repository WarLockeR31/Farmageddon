using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private static Manager instance;

    [SerializeField]
    private GameObject player;
    public GameObject Player { get { return player; } }

    public Animator animator;

    private void Awake()
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
