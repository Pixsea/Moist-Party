using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class ControllerTest : MonoBehaviour
{
    public Vector2 leftStick;
    public void PlayerJoined(PlayerInput input)
    {
        print("Player joined!");
    }

    public void PlayerFire(InputAction.CallbackContext context)
    {
        
        if ((context.interaction is TapInteraction) == false)
            return;
        print($"Player fired at {Time.time}");
    }

    public void PlayerMove(InputAction.CallbackContext context)
    {
        leftStick = context.ReadValue<Vector2>();
    }
}
