using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    public bool playerRock = false, playerPaper = false, playerScissors = false, playerSpecial = false;
    public bool enemyRock = false, enemyPaper = false, enemyScissors = false, enemySpecial = false;

    public void PlayerOnRockTile()
    {
        //set player on rock tile bool to true
        playerRock = true;
        //set others to false
        playerPaper = false;
        playerScissors = false;
        playerSpecial = false;
    }

    public void PlayerOnPaperTile()
    {
        //set player on rock tile bool to true
        playerPaper = true;
        //set others to false
        playerRock = false;
        playerScissors = false;
        playerSpecial = false;
    }

    public void PlayerOnScissorsTile()
    {
        //set player on rock tile bool to true
        playerScissors = true;
        //set others to false
        playerRock = false;
        playerPaper = false;
        playerSpecial =false;
    }

    public void PlayerOnSpecialTile()
    {
        //set player on rock tile bool to true
        playerSpecial = true;
        //set others to false
        playerRock = false;
        playerPaper = false;
        playerScissors = false;
    }

    public void EnemyOnRockTile()
    {
        enemyRock = true;
        // set others to false
        enemyPaper= false;
        enemyScissors = false;  
        enemySpecial = false;
    }
    public void EnemyOnPaperTile()
    {
        enemyPaper = true;
        // set others to false
        enemyRock= false;
        enemyScissors = false;
        enemySpecial = false;
    }
    public void EnemyOnScissorsTile() 
    { 
        enemyScissors = true;
        // set others to false
        enemyRock= false;
        enemyPaper= false;
        enemySpecial = false;
    }
    public void EnemyOnSpecialTile()
    {
        enemySpecial = true;
        // set others to false
        enemyRock= false;
        enemyPaper= false;
        enemyScissors = false;
    }

    
}
