using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_LockedDoor : Action
{
    int actionCount = 0;
    DialogueSystem dialogueSystem;
    GameManager gameManager;
    [SerializeField] Sprite angryVer;

    public override void action()
    {
        actionCount += 1;
        if(dialogueSystem == null)
        {
            dialogueSystem = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<DialogueSystem>();
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }

        if(actionCount >= 30)
        {
            dialogueSystem.appereance(gameManager.ActualText.LockedDoorPrank2);
            if(actionCount == 32)GetComponent<SpriteRenderer>().sprite = angryVer;
            dialogueSystem.NextSentence();
        }
        else if(actionCount >= 10)
        {
            dialogueSystem.appereance(gameManager.ActualText.LockedDoorPrank);
           
        }
        else
            dialogueSystem.appereance(gameManager.ActualText.LockedDoor);
        
    }
}
