using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] public bool rock = false, paper = false, scissors = false, special = false;

    public void PlayerOnRockTile()
    {
        //set player on rock tile bool to true
        rock = true;
    }

    public void PlayerOnPaperTile()
    {
        //set player on rock tile bool to true
        paper = true;
    }

    public void PlayerOnScissorsTile()
    {
        //set player on rock tile bool to true
        scissors = true;
    }

    public void PlayerOnSpecialTile()
    {
        //set player on rock tile bool to true
        special = true;
    }


}
