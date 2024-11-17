using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;

    private AudioSource steps;
    private List<AudioClip> stepsSounds;

    void Start()
    {
        steps = GetComponent<PlayerSounds>().step;
        stepsSounds = GetComponent<PlayerSounds>().steps;
    }


    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        if (x != 0f || z != 0f)
        {
            if (!steps.isPlaying)
            {
                int ind = Random.Range(0, 5);
                steps.clip = stepsSounds[ind];
                steps.Play();
            }
        }

        Vector3 move = (transform.right * x + transform.forward * z).normalized;
        controller.Move(move * PlayerState.Speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);
    }
}
