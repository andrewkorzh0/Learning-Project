using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_CollectFlower : Action
{
    [SerializeField] Sprite Collected;
    PlayerManager playerManager;
    void Start()
    {
       playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
    }
    bool collected = false;
    public override void action()
    {
        if(collected == false && !playerManager.isInventoryFull())
        {
            playerManager.addItemToInventory(4);
            GetComponent<SpriteRenderer>().sprite = Collected;
            collected = true;
        }
    }
}
