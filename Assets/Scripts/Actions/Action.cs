using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour
{

    public virtual void action(){}
    public virtual void OnTriggerEnter2D(Collider2D collider2D) {} // action(); обычно

}