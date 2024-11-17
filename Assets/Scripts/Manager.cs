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

    private PlayerSounds playerSounds;
    public PlayerSounds PlayerSounds { get { return playerSounds; } }

    public GameObject Player { get { return player; } }
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

    private void Start()
    {
        playerSounds = Player.GetComponent<PlayerSounds>();
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
