using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_tv : Action
{
    public override void action()
    {
        GetComponent<Animator>().SetTrigger("play");
    }
}
