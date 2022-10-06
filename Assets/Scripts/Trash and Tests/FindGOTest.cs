using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindGOTest : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(test());
    }
    IEnumerator test()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().playSound("step");
        StartCoroutine(test());
    }
}
