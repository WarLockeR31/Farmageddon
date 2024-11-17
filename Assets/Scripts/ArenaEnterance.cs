using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaEnterance : MonoBehaviour
{
    [SerializeField]
    private Gate gate;

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
            if (true) //�������� �� ������������ �����
            {
                arenaManager.StartWaves();
                gate.Close();
                gameObject.SetActive(false);
            }
        }
    }
}
