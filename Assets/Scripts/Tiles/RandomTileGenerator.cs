using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using static TilePrefabPooler;

public class RandomTileGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] allTilePrefabs;
    [SerializeField] private GameObject[] normalTilePrefabs;
    [SerializeField] private GameObject specialTilePrefab;

    
    // Tile width and height for 1st row and 2nd to 4th row.
    private int tileWidth = 5;
    private int tileHeightWithoutSpecial = 1;
    private int tileHeightWithSpecial = 3;
    
    public Vector3 startPositionOfPlayerTiles;
    public Vector3 startPositionOfEnemyTiles;
    // Ref to initial start point of tile generator, from the 2nd row.
    private Vector3 startPositionOfPlayerTilesFromSecondRow = new Vector3(0,0,1);
    private Vector3 startPositionOfEnemyTilesFromSecondRow = new Vector3(0,0,6);

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
                    // Random generator for a chance to spawn special tile
                    float randomValue = Random.Range(1, 11);
                    bool allowSpecialTilesSpawn = false;
                    if (randomValue == 3)
                    {
                        allowSpecialTilesSpawn = true;
                    } else allowSpecialTilesSpawn = false;

                    Vector3 nextTilePosition = startPositionOfPlayerTilesFromSecondRow + new Vector3(x, 0f, z);
                    // Create random indexes for both prefab arrays.
                    int randomIndexForAllTiles = Random.Range(0, allTilePrefabs.Length);
                    int randomIndexForNormalTiles = Random.Range(0, normalTilePrefabs.Length);

                    while (!allowSpecialTilesSpawn)
                    {
                        Instantiate(normalTilePrefabs[randomIndexForNormalTiles], nextTilePosition, Quaternion.identity);
                        break;
                    }
                    while (allowSpecialTilesSpawn == true)
                    {
                        Instantiate(specialTilePrefab, nextTilePosition, Quaternion.identity);
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
                Vector3 nextTilePosition = startPositionOfEnemyTiles + new Vector3(x, 0f, z);
                int randomIndexForNormalTiles = Random.Range(0, normalTilePrefabs.Length);
                // Set enemy tiles upside down to hide tile images as they are not required.
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
                    float randomValue = Random.Range(1, 11);
                    bool allowSpecialTilesSpawn = false;
                    if (randomValue == 3)
                    {
                        allowSpecialTilesSpawn = true;
                    }
                    else allowSpecialTilesSpawn = false;

                    Vector3 nextTilePosition = startPositionOfEnemyTilesFromSecondRow + new Vector3(x, 0f, z);
                    int randomIndexForAllTiles = Random.Range(0, allTilePrefabs.Length);
                    int randomIndexForNormalTiles = Random.Range(0, normalTilePrefabs.Length);

                    while (!allowSpecialTilesSpawn)
                    {
                        Instantiate(normalTilePrefabs[randomIndexForNormalTiles], nextTilePosition, Quaternion.Euler(0, 0, 180f));
                        break;
                    }
                    while (allowSpecialTilesSpawn == true)
                    {
                        Instantiate(specialTilePrefab, nextTilePosition, Quaternion.Euler(0, 0, 180f));
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
    /*
     * Hammies Suggestion:
        int numRows = tileWidth;
        int numCols = tileHeightWithSpecial;
        List<GameObject> normalCubesList = new List<GameObject>();
        List<GameObject> specialCubesList = new List<GameObject>();

        // spawn normal cubes for the first two rows
        for (int row = 0; row < numRows && row < 1; row++)
        {
            for (int col = 0; col < numCols; col++)
            {
                Vector3 spawnPos = startPositionOfPlayerTilesFromSecondRow + new Vector3(col, 0, row);
                GameObject cube = Instantiate(normalTilePrefabs[Random.Range(0, normalTilePrefabs.Length)], spawnPos, Quaternion.identity);
                normalCubesList.Add(cube);
            }
        }

        // spawn a random special cube for the remaining rows
        for (int row = 2; row < numRows; row++)
        {
            int specialCol = Random.Range(0, numCols);
            for (int col = 0; col < numCols; col++)
            {
                Vector3 spawnPos = new Vector3(col, 0, row);
                GameObject cube;
                if (col == specialCol)
                {
                    cube = Instantiate(specialTilePrefab, spawnPos, Quaternion.identity);
                    specialCubesList.Add(cube);
                }
                else
                {
                    cube = Instantiate(normalTilePrefabs[Random.Range(0, normalTilePrefabs.Length)], spawnPos, Quaternion.identity);
                    normalCubesList.Add(cube);
                }
            }
        }
        playerTilesHaveBeenGenerated = true;
        */
    //-------------------------------------
    /*
    // Generate tiles from the 2nd row.
    if (playerFirstRowGenerated == true)
    {


        for (int x = 0; x < tileWidth; x++)
        {
            for (int z = 0; z < tileHeightWithoutSpecial; z++)
            {
                int randomValue = Random.Range(1, 5);
                // Add to list. 
                List<int> randomValueList = new List<int>();


                if (randomValueList.Count >= 1)
                {
                    for (int i = 0; x < randomValueList.Count; i++)
                    {
                        if (randomValueList[i] == 3)
                        {
                            playerSpecialTileHasSpawned = true;
                        }
                        else playerSpecialTileHasSpawned = false;
                    }
                }
                else return;


                bool allowSpecialTilesSpawn = false;

                if (randomValue == 3 && playerSpecialTileHasSpawned == false) // & bool is not true.
                {
                    allowSpecialTilesSpawn = true;
                    // if 3 has been checked set to true
                }
                else allowSpecialTilesSpawn = false;

                Vector3 nextTilePosition = startPositionOfPlayerTilesFromSecondRow + new Vector3(x, 0f, z);
                // Create random indexes for both prefab arrays.
                //int randomIndexForAllTiles = Random.Range(0, allTilePrefabs.Length);
                int randomIndexForNormalTiles = Random.Range(0, normalTilePrefabs.Length);

                while (!allowSpecialTilesSpawn)
                {
                    Instantiate(normalTilePrefabs[randomIndexForNormalTiles], nextTilePosition, Quaternion.identity);
                    break;
                }
                while (allowSpecialTilesSpawn == true)
                {
                    if (playerSpecialTileHasSpawned == true)
                    {
                        Instantiate(specialTilePrefab, nextTilePosition + new Vector3 (0,2,0), Quaternion.identity);
                    } else
                    {
                        Instantiate(normalTilePrefabs[randomIndexForNormalTiles], nextTilePosition, Quaternion.identity);
                    }
                    //Instantiate(allTilePrefabs[randomIndexForAllTiles], nextTilePosition, Quaternion.identity);
                    break;
                }
                while (x == 5 && z == 5)
                {
                    // Check if there is a special tile, if not spawn one in the last location of the for loop.
                    if (playerSpecialTileHasSpawned == true)
                    {
                        return;
                    }
                    if (playerSpecialTileHasSpawned == false)
                    {
                        Instantiate(specialTilePrefab, nextTilePosition + new Vector3(0, 2, 0), Quaternion.identity);
                    }
                }
                //check list if 3 is there do noting
                // if 3 is not there spawn a special tile in the last poition

            } 
        } 

    playerTilesHaveBeenGenerated = true; // Allow player to spawn.
    } */
}
