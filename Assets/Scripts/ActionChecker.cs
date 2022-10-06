using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionChecker : MonoBehaviour
{
    GameObject actionObject;
    Animator p_animator;
    PlayerManager playerManager;
    DialogueSystem dialogueSystem;
    bool Endtypigtext = false; 

    void Start()
    {
        p_animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        dialogueSystem = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<DialogueSystem>();
    }
    
    void Update()
    {
        /* action v2 */
        /*
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D rayinfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector2.up, 15f);
            if(rayinfo.collider.gameObject.GetComponent<Action>() != null) 
            rayinfo.collider.gameObject.GetComponent<Action>().action();
            //print(rayinfo.collider.gameObject);
        }
        */

        if(Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.E))
        {
            if(actionObject!=null && !playerManager.inMenu)
                actionObject.GetComponent<Action>().action();

        }

        /* Don's dialogue typing sys
        if(Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.E) && !Endtypigtext )
        { 
            if(actionObject!=null && actionObject.GetComponent<Action>())
            {
                actionObject.GetComponent<Action>().action();
                Endtypigtext = true;   
            }
           
        }else if(Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.E) && Endtypigtext)
        {
            Endtypigtext = false;
            dialogueSystem.makeAnimation = false;
            StopCoroutine(dialogueSystem._myCoroutine);
            dialogueSystem.tmpComponent.text = dialogueSystem.scenario[dialogueSystem.index];
           
        }else
        {
            dialogueSystem.makeAnimation = true;
        }      
        */   
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.GetComponent<Action>())
            actionObject = collider.gameObject;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.GetComponent<Action>())
            actionObject = null;
    }

}
