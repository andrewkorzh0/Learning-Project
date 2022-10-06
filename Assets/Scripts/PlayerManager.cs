using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveData
{
    public string name;
    public int hp;
    public int[] inventory = new int[6];
    public int room;
    //test
    public bool LOADROOMTEST;
}

public class PlayerManager : MonoBehaviour
{

    //dev mode
    [Header("dev mode")]
    [SerializeField] GameObject soundManagerPrefab;

    [Header("transit")]
    [SerializeField] GameObject brContainer;

    [Header("UI")]
    [SerializeField] GameObject player_menu;
    GameManager gameManager;
    SoundManager soundManager;
    public bool inAction = false;
    public bool couldMove = true;
    public bool inMenu = false;

    //save stuff
    public SaveData sessionSave = new SaveData();
    
    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        try
        {
            soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        }
        catch // just for testing scenes
        {
            Instantiate(soundManagerPrefab);
            soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        }
        try
        {
            GiveSaveBetweenScenes betweenRoomContainer = GameObject.FindGameObjectWithTag("TTGSBS").GetComponent<GiveSaveBetweenScenes>();
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            
            sessionSave = betweenRoomContainer.saveData;
            try
            {
                player.transform.position = GameObject.FindGameObjectWithTag("roomData").GetComponent<RoomData>().enterPositions[betweenRoomContainer.enterWay];
            }catch{}

            player.GetComponent<Movement>().stay_type = GameObject.FindGameObjectWithTag("roomData").GetComponent<RoomData>().enterPositionsIdles[betweenRoomContainer.enterWay];
            sessionSave.room = SceneManager.GetActiveScene().buildIndex;
            Destroy(GameObject.FindGameObjectWithTag("TTGSBS"));
        }
        catch{}

        sortInventory();
    }
    IEnumerator wait(){yield return new WaitForSeconds(1f);}
    
    bool buttonPressed;
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            if(GetComponent<DialogueSystem>().in_dialogue != true)
            {
                player_menu.SetActive(!player_menu.activeInHierarchy);
                player_menu.GetComponent<MenuManager>().exit();
                couldMove = !couldMove;
                inMenu = !inMenu;
                soundManager.playSound("menu");
            }
        }
        if(Input.GetKeyDown(KeyCode.JoystickButton5) || Input.GetKeyDown(KeyCode.L))
        {
            gameManager.LoadGame();
        }
        if(Input.GetAxisRaw("RightTrigger") == 1 && !buttonPressed)
        {
            buttonPressed = true;
            gameManager.SaveGame(sessionSave);
        }
        else if(Input.GetAxisRaw("RightTrigger") == 0)
            buttonPressed = false;
    }

    public void loadRoom(int room, int enterWayNum = 0)
    {
        Instantiate(brContainer);
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("TTGSBS"));
        GiveSaveBetweenScenes betweenRoomContainer = GameObject.FindGameObjectWithTag("TTGSBS").GetComponent<GiveSaveBetweenScenes>();
        betweenRoomContainer.saveData = sessionSave;
        betweenRoomContainer.enterWay = enterWayNum;
        SceneManager.LoadScene(room);
    }

    public bool isInventoryFull()
    {
        foreach(int i in sessionSave.inventory)
        {
            if(i == 0)
                return false;
        }
        return true;
    }

    public void addItemToInventory(int item)
    {
        for(int i = 0; i < 6; i++)
        {
            if(sessionSave.inventory[i] == 0)
            {
                sessionSave.inventory[i] = item;
                i = 6;
            }
        }
    }

    public void sortInventory()
    {
        //test
        int[] timeInv = {0,0,0,0,0,0};
        //

        //make from 0,0,0,1,0,2 this 1,2,0,0,0,0
        int j = 0;
        for(int i = 0; i < 6; i++)
        {
			if (sessionSave.inventory[i] != 0)
			{
				timeInv[j] = sessionSave.inventory[i];
				j++;
			}
		}
        sessionSave.inventory = timeInv;
    }
}
