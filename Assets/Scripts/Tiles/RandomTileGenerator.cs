using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using static TilePrefabPooler;

public class RandomTileGenerator : MonoBehaviour
{
    // Ref to prefab tile Array, assigned with inspector.
    [SerializeField] private GameObject[] allTilePrefabs;
    [SerializeField] private GameObject[] normalTilePrefabs;
    [SerializeField] private GameObject specialTilePrefab;

    
    // Tile width and height for 1st row and 2nd to 4th row.
    private int tileWidth = 5;
    private int tileHeightWithoutSpecial = 1;
    private int tileHeightWithSpecial = 3;
    // Ref to start position of player and enemy tiles for the first row and spawn locations.
    public Vector3 startPositionOfPlayerTiles;
    public Vector3 startPositionOfEnemyTiles;
    // Ref to initial start point of tile generator, from the 2nd row.
    private Vector3 startPositionOfPlayerTilesFromSecondRow = new Vector3(0,0,1);
    private Vector3 startPositionOfEnemyTilesFromSecondRow = new Vector3(0,0,6);

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
        startPositionOfPlayerTiles = new Vector3(0, 0, 0); // Referenced in Player Spawner Script.
        startPositionOfEnemyTiles = new Vector3(0, 0, 9); // Referenced in Enemy Spawner Script
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
                    float randomValue = Random.Range(1, 5);
                    bool allowSpecialTilesSpawn = false;
                    if (randomValue == 3)
                    {
                        allowSpecialTilesSpawn = true;
                    } else allowSpecialTilesSpawn = false;

                    // Assign the current tile location within the loop from the start position, to a new vector.
                    Vector3 nextTilePosition = startPositionOfPlayerTilesFromSecondRow + new Vector3(x, 0f, z);
                    // Assign a random value from the special tile prefab Array.
                    int randomIndexForAllTiles = Random.Range(0, allTilePrefabs.Length);
                    // Assign a random value from the normal tile prefab Array.
                    int randomIndexForNormalTiles = Random.Range(0, normalTilePrefabs.Length);

                    while (!allowSpecialTilesSpawn)
                    {
                        // Instantiate random tile excluding special tiles.
                        Instantiate(normalTilePrefabs[randomIndexForNormalTiles], nextTilePosition, Quaternion.identity);
                        
                        
                        break;
                    }
                    while (allowSpecialTilesSpawn == true)
                    {
                        // Instantiate the random tile (including specials), at current position with no rotation.
                        Instantiate(allTilePrefabs[randomIndexForAllTiles], nextTilePosition, Quaternion.identity);
                        break;
                    }
                    
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
                    float randomValue = Random.Range(1, 5);
                    bool allowSpecialTilesSpawn = false;
                    if (randomValue == 3)
                    {
                        allowSpecialTilesSpawn = true;
                    }
                    else allowSpecialTilesSpawn = false;

                    // Assign the current tile location within the loop from the start position, to a new vector.
                    Vector3 nextTilePosition = startPositionOfEnemyTilesFromSecondRow + new Vector3(x, 0f, z);
                    // Assign a random value from the special tile prefab Array.
                    int randomIndexForAllTiles = Random.Range(0, allTilePrefabs.Length);
                    int randomIndexForNormalTiles = Random.Range(0, normalTilePrefabs.Length);

                    while (!allowSpecialTilesSpawn)
                    {
                        // Instantiate random tile excluding special tiles.
                        Instantiate(normalTilePrefabs[randomIndexForNormalTiles], nextTilePosition, Quaternion.Euler(0, 0, 180f));


                        break;
                    }
                    while (allowSpecialTilesSpawn == true)
                    {
                        // Instantiate the random tile (including specials), at current position with no rotation.
                        Instantiate(allTilePrefabs[randomIndexForAllTiles], nextTilePosition, Quaternion.Euler(0, 0, 180f));
                        break;
                    }

                }
            }
            enemyTilesHaveBeenGenerated = true; // Allow enemy to spawn.
        }
        
        
    }

    /*
     [System.Serializable]
    public class TilePrefabs
    {
        public string tag; // Name of pool.
        public GameObject tilePrefab; // Which Prefab is stored in this pool.
        public int amount; // How many prefabs are stored in this pool.
    }

    public List<TilePrefabs> tilePrefabsList; // List of each Tile Prefab Pool created.
     * 
     while (x == 2 && z == 2)
                    {
                        // If not special tiles exist at last tile spawn location then spawn special tile.
                        Instantiate(specialTilePrefab, nextTilePosition + new Vector3(0, 2f, 0), Quaternion.identity);
                        break;
                    }
     * 
     Vector3 nextTilePosition = startPositionOfEnemyTilesFromSecondRow + new Vector3(x, 0f, z);
                    foreach (TilePrefabs _tilePrefabs in tilePrefabsList)
                    {
                        for (int i = 0; i < _tilePrefabs.amount; i++)
                        {
                            Instantiate(_tilePrefabs.tilePrefab, nextTilePosition, Quaternion.identity);
                            
                        }
                    }
     */
}
