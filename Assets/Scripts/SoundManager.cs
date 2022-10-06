using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource step;
    [SerializeField] AudioSource menu;
    [SerializeField] AudioSource music;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void playSound(string sound, bool setLoop = false)
    {
        switch(sound)
        {
            case "step":
            step.Play();
            break;
            
            case "menu":
            menu.Play();
            break;

        }
    }

    public void stopSound()
    {
        
    }
}
