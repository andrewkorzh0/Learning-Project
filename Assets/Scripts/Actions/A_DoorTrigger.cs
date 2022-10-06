using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_DoorTrigger : Action
{
    [SerializeField] int room, enterWay;

    public override void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.tag == "Player") GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>().loadRoom(room, enterWay);
    }
}
