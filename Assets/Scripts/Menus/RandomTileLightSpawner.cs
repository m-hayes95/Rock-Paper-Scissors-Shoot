using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RandomTileLightSpawner : MonoBehaviour
{
    private int gridLength = 10;
    private int gridWidth = 5;
    private float lightSpawnThresehold = 0.3f;
    private float destroyPreviousTileLightTimer = 2f;
    [SerializeField]
    private GameObject tileLight;
    private Vector3 startTilePosition = new Vector3 (-4f,0f,-2f);
    


    private void Update()
    {
        // Loop through each tile in the grid.
        for (int x = 0; x < gridLength; x++)
        {
            for (int y = 0 ; y < gridWidth; y++)
            {
                float hightOffset = 0.45f; // Add a offset for the tile hight.
                // Location of next tile, starting from the start tile position.
                Vector3 nextTilePosition = startTilePosition + new Vector3(x, hightOffset, y);
                // Create a random value to spawn a light.
                float randomLightSpawnChance = Random.Range(0, 1000f);
                
                //Debug.Log("Random chance value " + randomLightSpawnChance);

                // Check if random value is below the defined threshold.
                if (randomLightSpawnChance <= lightSpawnThresehold)
                {
                    // Create a new game object with a instantiated light at the next position.
                    GameObject newLight = Instantiate(tileLight, nextTilePosition, Quaternion.identity);
                    // Destroy the new instantiated game obejct after a pre defined timer.
                    Destroy(newLight, destroyPreviousTileLightTimer);
                }
                

            }
        }
    }
}
