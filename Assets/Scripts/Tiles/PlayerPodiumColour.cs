using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPodiumColour : MonoBehaviour
{
    [SerializeField] private Material rockMat, paperMat, scissorsMat, specialMat; // ref to materials for each tile
    [SerializeField] private GameObject playerPodiumVisual; // ref to player podium game object
    private Renderer playerRenderer; // ref to game object renderer.
    [SerializeField] private TileManager tileManager; // ref to tile manager script


    private void Start()
    {
        playerRenderer = playerPodiumVisual.GetComponent<Renderer>(); // assign renderer on visual element of the game object.
   
    }

    private void Update()
    {
        if (tileManager == null)
            return;
        //player on rock tile set to correct mat
        if (tileManager.playerRock == true) 
        {
            //Debug.Log("player on rock");
            playerRenderer.material = rockMat; //Set the tile to rock materail

        }
        if (tileManager.playerPaper == true) 
        {
            //Debug.Log("player on paper");
            playerRenderer.material = paperMat;
        }
        if (tileManager.playerScissors == true) 
        {
            //Debug.Log("player on scissors");
            playerRenderer.material = scissorsMat;
        }
        if (tileManager.playerSpecial == true)
        {
            //Do not need the podium to change to special tile colour
            Debug.Log("Last player tile was a special tile");
        }

    }
}
