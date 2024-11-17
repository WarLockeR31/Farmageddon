using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    [SerializeField]
    private float duration;

    [SerializeField]
    private float magnitude;

    private Vector3 originalPos;

    private void Start()
    {
        originalPos = transform.localPosition;
    }

    public void StartShake()
    {
        transform.localPosition = originalPos;
        StartCoroutine(Shaking());
    }

    private IEnumerator Shaking()
    {
        originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = transform.localPosition + new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        transform.localPosition = originalPos;
    }
}
