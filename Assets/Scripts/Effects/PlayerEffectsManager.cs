using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffectsManager : MonoBehaviour
{
    [SerializeField] GameObject snow_trace;
    public bool create_snow = false;
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void create_trace(Vector3 trace_position)
    {
        Instantiate(snow_trace, trace_position, new Quaternion(0,0,0,0));
    }
    
}
