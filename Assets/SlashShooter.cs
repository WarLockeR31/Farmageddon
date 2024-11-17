using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject Slash;
    private GameObject player;
    private void OnEnable()
    {
        player = Manager.getInstance().Player;
        Slash.transform.position = transform.position;
        var obj = Instantiate(Slash);
        var scr = obj.GetComponent<SlashProjectile>();
        var target = (player.transform.position - transform.position).normalized;
        target = new Vector3(target.x, 0, target.z).normalized;
        scr.target = target;
    }
}
