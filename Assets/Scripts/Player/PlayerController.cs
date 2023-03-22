using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{ 
    private void Awake()
    { 
        // Construct input system.
        PlayerInputActions playerInputActions = new PlayerInputActions();
        // Enable the Player action maps within the input system.
        playerInputActions.Player.Enable();
        // Subscribe to the MoveUp action in the input system.
        playerInputActions.Player.MoveUp.performed += MoveUp;
    }

    public void MoveUp(InputAction.CallbackContext context)
    {
        Debug.Log(context); // Check call back context value

        if (context.performed) // Check if the input has been performed.
        {
            // If the input has been performed call the player move up method.
            Debug.Log("Move PLayer up");
        }
    }
    


}
