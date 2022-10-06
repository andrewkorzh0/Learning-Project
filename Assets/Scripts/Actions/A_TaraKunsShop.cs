using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_TaraKunsShop : Action
{
    DialogueSystem dialogueSystem;
    GameManager gameManager;
    [SerializeField] GameObject shop;
    int count = 0;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public override void action()
    {
        if(dialogueSystem == null)
            dialogueSystem = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<DialogueSystem>();
        dialogueSystem.appereance(gameManager.ActualText.tarakunsshop_1);
        //shop.SetActive(true);
    }
}
