using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] bool follow = false;
    GameObject player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void FixedUpdate()
    {
        if(follow) gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, gameObject.transform.position.z); 
    }
}
