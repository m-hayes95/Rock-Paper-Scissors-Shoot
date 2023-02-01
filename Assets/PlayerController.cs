using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public bool isTile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //raycast hit to check if player can move
        Vector3 fwd = transform.TransformDirection(new Vector3(0, -1,1));
        //use forward vector from a game object in front of Player. Then rotate the object to the correct orientaion.

        //draw a debug line for ray cast
        Debug.DrawRay(transform.position, fwd, Color.magenta);

        //saving ray cast hit data
        RaycastHit hit;

        //raycast out, check if something is hit
        if (Physics.Raycast(transform.position, fwd, out hit))
        {
            Debug.Log("hit the" + hit.collider.gameObject.name);
        }

        //move up
        if (Input.GetKeyDown("w"))
        {
            //Debug.Log("We are moving");
            transform.Translate(0, 0, 1);
        }
        //move left
        if (Input.GetKeyDown("a"))
        {
            transform.Translate(-1, 0, 0);
        }
        //move right
        if (Input.GetKeyDown("d"))
        {
            transform.Translate(1, 0, 0);
        }
        //move down
        if (Input.GetKeyDown("s"))
        {
            transform.Translate(0, 0, -1);
        }
    }
}
