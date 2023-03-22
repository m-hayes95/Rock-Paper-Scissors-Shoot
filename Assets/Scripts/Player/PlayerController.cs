using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerUpRayCast playerUpRayCast;
    [SerializeField] private PlayerLeftRayCast playerLeftRayCast;
    [SerializeField] private PlayerRightRayCast playerRightRayCast;
    [SerializeField] private PlayerSpawner playerSpawner;
    

    private void Awake()
    { 
        // Construct input system.
        PlayerInputActions playerInputActions = new PlayerInputActions();
        // Enable the Player action maps within the input system.
        playerInputActions.PlayerMovement.Enable();
        // Subscribe to the Player movement actions in the input system.
        playerInputActions.PlayerMovement.MoveUp.performed += MoveUp_Input;
        playerInputActions.PlayerMovement.MoveUpLeft.performed += MoveUpLeft_Input;
        playerInputActions.PlayerMovement.MoveUpRight.performed += MoveUpRight_Input;
        
    }

    public void MoveUp_Input(InputAction.CallbackContext context)
    {
        Debug.Log(context); // Check call back context value

        if (context.performed) // Check if the up input has been performed.
        {
            // If the input has been performed call the player move up method.
            //Debug.Log("Move PLayer up");
            // Call the Player move up function on the player up ray cast script.
            playerUpRayCast.PlayerMoveUp(); 
        }
    }

    public void MoveUpLeft_Input(InputAction.CallbackContext context)
    {
        if (context.performed) // Move player up to the left.
        {
            playerLeftRayCast.PlayerMoveUpLeft();
        }
    }

    public void MoveUpRight_Input(InputAction.CallbackContext context)
    {
        if (context.performed) // Move player up to the right.
        {
            playerRightRayCast.PlayerMoveUpRight();
        }
    }

    




}
