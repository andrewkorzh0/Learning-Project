using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickButtonsTest : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.JoystickButton0)) print(0);
        if(Input.GetKeyDown(KeyCode.JoystickButton1)) print(1);
        if(Input.GetKeyDown(KeyCode.JoystickButton2)) print(2);
        if(Input.GetKeyDown(KeyCode.JoystickButton3)) print(3);
        if(Input.GetKeyDown(KeyCode.JoystickButton4)) print(4);
        if(Input.GetKeyDown(KeyCode.JoystickButton5)) print(5);
        if(Input.GetKeyDown(KeyCode.JoystickButton6)) print(6);
        if(Input.GetKeyDown(KeyCode.JoystickButton7)) print(7);
        if(Input.GetKeyDown(KeyCode.JoystickButton8)) print(8);
        if(Input.GetKeyDown(KeyCode.JoystickButton9)) print(9);
        if(Input.GetKeyDown(KeyCode.JoystickButton10)) print(10);
        if(Input.GetKeyDown(KeyCode.JoystickButton11)) print(11);
        if(Input.GetKeyDown(KeyCode.JoystickButton12)) print(12);
        if(Input.GetKeyDown(KeyCode.JoystickButton13)) print(13);
        if(Input.GetKeyDown(KeyCode.JoystickButton14)) print(14);
        if(Input.GetKeyDown(KeyCode.JoystickButton15)) print(15);
        if(Input.GetKeyDown(KeyCode.JoystickButton16)) print(16);
        if(Input.GetKeyDown(KeyCode.JoystickButton17)) print(17);
        if(Input.GetKeyDown(KeyCode.JoystickButton18)) print(18);
        if(Input.GetAxisRaw("VerticalStick") != 0) print("vertical stick");
        if(Input.GetAxisRaw("HorizontalStick") != 0) print("horizontal stick");
    }
}
