using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    public bool playerRock = false, playerPaper = false, playerScissors = false, playerSpecial = false;
    public bool enemyRock = false, enemyPaper = false, enemyScissors = false, enemySpecial = false;
    // Store the last enemy tile if the current player tile is a special tile
    public bool lastPlayerTileIsRock = false, lastPlayerTileIsPaper = false, lastPlayerTileIsScissors = false;
    public bool lastEnemyTileIsRock = false, lastEnemyTileIsPaper = false, lastEnemyTileIsScissors = false;
    private string lastPlayerTile, lastEnemyTile;
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
        lastPlayerTile = ROCK;
    }

    public void PlayerOnPaperTile()
    {
        //set player on rock tile bool to true
        playerPaper = true;
        //set others to false
        playerRock = false;
        playerScissors = false;
        playerSpecial = false;

        lastPlayerTile = PAPER;
    }

    public void PlayerOnScissorsTile()
    {
        //set player on rock tile bool to true
        playerScissors = true;
        //set others to false
        playerRock = false;
        playerPaper = false;
        playerSpecial =false;

        lastPlayerTile = SCISSORS;
    }

    public void PlayerOnSpecialTile()
    {
        //set player on rock tile bool to true
        playerSpecial = true;
        //set others to false
        playerRock = false;
        playerPaper = false;
        playerScissors = false;
        // set the last tile bool to its corrosponding last time string
        if (lastPlayerTile == ROCK)
        {
            lastPlayerTileIsRock = true;
        } else if (lastPlayerTile == PAPER)
        {
            lastPlayerTileIsPaper = true;
        }
        else if (lastPlayerTile == SCISSORS)
        {
            lastPlayerTileIsScissors = true;
        }
    }

    public void EnemyOnRockTile()
    {
        enemyRock = true;
        // set others to false
        enemyPaper= false;
        enemyScissors = false;  
        enemySpecial = false;

        lastEnemyTile = ROCK;
    }
    public void EnemyOnPaperTile()
    {
        enemyPaper = true;
        // set others to false
        enemyRock= false;
        enemyScissors = false;
        enemySpecial = false;

        lastEnemyTile = PAPER;
    }
    public void EnemyOnScissorsTile() 
    { 
        enemyScissors = true;
        // set others to false
        enemyRock= false;
        enemyPaper= false;
        enemySpecial = false;

        lastEnemyTile = SCISSORS;
    }
    public void EnemyOnSpecialTile()
    {
        enemySpecial = true;
        // set others to false
        enemyRock= false;
        enemyPaper= false;
        enemyScissors = false;

        if (lastEnemyTile == ROCK)
        {
            lastEnemyTileIsRock = true;
        }
        else if (lastEnemyTile == PAPER)
        {
            lastEnemyTileIsPaper |= true;
        }
        else if (lastEnemyTile == SCISSORS)
        {
            lastEnemyTileIsScissors = true;
        }
    }

    
}
