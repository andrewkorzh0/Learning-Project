using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadsaveoutput : MonoBehaviour
{
    [SerializeField] Text text;

    public void lOaD_OoooHHHH_yEs()
    {
        text.text = "";
        GameManager gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gm.LoadGame();
    }
}
