using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodiumColour : MonoBehaviour
{
    //ref to player for scritps
    //[SerializeField] private CurrentTileCheckRayCast playerTileCheck;
    public GameObject playerTileCheck;

    [SerializeField] private Material rockMat, paperMat, scissorsMat, specialMat;
    [SerializeField] private bool rock, paper, scissors, special;
    private Renderer r;

    private void Start()
    {
        r = GetComponent<Renderer>();
       //new bool player = rockTile.GetComponent<CurrentTileCheckRayCast>();
       
    }

    private void Update()
    {
        //player on rock tile set to correct mat
        if (playerTileCheck.GetComponent<CurrentTileCheckRayCast>().rockTile == true)
        {
            //Set the tile to rock materail
            Debug.Log("player on rock");
            rock = true;
            r.material = rockMat;
        }
        else
        {
            rock = false;
        }

        //player on paper tile set to correct mat
        if (playerTileCheck.GetComponent<CurrentTileCheckRayCast>().paperTile == true)
        {
            paper = true;
            Debug.Log("player on paper");
            r.material = paperMat;
        }
        else
        {
            paper = false;
        }
        //player on scissors tile set to correct mat
        if (playerTileCheck.GetComponent<CurrentTileCheckRayCast>().scissorsTile == true)
        {
            scissors = true;
            r.material = scissorsMat;
        }
        else
        {
            scissors=false;
        }

        //player on special tile set to correct mat
        if (playerTileCheck.GetComponent<CurrentTileCheckRayCast>().specialTile == true)
        {
            special = true;
            r.material = specialMat;
        }
        else
        {
            special = false;
        }   

    }
}
