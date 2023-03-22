using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCurrentTileCheckRayCast : MonoBehaviour
{
    //Layer mask ref for tiles
    [SerializeField] private LayerMask rockTileLayerMask, paperTileLayerMask, scissorsTileLayerMask, specialTileLayerMask;
    //ref to tile manager script
    [SerializeField]
    private TileManager tileManager;
    [SerializeField]
    private GameObject _tileManager;
    private GameObject player;

    private const string TILE_MANAGER_TAG = "TileManagerTag";

    private void Start()
    {
        player = GetComponent<GameObject>();
        _tileManager = GameObject.FindGameObjectWithTag(TILE_MANAGER_TAG);
        tileManager = _tileManager.GetComponent<TileManager>();
    }

    private void Update()
    {
        //Create raycast from tile check game object, facing down
        Vector3 tileCheckRayCast = transform.TransformDirection(new Vector3(0, -1, 0));

        //Ray cast hit data 
        RaycastHit tileCheckHit;

        //set max distance for raycast parameters
        float maxDistance = 2f;

        //set rock tile bool to true if on correct tile. Check tile with layer mask
        if (Physics.Raycast(transform.position, tileCheckRayCast, out tileCheckHit, maxDistance, rockTileLayerMask))
        {
            //Debug.Log("Player current tile is " + tileCheckHit.collider.gameObject.tag);
            tileManager.PlayerOnRockTile();
        }

        //set paper tile bool to true if on correct tile. Check tile with layer mask
        if (Physics.Raycast(transform.position, tileCheckRayCast, out tileCheckHit, maxDistance, paperTileLayerMask))
        {
            //Debug.Log("Player current tile is " + tileCheckHit.collider.gameObject.tag);
            tileManager.PlayerOnPaperTile();
        }

        //set scissors tile bool to true if on correct tile. Check tile with layer mask
        if (Physics.Raycast(transform.position, tileCheckRayCast, out tileCheckHit, maxDistance, scissorsTileLayerMask))
        {
            //Debug.Log("Player current tile is " + tileCheckHit.collider.gameObject.tag);
            tileManager.PlayerOnScissorsTile();
        }

        //set special tile bool to true if on correct tile. Check tile with layer mask
        if (Physics.Raycast(transform.position, tileCheckRayCast, out tileCheckHit, maxDistance, specialTileLayerMask))
        {
            //Debug.Log("Player current tile is " + tileCheckHit.collider.gameObject.tag);
            tileManager.PlayerOnSpecialTile();
        }
    }
}
