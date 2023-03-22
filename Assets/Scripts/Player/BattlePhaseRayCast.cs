using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePhaseRayCast : MonoBehaviour
{
    private const string PRE_BATTLE_PHASE_TILE = "PreBattleTile";
    private const string PLAYER_BATTLE_PODIUM = "PlayerBattleTile";
    private const string PLAYER = "Player";
    //Ref to player and battle podium game object
    [SerializeField] private GameObject player, playerBattlePodium;
    //Ref to check if battle phase has been entered yet
    [SerializeField] private bool playerHasEnteredBP = false;

    private void Start()
    {
        // Assign game objects
        player = GameObject.FindGameObjectWithTag(PLAYER);
        playerBattlePodium = GameObject.FindGameObjectWithTag(PLAYER_BATTLE_PODIUM);
    }
    private void Update()
    {
        //Cast ray cast downwards at tiles
        Vector3 battlePhaseCheckRayCast = transform.TransformDirection(new Vector3(0, -1, 0));

        //Raycast hit data
        RaycastHit battlePhaseCheckRCHit;

        //Draw a debug line for ray cast 
        Debug.DrawRay(transform.position, battlePhaseCheckRayCast, Color.black);

        //Debug to check tile being hit
        if (Physics.Raycast(transform.position, battlePhaseCheckRayCast, out battlePhaseCheckRCHit))
        {
            //Debug.Log("Battle Phase Ray Cast Check hit" +battlePhaseCheckRCHit.collider.gameObject.tag);
        }

        //If ray cast hit collision is with tile with Pre battle tag, and has not entered battle
        if (battlePhaseCheckRCHit.collider != null && 
            battlePhaseCheckRCHit.collider.gameObject.CompareTag(PRE_BATTLE_PHASE_TILE) && 
            playerHasEnteredBP == false)
        {
            //Enter battle phase if condions are met
            //Debug.Log("StartBattlePhase");
            //Players postion transformed to player podium location w/ offset on Y axis
            float playerHeight = 1.5f;
            player.transform.position = playerBattlePodium.transform.position + Vector3.up * playerHeight;
            //Rotate player to face enemy
            player.transform.Rotate(0,90,0);
            //Set Battle phase bool to true
            playerHasEnteredBP = true;
        }
    }
}
