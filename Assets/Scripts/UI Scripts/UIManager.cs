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
    [SerializeField]
    private GameObject choosingStartingTileGroup;
    
    private const string PLAYER = "Player";
    private Color transparentBlueColour = new Color(0, 0, 1, 0.5f);

    [SerializeField]
    private TextMeshProUGUI highScoreCounter;
    
    [SerializeField]
    private Image leftPlayerMoveImage, rightPlayerMoveImage, upPlayerMoveImage;
 
    public GameObject playerWonRoundImage, playerLostRoundImage, playerDrawRoundImage;

    public bool gameWon, gameDraw, gameLost;

    private void Start()
    {
        gameWon = false;
        gameDraw = false;
        gameLost = false;
    }
    private void Update()
    {
        Debug.Log("Game won " + gameWon);
        Debug.Log("Game draw " + gameDraw);
        Debug.Log("Game lost " + gameLost);

        ShowRoundOverBanner();
        // Display players current high score.
        highScoreCounter.text = HighScoreManager.Instance.playersHighScore.ToString();

        if (playerSpawner.playerHasSpawned == true)
        {
            player = GameObject.FindGameObjectWithTag(PLAYER);
            playerController = player.GetComponent<PlayerController>();
            choosingStartingTileGroup.SetActive(false);
        }
        else return;

        // Change colour of potenital moves after they have been used to transparent and colour match to ui background.
        if (playerController.playerMoveUpAvailable == false)
        {
            upPlayerMoveImage.color = transparentBlueColour;
        }  // Reset the colour if the move becomes available again.
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
    private void ShowRoundOverBanner()
    {
        // Display game win, draw, loss banner on round over. Set in game manager script.
        if (gameWon == true)
        {
            playerWonRoundImage.SetActive(true);
            //Debug.Log(gameWon);
        } else
        {
            playerWonRoundImage.SetActive(false);
        }

        if (gameDraw == true)
        {
            playerDrawRoundImage.SetActive(true);
            //Debug.Log(gameDraw);
        } else
        {
            playerDrawRoundImage.SetActive(false);
        }

        if (gameLost == true)
        {
            playerLostRoundImage.SetActive(true);
            //Debug.Log(gameLost);
        } else
        {
            playerLostRoundImage.SetActive(false);
        }


    }
    
}
