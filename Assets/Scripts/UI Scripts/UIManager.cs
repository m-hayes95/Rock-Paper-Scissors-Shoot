using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Experimental.AI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private PlayerSpawner playerSpawner;
    
    private PlayerController playerController;
    private GameObject player;
    
    private const string PLAYER = "Player";
    private Color transparentBlueColour = new Color(0, 0, 1, 0.5f);

    // Ref to high score text field in canvas.
    [SerializeField]
    private TextMeshProUGUI highScoreCounter;
    // Ref to move player's available move images.
    [SerializeField]
    private Image leftPlayerMoveImage, rightPlayerMoveImage, upPlayerMoveImage;
    
    public Image playerWonRoundImage, playerLostRoundImage, playerDrawRoundImage;

    private void Start()
    {
        playerWonRoundImage.enabled= false;
        playerDrawRoundImage.enabled = false;
        playerLostRoundImage.enabled = false;
    }
    private void Update()
    {
        // Display players current high score.
        highScoreCounter.text = HighScoreManager.Instance.playersHighScore.ToString();

        if (playerSpawner.playerHasSpawned == true)
        {
            player = GameObject.FindGameObjectWithTag(PLAYER);
            playerController = player.GetComponent<PlayerController>();
        }
        else return;

        // Change colour of potenital moves after they have been used to transparent and colour match to ui background.
        if (playerController.playerMoveUpAvailable == false)
        {
            upPlayerMoveImage.color = transparentBlueColour;
        }  // Reset the colour if player move available is true.
        else upPlayerMoveImage.color = Color.white;

        if (playerController.playerMoveUpLeftAvailable == false)
        {
            leftPlayerMoveImage.color = transparentBlueColour;
        } 
        else  leftPlayerMoveImage.color= Color.white;

        if (playerController.playerMoveUpRightAvailable == false)
        {
            rightPlayerMoveImage.color = transparentBlueColour;
        }
        else rightPlayerMoveImage.color = Color.white;

    }

    
}
