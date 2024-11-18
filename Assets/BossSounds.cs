using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSounds : MonoBehaviour
{
    private static BossSounds instance;

    private void Awake()
    {
        instance = this;
    }
    public static BossSounds getInstance()
    {
        if (instance == null)
        {
            instance = new BossSounds();
        }
        return instance;
    }

    [SerializeField]
    public AudioSource charge;

    [SerializeField]
    public AudioSource slash;

    [SerializeField]
    public AudioSource shot;

    [SerializeField]
    public AudioSource smoke;

    [SerializeField]
    public AudioSource coinHit;
}
