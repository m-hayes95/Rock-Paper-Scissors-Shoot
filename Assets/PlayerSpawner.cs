using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private RandomTileGenerator randomTileGenerator;

   
    public void PlayerChooseStartPosition_Tile1()
    {
        if (randomTileGenerator.playerTilesHaveBeenGenerated == true)
        {
            Vector3 firstTile = new Vector3(0, 1.5f, 0);
            Debug.Log(firstTile);
            Instantiate(player, firstTile, Quaternion.identity);
            Debug.Log("Player Selected 1st Tile");
        }

    }

    
}
