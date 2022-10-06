using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerChange : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    int neg = -1, pos = 2;
    
    void Start()
    {
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
    }

    
    void OnTriggerEnter2D(Collider2D colider)
    {
        if(colider.gameObject.tag == "Player")
        {
            spriteRenderer.sortingOrder = pos;
        }
    }

     void OnTriggerExit2D(Collider2D colider)
    {
        if(colider.gameObject.tag == "Player")
        {
            spriteRenderer.sortingOrder = neg;
        }
    }

    
}
