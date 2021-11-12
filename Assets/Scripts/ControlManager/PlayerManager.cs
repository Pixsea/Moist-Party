using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public Color playerColor;
    public Vector2 leftStick;
    public void PlayerFire(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Started)
            return;
        //print(context.phase);
        
        
        print($"Player fired");
    }

    public void PlayerMove(InputAction.CallbackContext context)
    {
        string scene = SceneManager.GetActiveScene().name;
        leftStick = context.ReadValue<Vector2>();
        //Equivalent of "GetKeyDown" 
        //And only if in main menu
        if (context.phase == InputActionPhase.Started && scene == "MainMenu")
        {
            //The value is generally low, but gets the sign
            int sign = (int)Mathf.Sign(leftStick.y);
            
            MainMenu.instance.MoveSelected(sign);
        }
        
    }

    public void A_Pressed(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Started)
            return;
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            MainMenu.instance.PressSelected();
        }
    }
}
