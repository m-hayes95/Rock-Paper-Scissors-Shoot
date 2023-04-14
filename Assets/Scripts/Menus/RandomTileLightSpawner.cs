using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RandomTileLightSpawner : MonoBehaviour
{
    private int gridLength = 10;
    private int gridWidth = 5;
    private float lightSpawnThresehold = 0.5f;
    [SerializeField]
    private GameObject tileLight;
    private Vector3 startTilePosition = new Vector3 (-4f,0f,-2f);
    //float timer = 0f;
    float destroyPreviousTileLightTimer = 2f;


    private void Update()
    {
        for (int x = 0; x < gridLength; x++)
        {
            for (int y = 0 ; y < gridWidth; y++)
            {
                float hightOffset = 0.45f;
                Vector3 nextTilePosition = startTilePosition + new Vector3(x, hightOffset, y);
                float randomLightSpawnChance = Random.Range(0, 1000f);
                
                Debug.Log("Random chance value " + randomLightSpawnChance);
                if (randomLightSpawnChance <= lightSpawnThresehold)
                {
                    GameObject newLight = Instantiate(tileLight, nextTilePosition, Quaternion.identity);
                    Destroy(newLight, destroyPreviousTileLightTimer);
                }
                

            }
        }
    }
}
