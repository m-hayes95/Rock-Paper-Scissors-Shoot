using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    //ref to prefab layer mask - For Capsule Cast
    [SerializeField] private LayerMask rockTileLayerMask;
    [SerializeField] private float playerSpeed = 7f;

    private void Update()
    {
        //only moving on a 2 axis so Vector 3 is not required.
        Vector2 inputVector = new Vector2(0,0);
        //player inputs
        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
        }
        /*if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }*/

        //Debug.Log(inputVector);

        //translate the Vector 2 input into vector 3 input.
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        //transform.position += moveDir * playerSpeed * Time.deltaTime;
        
        //Create a capsuale cast around the player object that checks for tile layer masks on objects it collides with.
        float playerHeight = 2f;
        float playerRadius = 0.3f;
        float moveDistance = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance, rockTileLayerMask);
        Debug.Log(canMove);
        Color color = Color.yellow;
        Debug.DrawLine(transform.position, transform.position + Vector3.up * playerHeight, color, 0.5f);
        if (!canMove)
        {
            transform.position += moveDir * playerSpeed * Time.deltaTime;
        }
    }


}
