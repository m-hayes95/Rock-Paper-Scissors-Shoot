using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnerController : MonoBehaviour
{
    [SerializeField] private PlayerSpawner playerSpawner;

    private void Awake()
    {
        // Construct input system.
        PlayerInputActions playerInputActions = new PlayerInputActions();
        // Enable the Player action maps within the input system.
        playerInputActions.SpawnPlayer.Enable();
        // Subscribe to the Player choose beginning tile actions in the input system.
        playerInputActions.SpawnPlayer.PlayerStartsOnTile1.performed += PlayerStartOnTile1_Input;
    }

    public void PlayerStartOnTile1_Input(InputAction.CallbackContext context)
    {
        Debug.Log(context); // Check call back context value
        if (context.performed)
        {
            playerSpawner.PlayerChooseStartPosition_Tile1();
            Debug.Log("Call choose first tile function");
        }
    }
}
