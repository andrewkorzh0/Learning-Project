using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageChangerOld : MonoBehaviour
{
    GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }


    public void ChangeLanguage()
    {
        //test
        //testeeee
        if(gameManager.actualLanguage == "eng")
        {
            gameManager.ActualText = gameManager.RussianText;
            gameManager.actualLanguage = "rus";
        }
        else if(gameManager.actualLanguage == "rus")
        {
            gameManager.ActualText = gameManager.EnglishText;
            gameManager.actualLanguage = "eng";
        }
    }
}
