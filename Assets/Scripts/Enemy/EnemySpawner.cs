using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy; // Ref to enemy prefab.
    private int[] startTileLocation = new int[5] { 0, 1, 2, 3, 4 }; // Array for enemy spawn location offsets.
    // Ref to player spawner script, to check if player has spawned yet.
    [SerializeField] private PlayerSpawner playerSpawner;
    // Ref to tile script to check enemy grids 1st generated tile.
    [SerializeField] private RandomTileGenerator randomTileGenerator;
    public bool enemyHasSpawned = false; // Accessed in TileManager and GameManager.

    private void Update()
    {
        // Check if player has spawned and enemy has not yet spawned in before spawning enemy.
        if (playerSpawner.playerHasSpawned == true && enemyHasSpawned == false)
        {
            SpawnEnemy();
            enemyHasSpawned= true;
        }
        
    }

    private void SpawnEnemy()
    {
        // Create a float value for the new vector which choses a random start tile.
        float enemyRandomStartTile = Random.Range(0, startTileLocation.Length);
        //Debug.Log("Enemy Started on tile " + enemyRandomStartTile);

        float offsetForEnemyHeight = 1.5f; // Enemy height offset, so they spawn above the grid.
        // New vector transform coord for enemy spawn, using start tile from enemy generated grid.
        Vector3 enemyStartTile = randomTileGenerator.startPositionOfEnemyTiles + 
            new Vector3(enemyRandomStartTile, offsetForEnemyHeight, 0);

        // Spawn enemy at new start tile rotated at 180 degrees, so they face the player.
        Instantiate(enemy, enemyStartTile, Quaternion.Euler(0, 180f, 0));
    }

    public void EnemySpawnerOnNextLevel()
    {
        // Reset the enemy has spawned bool so other scripts can reset their found enemy game object on the start of the next scene.
        enemyHasSpawned = false;
    }
}
