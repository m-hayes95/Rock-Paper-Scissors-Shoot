using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        // Construct the new player input action controller
        PlayerInputActions playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    public Vector3 PlayerMoveUpInput()
    {
        Vector3 movePlayerUp = playerInputActions.Player.MoveUp.ReadValue<Vector3>();
        return movePlayerUp;
    }
    


}
