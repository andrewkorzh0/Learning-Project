using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class MenuVote : MonoBehaviour
{
    public GameObject MenuCont;
    public GameObject selectableObject;

    void Start()
    {
        MenuCont.SetActive(false);
    }
    void FixedUpdate()
    {
        //EventSystem.current.SetSelectedGameObject(null);
        if (Input.GetKeyDown(KeyCode.M))
        {
            EventSystem.current.SetSelectedGameObject(selectableObject);
            MenuCont.SetActive(!MenuCont.activeInHierarchy);
           
        }
    }

    public void RedButton()
    {
        Debug.Log("RedButton");
    }

    public void GreenButton()
    {
        Debug.Log("GreenButton");
    }

    public void BlueButton()
    {
         Debug.Log("BlueButton");
    }


}
