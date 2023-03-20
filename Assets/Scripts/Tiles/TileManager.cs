using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    // Ref for Phase Manager script
    [SerializeField] PhaseManager phaseManager;
    // Set bool to true if player or enemy is on the corresponding tile
    public bool playerRock = false, playerPaper = false, playerScissors = false, playerSpecial = false;
    public bool enemyRock = false, enemyPaper = false, enemyScissors = false, enemySpecial = false;

    // Store the last enemy tile if the current player tile is a special tile
    //public bool lastPlayerTileIsRock = false, lastPlayerTileIsPaper = false, lastPlayerTileIsScissors = false;
    //public bool lastEnemyTileIsRock = false, lastEnemyTileIsPaper = false, lastEnemyTileIsScissors = false;

    // Ref to current players current tile using string field
    private string lastPlayerTileOnSpecial, lastEnemyTileOnSpecial;
    private const string ROCK = "Rock", PAPER = "Paper", SCISSORS = "Scissors";

    public void PlayerOnRockTile()
    {
        //set player on rock tile bool to true
        playerRock = true;
        //set others to false
        playerPaper = false;
        playerScissors = false;
        playerSpecial = false;
        // set the last player tile for when we hit a special tile
        lastPlayerTileOnSpecial = ROCK;
    }

    public void PlayerOnPaperTile()
    {
        //set player on rock tile bool to true
        playerPaper = true;
        //set others to false
        playerRock = false;
        playerScissors = false;
        playerSpecial = false;

        lastPlayerTileOnSpecial = PAPER;
    }

    public void PlayerOnScissorsTile()
    {
        //set player on rock tile bool to true
        playerScissors = true;
        //set others to false
        playerRock = false;
        playerPaper = false;
        playerSpecial =false;

        lastPlayerTileOnSpecial = SCISSORS;
    }

    public void PlayerOnSpecialTile()
    {
        //set player on rock tile bool to true
        playerSpecial = true;
        //set others to false
        playerRock = false;
        playerPaper = false;
        playerScissors = false;
        //if player lands on a special tile, set the players tile as their previous tile.
        if (lastPlayerTileOnSpecial == ROCK)
        {
            playerRock = true;
        } else if (lastPlayerTileOnSpecial == PAPER)
        {
            playerPaper = true;
        } else if (lastPlayerTileOnSpecial == SCISSORS)
        {
            playerScissors = true;
        }
    }

    public void EnemyOnRockTile()
    {
        enemyRock = true;
        // set others to false
        enemyPaper= false;
        enemyScissors = false;  
        enemySpecial = false;

        lastEnemyTileOnSpecial = ROCK;
    }
    public void EnemyOnPaperTile()
    {
        enemyPaper = true;
        // set others to false
        enemyRock= false;
        enemyScissors = false;
        enemySpecial = false;

        lastEnemyTileOnSpecial = PAPER;
    }
    public void EnemyOnScissorsTile() 
    { 
        enemyScissors = true;
        // set others to false
        enemyRock= false;
        enemyPaper= false;
        enemySpecial = false;

        lastEnemyTileOnSpecial = SCISSORS;
    }
    public void EnemyOnSpecialTile()
    {
        enemySpecial = true;
        // set others to false
        enemyRock= false;
        enemyPaper= false;
        enemyScissors = false;
        //if enemy lands on a special tile, set the enemys tile as their previous tile.
        if (lastEnemyTileOnSpecial == ROCK)
        {
            enemyRock = true;
        }
        else if (lastEnemyTileOnSpecial == PAPER)
        {
            enemyPaper = true;
        }
        else if (lastEnemyTileOnSpecial == SCISSORS)
        {
            enemyScissors = true;
        }
    }

    
}
