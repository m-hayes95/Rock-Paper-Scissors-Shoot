using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTileGenerator : MonoBehaviour
{
    // Ref to prefab tile Array, assigned with inspector.
    [SerializeField] private GameObject[] tilePrefabs;
    // Tile width and height.
    private int tileWidth = 5;
    private int tileHeight = 4;
    // Ref to start position of player and enemy tiles.
    private Vector3 startPositionOfPlayerTiles = new Vector3(0,0,0);
    private Vector3 startPositionOfEnemyTiles = new Vector3(0,0,7);
    // Bool used to check if tile generation is completed
    public bool playerTilesHaveBeenGenerated= false;
    public bool enemyTilesHaveBeenGenerated= false;

    private void Start()
    {
        GenerateStartPlayerTiles();
        GenerateStartEnemyTiles();
    }
    public void GenerateStartPlayerTiles()
    {
        for (int x = 0; x < tileWidth; x++) 
        { for (int z = 0; z < tileHeight; z++) 
            {
                // Assign the current tile location within the loop from the start position, to a new vector.
                Vector3 nextTilePosition = startPositionOfPlayerTiles + new Vector3(x, 0f, z);
                // Assign a random value from the tile prefab Array.
                int randomIndex = Random.Range(0, tilePrefabs.Length);
                // Instantiate the random tile, at current position with no rotation.
                Instantiate(tilePrefabs[randomIndex], nextTilePosition, Quaternion.identity);
            }
            
        }

        playerTilesHaveBeenGenerated = true;
    }

    public void GenerateStartEnemyTiles()
    {
        for (int x = 0; x < tileWidth; x++)
        {
            for (int z = 0; z < tileHeight; z++)
            {
                // Assign the current tile location within the loop from the start position, to a new vector.
                Vector3 nextTilePosition = startPositionOfEnemyTiles + new Vector3(x, 0f, z);
                // Assign a random value from the tile prefab Array.
                int randomIndex = Random.Range(0, tilePrefabs.Length);
                // Instantiate the random tile 
                Instantiate(tilePrefabs[randomIndex], nextTilePosition, Quaternion.identity);
            }

        }

        enemyTilesHaveBeenGenerated = true;
    }
}
