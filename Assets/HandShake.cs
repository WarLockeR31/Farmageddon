using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandShake : MonoBehaviour
{
    [SerializeField]
    private RectTransform rectTransform;

    [SerializeField]
    private AnimationCurve posCurveY;

    [SerializeField]
    private float timeY;
    private float curTimeY = 0;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (curTimeY >= timeY)
        {
            curTimeY = 0;
        }

        rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, posCurveY.Evaluate(curTimeY / timeY), rectTransform.localPosition.z);


        curTimeY += Time.deltaTime;
    }
}
