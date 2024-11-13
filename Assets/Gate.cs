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
    private Transform pivot;

    private float startRotationY;
    private float targetRotationY;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Coll");
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
        StartCoroutine(Opening());
    }

    System.Collections.IEnumerator Opening()
    {
        startRotationY = pivot.rotation.eulerAngles.y;
        targetRotationY = startRotationY + 135f;

        while (pivot.rotation.eulerAngles.y < targetRotationY)
        {
            pivot.Rotate(new Vector3(0f, rotateSpeed * Time.deltaTime, 0f));

            yield return new WaitForEndOfFrame();
        }
    }
}
