using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDroper : MonoBehaviour
{
    [SerializeField]
    private GameObject item;
    public void DropItem ()
    {
        var instanceItme = Instantiate(item);
        instanceItme.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }
}
