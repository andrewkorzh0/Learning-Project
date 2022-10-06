using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("language packs")]
    [SerializeField] public TextDataBase EnglishText;
    [SerializeField] public TextDataBase RussianText;
    public TextDataBase ActualText;
    public string actualLanguage = "eng";
    
    string configPath = @"A:\projs\ultramarine color clouds\Assets\config.gconf";
    public string confPath
    {
        get {return configPath;}
    }
    
    [SerializeField] GameObject TTGSBS;
    public SaveData save = new SaveData();
    string savePath = @"A:\projs\ultramarine color clouds\Assets\one.save";
    string[] defaultSave = 
    {
        "name",
        "999",
        "0",
        "1",
        "2",
        "3",
        "3",
        "3",
        "0"
    };
    
    void Awake()
    {
       
        Application.targetFrameRate = -1;
        ActualText = File.ReadAllLines(configPath)[0] == "eng" ? EnglishText : RussianText;
        //what, why this isn't working?//Screen.SetResolution(256, 144, true);

        #if !UNITY_EDITOR
            savePath = @"C:\Users\" + Environment.GetEnvironmentVariable("USERNAME") + @"\Desktop\Saves\one.save";
            if(!File.Exists(savePath))
            {
                Directory.CreateDirectory(@"C:\Users\" + Environment.GetEnvironmentVariable("USERNAME") + @"\Desktop\Saves");
                File.Create(@"C:\Users\" + Environment.GetEnvironmentVariable("USERNAME") + @"\Desktop\Saves\one.save").Dispose();
                StartCoroutine(wait());
                File.WriteAllLines(savePath, defaultSave);
            }
        #endif
        
        
    }

    public void SaveGame(SaveData saveData)
    {
        string[] saveFile = new string[10];//9, 10th stroke for test
        saveFile[0] = saveData.name;
        saveFile[1] = saveData.hp.ToString();
        for(int i = 2; i < 8; i++)
            saveFile[i] = saveData.inventory[i-2].ToString();
        saveFile[8] = saveData.LOADROOMTEST == false ? "0" : "1";
        saveFile[9] = saveData.room.ToString();
        File.WriteAllLines(savePath, saveFile);
    }

    public void LoadGame()
    {
        string[] allTheStuff = File.ReadAllLines(savePath);
        save.name = allTheStuff[0];

        int.TryParse(allTheStuff[1], out save.hp);

        for(int i = 2; i < 8; i++)
            int.TryParse(allTheStuff[i], out save.inventory[i-2]);

        int.TryParse(allTheStuff[allTheStuff.Length-1], out save.room);
        
        int ten;
        int.TryParse(allTheStuff[8], out ten);
        save.LOADROOMTEST = ten != 0;
        
        //load scene
        if(SceneManager.sceneCountInBuildSettings < save.room)
        {
            firstLoadRoom(5);
        }
        else firstLoadRoom(save.room);
    }
    
    public void firstLoadRoom(int room)
    {
        Instantiate(TTGSBS);
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("TTGSBS"));
        GiveSaveBetweenScenes ttgsbs = GameObject.FindGameObjectWithTag("TTGSBS").GetComponent<GiveSaveBetweenScenes>();
        ttgsbs.saveData = save;
        SceneManager.LoadScene(room);
    }
}
