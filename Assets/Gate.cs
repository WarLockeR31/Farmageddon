using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField]
    private bool isOpened = false;

    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private float rotationAngle;

    [SerializeField]
    private Transform pivot;

    private float startRotationY;
    private float targetRotationY;

    [SerializeField]
    private bool clockWise = true;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (true) //проверка на зачищенность арены
            {
                if (!isOpened)
                    Open();
            }
        }
    }

    void Open()
    {
        isOpened = true;
        StartCoroutine(OpeningY());
    }

    System.Collections.IEnumerator OpeningY()
    {
        startRotationY = pivot.rotation.eulerAngles.y;
        targetRotationY = startRotationY + (clockWise ? rotationAngle : -rotationAngle);

        while (!(pivot.rotation.eulerAngles.y < targetRotationY + 1f && pivot.rotation.eulerAngles.y > targetRotationY - 1f))
        {
            pivot.Rotate(new Vector3(0f, (clockWise ? rotateSpeed : -rotateSpeed) * Time.deltaTime, 0f));

            yield return new WaitForEndOfFrame();
        }
    }
}
