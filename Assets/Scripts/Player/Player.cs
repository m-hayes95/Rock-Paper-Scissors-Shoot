using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private GameObject player;
     
    public void PlayerChooseStartPosition()
    {
        Vector3 firstTile = new Vector3(0, 1.5f, 0);
        Instantiate(player, firstTile, Quaternion.identity);
        Debug.Log("Player Selected 1st Tile");
    }
}
