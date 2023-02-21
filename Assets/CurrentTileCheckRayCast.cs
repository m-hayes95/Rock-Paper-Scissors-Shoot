using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentTileCheckRayCast : MonoBehaviour
{
    //bool check for current tile
    public bool rockTile = false, paperTile = false, scissorsTile = false, specialTile = false;
    //Layer mask ref for tiles
    [SerializeField] private LayerMask rockTileLayerMask, paperTileLayerMask, scissorsTileLayerMask, specialTileLayerMask;

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
            rockTile = true;
        }else
        {
            rockTile = false;
        }

        //set paper tile bool to true if on correct tile. Check tile with layer mask
        if (Physics.Raycast(transform.position, tileCheckRayCast, out tileCheckHit, maxDistance, paperTileLayerMask))
        {
            //Debug.Log("Player current tile is " + tileCheckHit.collider.gameObject.tag);
            paperTile = true;
        }
        else
        {
            paperTile = false;
        }

        //set scissors tile bool to true if on correct tile. Check tile with layer mask
        if (Physics.Raycast(transform.position, tileCheckRayCast, out tileCheckHit, maxDistance, scissorsTileLayerMask))
        {
            //Debug.Log("Player current tile is " + tileCheckHit.collider.gameObject.tag);
            scissorsTile = true;
        }
        else
        {
            scissorsTile = false;
        }

        //set special tile bool to true if on correct tile. Check tile with layer mask
        if (Physics.Raycast(transform.position, tileCheckRayCast, out tileCheckHit, maxDistance, specialTileLayerMask))
        {
            //Debug.Log("Player current tile is " + tileCheckHit.collider.gameObject.tag);
            specialTile = true;
        }
        else
        {
            specialTile = false;
        }
    }
}
