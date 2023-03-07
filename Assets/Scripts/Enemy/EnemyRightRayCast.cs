using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRightRayCast : MonoBehaviour
{
    [SerializeField] private EnemyAI enemyAI;
    
    private const string MOVEABLE_TILE = "MoveableTile";

    public void EnemyMoveRight()
    {
        //Cast ray cast in diagonal position, using the up game object
        Vector3 fwdRight = transform.TransformDirection(new Vector3(0, -1, 1));

        //Store the raycast hit data
        RaycastHit rightHit;

        //Debug for raycast and hit return info
        Debug.DrawRay(transform.position, fwdRight, Color.grey);

        if (Physics.Raycast(transform.position, fwdRight, out rightHit))
        {
            //Debug.Log("RIGHT hit " + rightHit.collider.gameObject.name + rightHit.collider.gameObject.tag);
        }

        //Check if raycast returns hit and it has moveable tile tag
        if (rightHit.collider != null && rightHit.collider.CompareTag(MOVEABLE_TILE))
        {
            //Move player to position of tile hit with raycast
            //Debug.Log("Player Moved RIGHT to " + rightHit.collider.gameObject.name);
            //Tiles are under player, so needs an offset on the Y axis
            float enemyHeight = 1.5f;
            enemyAI.transform.position = rightHit.collider.transform.position + Vector3.up * enemyHeight;
        }
    }
}
