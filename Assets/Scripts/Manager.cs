using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private static Manager instance;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private PlayerHealth playerHealth;
    [SerializeField]
    public GameObject Player { get { return player; } }
    [SerializeField]
    public PlayerHealth PlayerHealth { get { return playerHealth; } }
    [SerializeField]
    public AttackControl attackControl;

    public Animator animator;

    private void Awake()
    {
        instance = this;
    }
    public static Manager getInstance()
    {
        if (instance == null)
        {
            instance = new Manager();
        }
        return instance;
    }

    // Item System
    public void ActivateItem(Item item)
    {
        Debug.Log("Item activated");
        item.Do();
        if (item.ActionTime > 0)
        {
            StartCoroutine(DelayedAction(item.ActionTime, item.Undo));
        }
    }   
    
    IEnumerator DelayedAction(float delay, System.Action action)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Item aisabled");
        action.Invoke();
    }
}
