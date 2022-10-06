using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BetweenScenesStartMethodTest : MonoBehaviour
{
    void Start()
    {
        print("THAT WORKS LOL");
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode lsm)
    {
        print("THAT WORKS LOL");
    }

}
