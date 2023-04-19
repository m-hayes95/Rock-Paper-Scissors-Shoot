using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    public void PlayerOnSpecialTileEffect()
    {
        // Reset the player controller inputs for available moves.
        playerController.playerMoveUpAvailable = true;
        playerController.playerMoveUpLeftAvailable = true;
        playerController.playerMoveUpRightAvailable = true;
        //Debug.Log("Player's available moves have been reset");
        
    }
    
    
    
}
