using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    SoundManager soundManager;
    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>(); 
    }

    public void playSound()
    {
        soundManager.playSound("step");
    }
}
