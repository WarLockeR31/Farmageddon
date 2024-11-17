using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bananaScript : MonoBehaviour
{
    [SerializeField]
    private AudioSource fly;
    public AudioSource Fly { get { return fly; } }

    [SerializeField]
    private AudioSource boom;
    public AudioSource Boom { get { return boom; } }

    [SerializeField]
    private AudioSource coinHit;
    public AudioSource CoinHit { get { return coinHit; } }

    [SerializeField]
    public float oldSpeed = 10f;
    public float newSpeed = 15f;
    [SerializeField]
    public float triggerDistance = 30f;
    [SerializeField]
    public float detonationRange = 3f;
    [SerializeField]
    public float damage = 5f;

    private GameObject player;

    private Health PlayerHealth;

}
