using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Door : Action
{
    [SerializeField] int room, enterWay;
    public override void action()
    {
        GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>().loadRoom(room, enterWay);
    }
}
