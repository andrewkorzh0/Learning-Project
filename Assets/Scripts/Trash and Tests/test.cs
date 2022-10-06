using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    
    void Start()
    {
        GetComponent<TMPro.TMP_Text>().text = Application.persistentDataPath + @"\Saves";       
    }
}
