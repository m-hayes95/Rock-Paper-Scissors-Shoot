using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject up;
    //use const string, less error prone
    private const string MOVEABLE_TILE = "MoveableTile";

    private void Update()
    {
        //Cast ray cast in diagonal position, using the up game object
        Vector3 fwd = up.transform.TransformDirection(new Vector3(0, -1, 1));

        //Store the raycast hit data
        RaycastHit hit;
        
        //Debug for raycast and hit return info
        Debug.DrawRay(up.transform.position, fwd, Color.magenta);
        if (Physics.Raycast(up.transform.position, fwd, out hit))
        {
            Debug.Log("Up hit " + hit.collider.gameObject.name + hit.collider.gameObject.tag);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            //Check if raycast returns hit and it has moveable tile tag
            if (hit.collider != null && hit.collider.CompareTag(MOVEABLE_TILE))
            {
                //Move player to position of tile hit with raycast
                Debug.Log("Player Moved Foward to " + hit.collider.gameObject.name);
                //Tiles are under player, so needs an offset on the Y axis
                float playerHeight = 1.5f;
                transform.position = hit.collider.transform.position + Vector3.up * playerHeight;
            }
        }
            
                
    }
    
}
