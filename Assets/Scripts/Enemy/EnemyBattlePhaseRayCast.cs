using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattlePhaseRayCast : MonoBehaviour
{
    private const string PRE_BATTLE_PHASE_TILE = "PreBattleTile";
    //Ref to player and battle podium game object
    [SerializeField] private GameObject enemy, enemyBattlePodium;
    //Ref to check if battle phase has been entered yet
    [SerializeField] private bool playerHasEnteredBP = false;

    public void EnemyEnterBattlePhase()
    {
        //Cast ray cast downwards at tiles
        Vector3 EnemyBattlePhaseCheckRayCast = transform.TransformDirection(new Vector3(0, -1, 0));

        //Raycast hit data
        RaycastHit EnemyBattlePhaseCheckRayCastHit;

        //Draw a debug line for ray cast 
        Debug.DrawRay(transform.position, EnemyBattlePhaseCheckRayCast, Color.black);

        //Debug to check tile being hit
        if (Physics.Raycast(transform.position, EnemyBattlePhaseCheckRayCast, out EnemyBattlePhaseCheckRayCastHit))
        {
            //Debug.Log("Battle Phase Ray Cast Check hit" +battlePhaseCheckRCHit.collider.gameObject.tag);
        }

        //If ray cast hit collision is with tile with Pre battle tag, and has not entered battle
        if (EnemyBattlePhaseCheckRayCastHit.collider != null &&
            EnemyBattlePhaseCheckRayCastHit.collider.gameObject.CompareTag(PRE_BATTLE_PHASE_TILE) &&
            playerHasEnteredBP == false)
        {
            //Enter battle phase if condions are met
            //Debug.Log("StartBattlePhase");
            //Players postion transformed to player podium location w/ offset on Y axis
            float enemyHeight = 1.5f;
            enemy.transform.position = enemyBattlePodium.transform.position + Vector3.up * enemyHeight;
            //Rotate player to face enemy
            enemy.transform.Rotate(0, 90, 0);
            //Set Battle phase bool to true
            playerHasEnteredBP = true;
        }
    }
}
