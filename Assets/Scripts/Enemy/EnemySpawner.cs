using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy; // Ref to enemy prefab.
    [SerializeField] private float[] startTileLocation; // Array for enemy spawn location offsets.
    // Ref to player spawner script, to check if player has spawned yet.
    [SerializeField] private PlayerSpawner playerSpawner;
    [SerializeField] private RandomTileGenerator randomTileGenerator;
    private bool enemyHasSpawned = false;

    private void Update()
    {
        if (playerSpawner.playerHasSpawned == true && enemyHasSpawned == false)
        {
            SpawnEnemy();
            enemyHasSpawned= true;
        }
        
    }

    private void SpawnEnemy()
    {
        float offsetForEnemyTileStartCoord = 3f;
        float offsetForEnemyHeight = 1.5f;
        Vector3 enemyStartTile = randomTileGenerator.startPositionOfEnemyTiles + new Vector3(0, 0, offsetForEnemyTileStartCoord);
        Vector3 firstTile = enemyStartTile + new Vector3(0, offsetForEnemyHeight, 0);
        Instantiate(enemy, firstTile, Quaternion.Euler(0, 180f, 0));
    }
}
