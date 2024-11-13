using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDroper : MonoBehaviour
{
    [SerializeField]
    private GameObject item;
    public void DropItem ()
    {
        item.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        Instantiate(item, item.transform);
    }
}
