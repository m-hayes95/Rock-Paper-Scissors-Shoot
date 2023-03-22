using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject player; // Ref to spawn player prefab.
    [SerializeField] private RandomTileGenerator randomTileGenerator; // Ref to heirachy tile spawner.

    private float playerHeight = 1.5f; // Height offset for choosen spawn locations.


    public void PlayerChooseStartPosition_Tile1()
    {
        // Check if tiles have finished generating.
        if (randomTileGenerator.playerTilesHaveBeenGenerated == true)
        {
            // Define a start position using the first tile location from the Random Tile Generator script, 
            // then add a vector offset for the players height.
            Vector3 firstTile = randomTileGenerator.startPositionOfPlayerTiles + new Vector3(0, playerHeight, 0);
            Debug.Log(firstTile);
            Instantiate(player, firstTile, Quaternion.identity); // Spawn player on first position with no rotation.
        }

    }

    public void PlayerChooseStartPosition_Tile2()
    {
        if (randomTileGenerator.playerTilesHaveBeenGenerated == true)
        {
            float secondTileOffset = 1f;
            Vector3 secondTile = randomTileGenerator.startPositionOfPlayerTiles + new Vector3(secondTileOffset, playerHeight, 0);
            Debug.Log(secondTile);
            Instantiate(player, secondTile, Quaternion.identity);
        }
    }

    public void PlayerChooseStartPosition_Tile3()
    {
        if (randomTileGenerator.playerTilesHaveBeenGenerated == true)
        {
            float thirdTileOffset = 2f;
            Vector3 thirdTile = randomTileGenerator.startPositionOfPlayerTiles + new Vector3(thirdTileOffset, playerHeight, 0);
            Debug.Log(thirdTile);
            Instantiate(player, thirdTile, Quaternion.identity);
        }
    }

    public void PlayerChooseStartPosition_Tile4()
    {
        if (randomTileGenerator.playerTilesHaveBeenGenerated == true)
        {
            float forthTileOffset = 3f;
            Vector3 forthTile = randomTileGenerator.startPositionOfPlayerTiles + new Vector3(forthTileOffset, playerHeight, 0);
            Debug.Log(forthTile);
            Instantiate(player, forthTile, Quaternion.identity);
        }
    }

    public void PlayerChooseStartPosition_Tile5()
    {
        if (randomTileGenerator.playerTilesHaveBeenGenerated == true)
        {
            float fithTileOffset = 4f;
            Vector3 fithTile = randomTileGenerator.startPositionOfPlayerTiles + new Vector3(fithTileOffset, playerHeight, 0);
            Debug.Log(fithTile);
            Instantiate(player, fithTile, Quaternion.identity);
        }
    }
}
