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

    // Allow player to use a direction only once.
    public bool playerMoveUpAvailable = true;
    public bool playerMoveUpLeftAvailable = true;
    public bool playerMoveUpRightAvailable = true;
    // Timer that sets next move delayed to false.
    private bool playersNextMoveDelayed = false;
    private float timer = 0f;
    private float nextMoveDelay = 0.5f;

    public float cameraShakeIntesity = 3f;
    private float cameraShakeTimer = .1f;

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

    private void Update()
    {
        // Add a delay to stop player spamming moves, allowing timer for enemys move to happen.
        if (playersNextMoveDelayed == true)
        {
            if (timer >= nextMoveDelay)
            {
                playersNextMoveDelayed = false;
            }
            else timer += Time.deltaTime;
        } 
    }

    public void MoveUp_Input(InputAction.CallbackContext context)
    {
        //Debug.Log(context); // Check call back context value

        // Check if the up input has been performed & player can acess the raycast to move.
        // Check timer has reset, allowing player to move.
        if (context.performed && playerUpRayCast != null &&
            playerMoveUpAvailable == true && playersNextMoveDelayed == false) 
        {
            if (CameraShake.Instance.isCameraShakeEnabled == true)
            {
                CameraShake.Instance.ShakeCamera(cameraShakeIntesity, cameraShakeTimer);
            }
            
            // If the input has been performed call the player move up method.
            //Debug.Log("Input PLayer Up");
            // Call the Player move up function on the player up ray cast script.
            playerUpRayCast.PlayerMoveUp();
            // If player has used their move up move, dont allow to use the same move again.
            playerMoveUpAvailable = false;
            // Set the delay next move to true.
            playersNextMoveDelayed = true;
        }
    }

    public void MoveUpLeft_Input(InputAction.CallbackContext context)
    {
        if (context.performed && playerLeftRayCast != null &&
            playerMoveUpLeftAvailable == true && playersNextMoveDelayed == false) // Move player up to the left.
        {
            if (CameraShake.Instance.isCameraShakeEnabled == true)
            {
                CameraShake.Instance.ShakeCamera(cameraShakeIntesity, cameraShakeTimer);
            }
                
            //Debug.Log("Input Move PLayer Left");
            playerLeftRayCast.PlayerMoveUpLeft();
            playerMoveUpLeftAvailable=false;
            playersNextMoveDelayed = true;
        }
    }

    public void MoveUpRight_Input(InputAction.CallbackContext context)
    {
        if (context.performed && playerRightRayCast != null &&
            playerMoveUpRightAvailable == true && playersNextMoveDelayed == false) // Move player up to the right.
        {
            if (CameraShake.Instance.isCameraShakeEnabled == true)
            {
                CameraShake.Instance.ShakeCamera(cameraShakeIntesity, cameraShakeTimer);
            }
                
            //Debug.Log("Input Move PLayer Right");
            playerRightRayCast.PlayerMoveUpRight();
            playerMoveUpRightAvailable=false;
            playersNextMoveDelayed = true;
        }
    }

    




}
