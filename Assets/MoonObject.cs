using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonObject : MonoBehaviour
{
    private RotatingCircle rotatingCircle;

    // Start is called before the first frame update
    void Start()
    {
        rotatingCircle = GetComponentInParent<RotatingCircle>();
        transform.position = rotatingCircle.transform.position + (transform.position - rotatingCircle.transform.position).normalized * rotatingCircle.MoonsDistance;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(1, 1, 1) * Time.deltaTime * 50f);
    }
}
