using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveSaveBetweenScenes : MonoBehaviour
{
    public SaveData saveData;
    public int enterWay;
    
    void Awake()
    {
        //StartCoroutine(die());
    }

    IEnumerator die()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
