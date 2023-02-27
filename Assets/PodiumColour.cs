using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodiumColour : MonoBehaviour
{
    //ref to player for scritps
    //[SerializeField] private CurrentTileCheckRayCast playerTileCheck;
    public GameObject playerTileCheck;

    [SerializeField] private Material rockMat, paperMat, scissorsMat, specialMat;
    //[SerializeField] private bool rock, paper, scissors, special;
    private Renderer r;
    //ref to tile manager script
    private TileManager tileManager;

    private void Start()
    {
        r = GetComponent<Renderer>();
       //new bool player = rockTile.GetComponent<CurrentTileCheckRayCast>();
       
    }

    private void Update()
    {
        //player on rock tile set to correct mat
        if (tileManager.rock == true)
        {
            //Set the tile to rock materail
            Debug.Log("player on rock");
            r.material = rockMat;
        }

        //player on paper tile set to correct mat
        if (tileManager.paper == true)
        {
            Debug.Log("player on paper");
            r.material = paperMat;
        }
    
        //player on scissors tile set to correct mat
        if (tileManager.scissors == true)
        {
            Debug.Log("player on scissors");
            r.material = scissorsMat;
        }

        //player on special tile set to correct mat
        if (tileManager.special == true)
        {
            Debug.Log("player on special");
            r.material = specialMat;
        }

    }
}
