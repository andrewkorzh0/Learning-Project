using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{
    [SerializeField] GameObject loadButton;
    [SerializeField] GameObject changeLanguageButton;
    GameManager gameManager;
    string configPath;
    
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        configPath = gameManager.confPath;
        loadUI();
        for(int i = 0; i < buttons.Length; i++)
        {
            buttonsLayer[i] = buttons[i].gameObject.GetComponent<Image>();
        }
        buttonsLayer[actionButton].color = use;
    }

    void loadUI()
    {
        gameManager.ActualText = File.ReadAllLines(configPath)[0] == "eng" ? gameManager.EnglishText : gameManager.RussianText;
        changeLanguageButton.GetComponentInChildren<Text>().text = gameManager.ActualText.languageButton;
        loadButton.GetComponentInChildren<Text>().text = gameManager.ActualText.loadButton;
    }


    //menu navigation
    int actionButton = 0;
    [SerializeField] Button[] buttons;
    Image[] buttonsLayer = new Image[2];
    Color use = new Color(0,0,0);
    Color unUse = new Color(255,255,255);
    int gamepadInput = 0;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) || gamepadInput == 0 & Input.GetAxisRaw("Vertical") != 0)
        {
            buttonsLayer[actionButton].color = unUse;
            gamepadInput = 1;
            actionButton = actionButton == 0 ? 1 : 0;
            buttonsLayer[actionButton].color = use;
        }
        else if(Input.GetAxisRaw("Vertical") == 0) gamepadInput = 0;
        if(Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.E))
            buttons[actionButton].onClick.Invoke();
    }
    //

    public void ChangeLanguage()
    {
        if(File.ReadAllLines(configPath)[0] == "eng")
        {
            gameManager.ActualText = gameManager.RussianText;
            File.WriteAllText(configPath, "rus");
        }
        else
        {
            gameManager.ActualText = gameManager.EnglishText;
            File.WriteAllText(configPath, "eng");
        }
        loadUI();
    }
}
