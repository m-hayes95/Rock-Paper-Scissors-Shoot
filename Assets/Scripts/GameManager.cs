using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private RandomTileGenerator randomTileGenerator;
    [SerializeField] private Player player;
    public void Update()
    {
        if (randomTileGenerator.playerTilesHaveBeenGenerated == true)
        {

            if (Input.GetKeyDown(KeyCode.Z))
            {
                player.PlayerChooseStartPosition();
            }

        }
    }
    public void GamePlayerWin()
    {
        Debug.Log("Player Wins");
    }
    public void GameEnemyWin()
    {
        Debug.Log("Enemy Wins");
    }
    public void GameDraw()
    {
        Debug.Log("Draw");
    }





}
