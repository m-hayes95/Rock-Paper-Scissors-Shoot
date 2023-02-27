using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodiumColour : MonoBehaviour
{
    [SerializeField] private Material rockMat, paperMat, scissorsMat, specialMat; // ref to materials for each tile
    private Renderer r; // ref to game object renderer.
    [SerializeField] private TileManager tileManager; // ref to tile manager script


    private void Start()
    {
        r = GetComponent<Renderer>(); // assign renderer
   
    }

    private void Update()
    {
        //player on rock tile set to correct mat
        if (tileManager.rock == true) 
        {
            //Debug.Log("player on rock");
            r.material = rockMat; //Set the tile to rock materail

        }
        if (tileManager.paper == true) 
        {
            //Debug.Log("player on paper");
            r.material = paperMat;
        }
        if (tileManager.scissors == true) 
        {
            //Debug.Log("player on scissors");
            r.material = scissorsMat;
        }
        if (tileManager.special == true)
        {
            //Debug.Log("player on special");
            r.material = specialMat;
        }

    }
}
