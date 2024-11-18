using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenHealObj : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve yAxisShake;
    [SerializeField]
    private float repTime;
    private float curTime = 0;

    private void Update()
    {
        curTime += Time.deltaTime;
        curTime = Mathf.Repeat(curTime, repTime);

        transform.localPosition = new Vector3(transform.localPosition.x, yAxisShake.Evaluate(curTime / repTime), transform.localPosition.z);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Manager.getInstance().ActivateItem(new GreenHeal());
            Destroy(this.gameObject); 
        }
    }
}
