using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnerController : MonoBehaviour
{
    [SerializeField] private PlayerSpawner playerSpawner; // Ref to player spawner methods.

    private bool playerHasChoosen = false; // Check if player has choosen start tile.

    private void Awake()
    {
        // Construct input system.
        PlayerInputActions playerInputActions = new PlayerInputActions();
        // Enable the Player action maps within the input system.
        playerInputActions.SpawnPlayer.Enable();
        // Subscribe to the Player choose beginning tile actions in the input system.
        playerInputActions.SpawnPlayer.PlayerStartsOnTile1.performed += PlayerStartOnTile1_Input;
        playerInputActions.SpawnPlayer.PlayerStartsOnTile2.performed += PlayerStartOnTile2_Input;
        playerInputActions.SpawnPlayer.PlayerStartsOnTile3.performed += PlayerStartOnTile3_Input;
        playerInputActions.SpawnPlayer.PlayerStartsOnTile4.performed += PlayerStartOnTile4_Input;
        playerInputActions.SpawnPlayer.PlayerStartsOnTile5.performed += PlayerStartOnTile5_Input;
    }

    public void PlayerStartOnTile1_Input(InputAction.CallbackContext context)
    {
        //Debug.Log(context); // Check call back context value.
        if (context.performed) // If intput is performed...
        {
            if (!playerHasChoosen) // Don't allow 2 players to be spawned at once.
            {
                // Call player choose tile in the Player Spawner script.
                playerSpawner.PlayerChooseStartPosition_Tile1();
                //Debug.Log("Call choose first tile function");
                playerHasChoosen = true;
            }
        }
    }
    public void PlayerStartOnTile2_Input(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!playerHasChoosen)
            {
                playerSpawner.PlayerChooseStartPosition_Tile2();
                playerHasChoosen = true;
            }
        }
    }
    public void PlayerStartOnTile3_Input(InputAction.CallbackContext context)
    {
        if (!playerHasChoosen)
        {
            playerSpawner.PlayerChooseStartPosition_Tile3();
            playerHasChoosen = true;
        }
    }
    public void PlayerStartOnTile4_Input(InputAction.CallbackContext context)
    {
        if (!playerHasChoosen)
        {
            playerSpawner.PlayerChooseStartPosition_Tile4();
            playerHasChoosen = true;
        }
    }
    public void PlayerStartOnTile5_Input(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!playerHasChoosen)
            {
                playerSpawner.PlayerChooseStartPosition_Tile5();
                playerHasChoosen = true;
            }
        }
    }
}