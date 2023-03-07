using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUpRayCast : MonoBehaviour
{
    [SerializeField] private EnemyAI enemyAI;
    //ref to moveable tile tag
    private const string MOVEABLE_TILE = "MoveableTile";

    public void EnemyMoveUp()
    {
        //Cast ray cast in diagonal position, using the up game object
        Vector3 fwd = transform.TransformDirection(new Vector3(0, -1, 1));

        //Store the raycast hit data
        RaycastHit hit;

        //Debug for raycast and hit return info
        Debug.DrawRay(transform.position, fwd, Color.magenta);

        Physics.Raycast(transform.position, fwd, out hit);

        //Check if raycast returns hit and it has moveable tile tag
        if (hit.collider != null && hit.collider.CompareTag(MOVEABLE_TILE))
        {
            //Move enemy to position of tile hit with raycast
            //Debug.Log("Enemy Moved Foward to " + hit.collider.gameObject.name);
            //Tiles are under player, so needs an offset on the Y axis
            float enemyHeight = 1.5f;
            enemyAI.transform.position = hit.collider.transform.position + Vector3.up * enemyHeight;
        }
    }
}
