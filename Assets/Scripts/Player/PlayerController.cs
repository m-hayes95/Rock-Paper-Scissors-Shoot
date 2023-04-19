using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Ref CodeMonkey "How to use NEW Input System Package! (Unity Tutorial - Keyboard, Mouse, Touch, Gamepad)"
// https://www.youtube.com/watch?v=Yjee_e4fICc&t=1044s

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerUpRayCast playerUpRayCast;
    [SerializeField] private PlayerLeftRayCast playerLeftRayCast;
    [SerializeField] private PlayerRightRayCast playerRightRayCast;
    [SerializeField] private PlayerSpawner playerSpawner;

    // Allow player to use a direction only once.
    public bool playerMoveUpAvailable = true;
    public bool playerMoveUpLeftAvailable = true;
    public bool playerMoveUpRightAvailable = true;

    public float cameraShakeIntesity = 3f;
    private float cameraShakeTimer = .1f;

    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        // Construct input system.
        playerInputActions = new PlayerInputActions();
        // Enable the Player action maps within the input system.
        //playerInputActions.PlayerMovement.Enable();

        // Subscribe to the Player movement actions in the input system.
        playerInputActions.PlayerMovement.MoveUp.performed += MoveUp_Input;
        playerInputActions.PlayerMovement.MoveUpLeft.performed += MoveUpLeft_Input;
        playerInputActions.PlayerMovement.MoveUpRight.performed += MoveUpRight_Input;
    }

    public void MoveUp_Input(InputAction.CallbackContext context)
    {
        //Debug.Log(context); // Check call back context value

        // Check if the up input has been performed & player can acess the raycast to move.
        // Check timer has reset, allowing player to move.
        if (context.performed && playerUpRayCast != null &&
                playerMoveUpAvailable == true && PauseMenu.GameIsPaused == false) 
        {
            if (CameraShake.IsCameraShakeEnabled == true)
            {
                CameraShake.Instance.ShakeCamera(cameraShakeIntesity, cameraShakeTimer);
            }
            GameplayMusic.Insatance.PlayPlayerMoveSound(); // Play move sound.
            // If the input has been performed call the player move up method.
            //Debug.Log("Input PLayer Up");
            // Call the Player move up function on the player up ray cast script.
            playerUpRayCast.PlayerMoveUp();
            // If player has used their move up move, dont allow to use the same move again.
            playerMoveUpAvailable = false;
        }
    }

    public void MoveUpLeft_Input(InputAction.CallbackContext context)
    {
        if (context.performed && playerLeftRayCast != null &&
            playerMoveUpLeftAvailable == true && PauseMenu.GameIsPaused == false) // Move player up to the left.
        {
            if (CameraShake.IsCameraShakeEnabled == true)
            {
                CameraShake.Instance.ShakeCamera(cameraShakeIntesity, cameraShakeTimer);
            }
            GameplayMusic.Insatance.PlayPlayerMoveSound();
            //Debug.Log("Input Move PLayer Left");
            playerLeftRayCast.PlayerMoveUpLeft();
            playerMoveUpLeftAvailable=false;
        }
    }

    public void MoveUpRight_Input(InputAction.CallbackContext context)
    {
        if (context.performed && playerRightRayCast != null &&
            playerMoveUpRightAvailable == true && PauseMenu.GameIsPaused == false) // Move player up to the right.
        {
            GameplayMusic.Insatance.PlayPlayerMoveSound();
            if (CameraShake.IsCameraShakeEnabled == true)
            {
                CameraShake.Instance.ShakeCamera(cameraShakeIntesity, cameraShakeTimer);
            }
                
            //Debug.Log("Input Move PLayer Right");
            playerRightRayCast.PlayerMoveUpRight();
            playerMoveUpRightAvailable=false;
        }
    }

    private void OnEnable()
    {
        playerInputActions.PlayerMovement.Enable();
    }
    private void OnDisable()
    {
        playerInputActions.PlayerMovement.Disable();
    }
}
