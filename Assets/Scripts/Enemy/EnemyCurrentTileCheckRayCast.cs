using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCurrentTileCheckRayCast : MonoBehaviour
{
    //Layer mask ref for tiles
    [SerializeField] private LayerMask rockTileLayerMask, paperTileLayerMask, scissorsTileLayerMask, specialTileLayerMask;
    //ref to tile manager script
    [SerializeField] private TileManager tileManager;
    [SerializeField] private GameObject _tileManager;
    private const string TILE_MANAGER_TAG = "TileManagerTag";
    private void Start()
    {
        // Assign scene tile manager script for ref
        _tileManager = GameObject.FindGameObjectWithTag(TILE_MANAGER_TAG);
        tileManager = _tileManager.GetComponent<TileManager>();
    }



    public void CheckEnemysCurrentTile()
    {
        //Create raycast from tile check game object, facing down
        Vector3 enemyTileCheckRayCast = transform.TransformDirection(new Vector3(0, -1, 0));

        //Ray cast hit data 
        RaycastHit enemyTileCheckHit;

        //set max distance for raycast parameters
        float maxDistance = 2f;

        //set rock tile bool to true if on correct tile. Check tile with layer mask
        if (Physics.Raycast(transform.position, enemyTileCheckRayCast, out enemyTileCheckHit, maxDistance, rockTileLayerMask))
        {
            //Debug.Log("Enemy current tile is " + enemyTileCheckHit.collider.gameObject.name);
            tileManager.EnemyOnRockTile();
            
        }

        //set paper tile bool to true if on correct tile. Check tile with layer mask
        if (Physics.Raycast(transform.position, enemyTileCheckRayCast, out enemyTileCheckHit, maxDistance, paperTileLayerMask))
        {
            //Debug.Log("Enemy current tile is " + enemyTileCheckHit.collider.gameObject.name);
            tileManager.EnemyOnPaperTile();
        }

        //set scissors tile bool to true if on correct tile. Check tile with layer mask
        if (Physics.Raycast(transform.position, enemyTileCheckRayCast, out enemyTileCheckHit, maxDistance, scissorsTileLayerMask))
        {
            //Debug.Log("Enemy current tile is " + enemyTileCheckHit.collider.gameObject.name);
            tileManager.EnemyOnScissorsTile();
        }

        //set special tile bool to true if on correct tile. Check tile with layer mask
        if (Physics.Raycast(transform.position, enemyTileCheckRayCast, out enemyTileCheckHit, maxDistance, specialTileLayerMask))
        {
            //Debug.Log("Enemy current tile is " + enemyTileCheckHit.collider.gameObject.name);
            tileManager.EnemyOnSpecialTile();
        }
    }
}
