using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseArenaEnterance : MonoBehaviour
{
    [SerializeField]
    private Gate gate;

    private HouseArenaManager arenaManager;
    // Start is called before the first frame update
    void Start()
    {
        arenaManager = transform.parent.GetComponent<HouseArenaManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!arenaManager.IsFighting()) //проверка на зачищенность арены
            {
                arenaManager.StartWaves();
                gate.Close();
                gameObject.SetActive(false);
            }
        }
    }
}
