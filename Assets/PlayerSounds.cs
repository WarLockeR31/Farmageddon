using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField]
    public AudioSource batStart;

    [SerializeField]
    public AudioSource katanaStart;

    [SerializeField]
    public AudioSource coinStart;

    [SerializeField]
    public AudioSource batHit;

    [SerializeField]
    public AudioSource katanaHit;

    [SerializeField]
    public AudioSource step;

    [SerializeField]
    public List<AudioClip> steps;

    //katanaHit.Play();
}
