using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaEnterance : MonoBehaviour
{
    private ArenaManager arenaManager;
    // Start is called before the first frame update
    void Start()
    {
        arenaManager = transform.parent.GetComponent<ArenaManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (true) //проверка на зачищенность арены
            {
                arenaManager.StartWaves();
            }
        }
    }
}
