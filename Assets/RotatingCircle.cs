using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCircle : MonoBehaviour
{
    [SerializeField]
    private float pivotY;

    [SerializeField]
    private float moonsDistance;
    public float MoonsDistance { get { return moonsDistance; } }

    [SerializeField]
    private float speed;

    [SerializeField]
    private Vector3 axises;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = Manager.getInstance().Player;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(transform.localEulerAngles + axises * speed * Time.deltaTime);

        transform.position = player.transform.position + new Vector3(0f, pivotY, 0f);
    }
}
