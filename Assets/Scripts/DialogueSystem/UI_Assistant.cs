/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Assistant : MonoBehaviour {
    [SerializeField] private TextWriter textWriter;
    private Text messageText;

    private void Awake() 
    {
        messageText = transform.Find("message").Find("messageText").GetComponent<Text>();
    }
    private void Start()
    {
        textWriter.AddWriter(messageText,"Hello",1f);
    }


        
    

   
}
