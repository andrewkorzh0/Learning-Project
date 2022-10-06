using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter:MonoBehaviour{

    private Text uiText;
    private string textToWrite;
    private float timeperCharacter;
    private int characterIndex;
    private float timer;
    public void AddWriter(Text uiText,string textToWrite,float timeperCharacter)
    {
        this.uiText = uiText;
        this.textToWrite = textToWrite;
        this.timeperCharacter = timeperCharacter;
        characterIndex = 0;
    }

    private void Update()
    {
        if(uiText != null)
        {
            timer = Time.deltaTime;

            if(timer <= 0f)
            {
                timer += timeperCharacter;
                characterIndex++;
                uiText.text = textToWrite.Substring(0,characterIndex);
            }
        }
    }
}