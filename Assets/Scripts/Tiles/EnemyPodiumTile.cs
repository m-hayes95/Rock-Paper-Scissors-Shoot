using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPodiumTile : MonoBehaviour
{
    [SerializeField] private Material rockMat, paperMat, scissorsMat, specialMat; // ref to materials for each tile
    private Renderer enemyPodiumTileRenderer; // ref to game object renderer.
    [SerializeField] private GameObject enemyPodiumVisual; // ref to enemy podium game object
    [SerializeField] private TileManager tileManager; // ref to tile manager script


    private void Start()
    {
        // Assign renderer from enemy podium visual game object
        enemyPodiumTileRenderer = enemyPodiumVisual.GetComponent<Renderer>(); 
    }

    private void Update()
    {
        // If enemy is on a tile, set the material of the podium to match the corrosponding colour.
        if (tileManager.enemyRock == true)
        {
            enemyPodiumTileRenderer.material = rockMat; 
        }
        if (tileManager.enemyPaper == true)
        {
            enemyPodiumTileRenderer.material = paperMat;
        }
        if (tileManager.enemyScissors == true)
        {
            enemyPodiumTileRenderer.material = scissorsMat;
        }
        if (tileManager.enemySpecial == true)
        {
            enemyPodiumTileRenderer.material = specialMat;
        }

    }
}
