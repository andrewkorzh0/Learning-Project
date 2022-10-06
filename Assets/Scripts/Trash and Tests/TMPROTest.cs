using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMPROTest : MonoBehaviour
{
    TMPro.TMP_Text tmp;
    void Start()
    {
        tmp = GetComponent<TMPro.TMP_Text>();
        tmp.text = "ge";
    }
}
