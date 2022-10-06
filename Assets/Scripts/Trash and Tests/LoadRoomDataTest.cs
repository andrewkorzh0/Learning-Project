using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadRoomDataTest : MonoBehaviour
{
    void Start()
    {
        if(GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>().sessionSave.LOADROOMTEST)
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
    }
}
