using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tests : MonoBehaviour
{
    [SerializeField] bool FIXED_FPS = true;
    [SerializeField] bool SHOW_FPS = true;
    [SerializeField] Text FPS_TEXT;
    
    //using
    float deltaTime = 0;
    
    void Start() 
    {
        if(FIXED_FPS == true)
            Application.targetFrameRate = 30;
    }

    void Update() 
    {
        if(SHOW_FPS)
        {
            deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
            float fps = 1.0f / deltaTime;
            FPS_TEXT.text = Mathf.Ceil(fps).ToString();
        }    
    } 

}
