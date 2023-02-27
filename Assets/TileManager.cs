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
        //set others to false
        paper = false;
        scissors = false;
        special = false;
    }

    public void PlayerOnPaperTile()
    {
        //set player on rock tile bool to true
        paper = true;
        //set others to false
        rock = false;
        scissors=false;
        special = false;
    }

    public void PlayerOnScissorsTile()
    {
        //set player on rock tile bool to true
        scissors = true;
        //set others to false
        rock = false;
        paper=false;
        special=false;
    }

    public void PlayerOnSpecialTile()
    {
        //set player on rock tile bool to true
        special = true;
        //set others to false
        rock = false;
        paper = false;
        scissors = false;
    }


}
