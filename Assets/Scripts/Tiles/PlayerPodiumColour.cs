using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPodiumColour : MonoBehaviour
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
        if (tileManager.playerRock == true) 
        {
            //Debug.Log("player on rock");
            r.material = rockMat; //Set the tile to rock materail

        }
        if (tileManager.playerPaper == true) 
        {
            //Debug.Log("player on paper");
            r.material = paperMat;
        }
        if (tileManager.playerScissors == true) 
        {
            //Debug.Log("player on scissors");
            r.material = scissorsMat;
        }
        if (tileManager.playerSpecial == true)
        {
            //Debug.Log("player on special");
            r.material = specialMat;
        }

    }
}
