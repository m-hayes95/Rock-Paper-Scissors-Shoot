using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManagerSpawner : MonoBehaviour
{
    [SerializeField]
    private PlayerSpawner playerSpawner;
    [SerializeField]
    private EnemySpawner enemySpawner;
    [SerializeField]
    private GameObject tileManager;

    private void Update()
    {
        if (playerSpawner.playerHasSpawned == true && enemySpawner.enemyHasSpawned == true) 
        {
            Instantiate(tileManager, transform.position, Quaternion.identity);
        }
    }
}
