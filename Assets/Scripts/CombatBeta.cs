using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatBeta : MonoBehaviour
{
    
    Animator animator;    
    bool inAction = false;
    
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
            if(Input.GetKeyDown(KeyCode.T))
                animator.SetTrigger("attack");

    }

    IEnumerator cooldown()
    {
        inAction = true;
        yield return new WaitForSeconds(0.5f);
        inAction = false;        
    }
}
