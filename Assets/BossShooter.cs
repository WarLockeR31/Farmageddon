using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    private GameObject player;
    private void OnEnable()
    {
        player = Manager.getInstance().Player;
        bullet.transform.position = transform.position;
        var obj = Instantiate(bullet);
        var scr = obj.GetComponent<BossBullet>();
        scr.target = (player.transform.position - transform.position).normalized;
    }

}
