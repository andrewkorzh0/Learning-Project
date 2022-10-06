using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPosChanger : MonoBehaviour
{
    [SerializeField] bool work = true;
    [SerializeField] float pixel_size = 0.5f;
    GameObject[] environment;
    void Start()
    {
        if(work)
        {
            environment = GameObject.FindGameObjectsWithTag("Environment");
            foreach(GameObject i in environment)
            {
                //doesn't working ;()
                i.transform.SetPositionAndRotation(new Vector3((i.transform.position.x - (i.transform.position.x % pixel_size)) + pixel_size, (i.transform.position.y - (i.transform.position.y % pixel_size)) + pixel_size, 0), new Quaternion(0,0,0,0));
            }
        }
    }
}
