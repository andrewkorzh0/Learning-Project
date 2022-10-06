using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_VolleyballFox : Action
{
    DialogueSystem dialogueSystem;
    GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    
    /* string[] dialogue_test = new string[3]
    {
        "hello",
        "i am volleyball fox lol",
        "yes, this is just test dialogue"
    }; weird stuff idk*/ 

    public override void action()
    {
        if(dialogueSystem == null) dialogueSystem = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<DialogueSystem>();
        dialogueSystem.appereance(gameManager.ActualText.volleyballfox_1);
        print("volleyball fox is acted(?)");
        
    }

}
