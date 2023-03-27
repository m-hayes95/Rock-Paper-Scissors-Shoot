using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTileGenerator : MonoBehaviour
{
    // Ref to prefab tile Array, assigned with inspector.
    [SerializeField] private GameObject[] allTilePrefabs;
    [SerializeField] private GameObject[] normalTilePrefabs;
    // Tile width and height for 1st row and 2nd to 4th row.
    private int tileWidth = 5;
    private int tileHeightWithoutSpecial = 1;
    private int tileHeightWithSpecial = 3;
    // Ref to start position of player and enemy tiles for the first row and spawn locations.
    public Vector3 startPositionOfPlayerTiles = new Vector3(0,0,0); // Referenced in Player Spawner Script.
    public Vector3 startPositionOfEnemyTiles = new Vector3(0,0,10); // Referenced in Enemy Spawner Script
    // Ref to initial start point of tile generator, from the 2nd row.
    private Vector3 startPositionOfPlayerTilesFromSecondRow = new Vector3(0,0,1);
    private Vector3 startPositionOfEnemyTilesFromSecondRow = new Vector3(0,0,7);

    // Bool used to check if tile generation is completed
    public bool playerTilesHaveBeenGenerated= false;
    public bool enemyTilesHaveBeenGenerated= false;
    // Check if first row has finished generating before spawning the rest.
    private bool playerFirstRowGenerated = false;
    private bool enemyFirstRowGenerated = false;

    private void Start()
    {
        GenerateStartPlayerTiles();
        GenerateStartEnemyTiles();
    }
    public void GenerateStartPlayerTiles()
    {
        // Generate tiles for the first row.
        for (int x = 0; x < tileWidth; x++) 
        { for (int z = 0; z < tileHeightWithoutSpecial; z++) 
            {
                // Assign the current tile location within the loop from the start position, to a new vector.
                Vector3 nextTilePosition = startPositionOfPlayerTiles + new Vector3(x, 0f, z);
                // Assign a random value from the normal tile prefab Array.
                int randomIndexForNormalTiles = Random.Range(0, normalTilePrefabs.Length);
                // Instantiate the random tile, at current position with no rotation.
                Instantiate(normalTilePrefabs[randomIndexForNormalTiles], nextTilePosition, Quaternion.identity);
                playerFirstRowGenerated = true;

            } 
            
        }
        // Generate tiles from the 2nd row.
        if (playerFirstRowGenerated == true)
        {
            for (int x = 0; x < tileWidth; x++)
            {
                for (int z = 0; z < tileHeightWithSpecial; z++)
                {
                    // Assign the current tile location within the loop from the start position, to a new vector.
                    Vector3 nextTilePosition = startPositionOfPlayerTilesFromSecondRow + new Vector3(x, 0f, z);
                    // Assign a random value from the special tile prefab Array.
                    int randomIndexForAllTiles = Random.Range(0, allTilePrefabs.Length);
                    // Instantiate the random tile (including specials), at current position with no rotation.
                    Instantiate(allTilePrefabs[randomIndexForAllTiles], nextTilePosition, Quaternion.identity);
                }
            }
            playerTilesHaveBeenGenerated = true; // Allow player to spawn.
        } 
    }

    public void GenerateStartEnemyTiles()
    {
        // Generate tiles for the first row.
        for (int x = 0; x < tileWidth; x++)
        {
            for (int z = 0; z < tileHeightWithoutSpecial; z++)
            {
                // Assign the current tile location within the loop from the start position, to a new vector.
                Vector3 nextTilePosition = startPositionOfEnemyTiles + new Vector3(x, 0f, z);
                // Assign a random value from the normal tile prefab Array.
                int randomIndexForNormalTiles = Random.Range(0, normalTilePrefabs.Length);
                // Instantiate the random tile, at current position with opposite rotation.
                Instantiate(normalTilePrefabs[randomIndexForNormalTiles], nextTilePosition, Quaternion.Euler(0, 0, 180f));
                enemyFirstRowGenerated = true;
            }
        }
        
        if (enemyFirstRowGenerated == true)
        {
            // Generate tiles from the 2nd row.
            for (int x = 0; x < tileWidth; x++)
            {
                for (int z = 0; z < tileHeightWithSpecial; z++)
                {
                    // Assign the current tile location within the loop from the start position, to a new vector.
                    Vector3 nextTilePosition = startPositionOfEnemyTilesFromSecondRow + new Vector3(x, 0f, z);
                    // Assign a random value from the special tile prefab Array.
                    int randomIndexForAllTiles = Random.Range(0, allTilePrefabs.Length);
                    // Instantiate the random tile (including specials), at current position with opposite rotation.
                    Instantiate(allTilePrefabs[randomIndexForAllTiles], nextTilePosition, Quaternion.Euler(0, 0, 180f));
                }
            }
            enemyTilesHaveBeenGenerated = true; // Allow enemy to spawn.
        }
        
        
    }
}
