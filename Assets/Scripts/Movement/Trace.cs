using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trace : MonoBehaviour
{
    void Awake()
    {
        StartCoroutine(trace_life());
    }

    IEnumerator trace_life()
    {
        yield return new WaitForSeconds(3.5f);
        //можно добавить сюда анимацию затухания через некоторое время
        Destroy(gameObject);
    }
}
