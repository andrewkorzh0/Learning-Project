using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    PlayerManager playerManager;
    [SerializeField] GameObject[] menuHeaders;
    [SerializeField] GameObject[] menus;
    [SerializeField] Color use;
    Color unUse = new Color(0,0,0,0);
    [SerializeField] GameObject[] itemsOne;
    SoundManager soundManager;
    int actuallMenu = 0;
    int openedMenu = -1; // for exit from opened menu
    int actuallItem = 1;
    bool inItemMenu = false;

    int gamepadClickTime = 0;
    int gamepadClickDirection = 0;
    //-1,1 - vertical, -2,2 - horizontal, 3 - chooseButtonPressed


    void Awake()
    {
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        menuHeaders[actuallMenu].GetComponent<Image>().color = use;
        update = updateMainMenu;
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();

    }

    private delegate void updateVer();
    updateVer update;

    void Update()
    {
        update();
    }

    void updateItemMenu()
    {
        itemsOne[actuallItem-1].GetComponent<Image>().color = unUse;

        if(Input.GetKeyDown(KeyCode.S) || Input.GetAxisRaw("Vertical") == -1 )
        {
            if(gamepadClickTime != 1 || gamepadClickDirection != -1 && Mathf.Abs(gamepadClickDirection) != 2)
            {
                //gamepad
                gamepadClickDirection = -1;
                gamepadClickTime = 1;

                if(actuallItem == 5 || actuallItem == 6)
                    actuallItem -= 4;
                else
                    actuallItem += 2;

                soundManager.playSound("menu");
            }
            
        }
        else if(Input.GetKeyDown(KeyCode.A) || Input.GetAxisRaw("Horizontal") == -1 )
        {
            if(gamepadClickTime != 1 || gamepadClickDirection != -2 && Mathf.Abs(gamepadClickDirection) != 1)
            {
                //gamepad
                gamepadClickDirection = -2;
                gamepadClickTime = 1;

                if(actuallItem % 2 != 0)
                    actuallItem += 1;
                else
                    actuallItem -= 1;

                soundManager.playSound("menu");
            }
        }
        else if(Input.GetKeyDown(KeyCode.W) || Input.GetAxisRaw("Vertical") == 1)
        {
            if(gamepadClickTime != 1 || gamepadClickDirection != 1 && Mathf.Abs(gamepadClickDirection) != 2)
            {
                //gamepad
                gamepadClickDirection = 1;
                gamepadClickTime = 1;
                
                if(actuallItem == 1 || actuallItem == 2)
                    actuallItem += 4;
                else
                    actuallItem -= 2;

                soundManager.playSound("menu");
            }
        }
        else if(Input.GetKeyDown(KeyCode.D) || Input.GetAxisRaw("Horizontal") == 1)
        {
            if(gamepadClickTime != 1 || gamepadClickDirection != 2 && Mathf.Abs(gamepadClickDirection) != 1)
            {
                //gamepad
                gamepadClickDirection = 2;
                gamepadClickTime = 1;

                if(actuallItem % 2 != 0)
                    actuallItem += 1;
                else
                    actuallItem -= 1;

                soundManager.playSound("menu");
            }
        }
        
        else if(Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            update = updateMainMenu;
            menus[actuallMenu].SetActive(!menus[actuallMenu].activeInHierarchy);
            actuallItem = 1;
            soundManager.playSound("menu");
        }
        else if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            playerManager.sessionSave.inventory[actuallItem-1] = 0;
            menus[actuallMenu].GetComponent<MenuContent>().LoadInventory();
            soundManager.playSound("menu");
        }
        else if(Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            playerManager.addItemToInventory(3);
            menus[actuallMenu].GetComponent<MenuContent>().LoadInventory();
            soundManager.playSound("menu");
        }
        itemsOne[actuallItem-1].GetComponent<Image>().color = use;
        print(actuallItem);


        if(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
            gamepadClickTime = 0;
    }


    void updateMainMenu()
    {
        if(Input.GetAxisRaw("Vertical") == 0) gamepadClickTime = 0;
        if(Input.GetKeyDown(KeyCode.S) || Input.GetAxisRaw("Vertical") == -1 )
        {
            if(gamepadClickTime != 1 || gamepadClickDirection == 1)
            {

                //gamepad
                gamepadClickTime = 1;
                gamepadClickDirection = -1;

                menuHeaders[actuallMenu].GetComponent<Image>().color = unUse;
                if(actuallMenu == 2) actuallMenu = 0;
                else actuallMenu+=1;
                menuHeaders[actuallMenu].GetComponent<Image>().color = use;

                soundManager.playSound("menu");

            }
        }
        else if(Input.GetKeyDown(KeyCode.W) || Input.GetAxisRaw("Vertical") == 1)
        {
            if(gamepadClickTime != 1 || gamepadClickDirection == -1)
            {

                //gamepad
                gamepadClickTime = 1;
                gamepadClickDirection = 1;

                menuHeaders[actuallMenu].GetComponent<Image>().color = unUse;
                if(actuallMenu == 0) actuallMenu = 2;
                else actuallMenu-=1;
                menuHeaders[actuallMenu].GetComponent<Image>().color = use;

                soundManager.playSound("menu");

            }
        }
        else if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            
            foreach(GameObject i in menus)
            i.SetActive(false);
            
            menus[actuallMenu].SetActive(!menus[actuallMenu].activeInHierarchy);
            try
            {
                menus[actuallMenu].GetComponent<MenuContent>().LoadInventory();
                itemsOne[actuallItem-1].GetComponent<Image>().color = use;
                update = updateItemMenu;
                soundManager.playSound("menu");
            }
            catch
            {
                Debug.LogError("isn't content fot that menu: " + menuHeaders[actuallMenu].name);
            }
            openedMenu = actuallMenu;
            /*try
            {
            }
            catch
            {
                Debug.LogError("isn't content fot that menu: " + menuHeaders[actuallMenu].name);
            }*/
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            gameObject.SetActive(!gameObject.activeInHierarchy);
            playerManager.couldMove = !playerManager.couldMove;
            playerManager.inMenu = false;
            soundManager.playSound("menu");
        }
    }

    public void exit()
    {
        foreach(GameObject i in menus)
            i.SetActive(false);
        openedMenu = -1;
        update = updateMainMenu;
        itemsOne[actuallItem-1].GetComponent<Image>().color = unUse;
        actuallItem = 1;
    }
    
}
