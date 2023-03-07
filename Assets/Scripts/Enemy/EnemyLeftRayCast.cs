using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLeftRayCast : MonoBehaviour
{
    [SerializeField] private EnemyAI enemy;
    private const string MOVEABLE_TILE = "MoveableTile";

    public void EnemyMoveLeft()
    {
        //Cast ray cast in diagonal position, using the up game object
        Vector3 fwdLeft = transform.TransformDirection(new Vector3(0, -1, 1));

        //Store the raycast hit data
        RaycastHit leftHit;

        //Debug for raycast and hit return info
        Debug.DrawRay(transform.position, fwdLeft, Color.cyan);

        if (Physics.Raycast(transform.position, fwdLeft, out leftHit))
        {
            //Debug.Log("Left hit " + leftHit.collider.gameObject.name + leftHit.collider.gameObject.tag);
        }

        //Check if raycast returns hit and it has moveable tile tag
        if (leftHit.collider != null && leftHit.collider.CompareTag(MOVEABLE_TILE))
        {
            //Move player to position of tile hit with raycast
            //Debug.Log("Player Moved Left to " + leftHit.collider.gameObject.name);
            //Tiles are under player, so needs an offset on the Y axis
            float enemyHeight = 1.5f;
            enemy.transform.position = leftHit.collider.transform.position + Vector3.up * enemyHeight;
        }
    }
}
