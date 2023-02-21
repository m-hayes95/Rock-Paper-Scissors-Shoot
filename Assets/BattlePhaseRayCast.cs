using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePhaseRayCast : MonoBehaviour
{
    private const string PRE_BATTLE_PHASE_TILE = "PreBattleTile";
    [SerializeField] private GameObject player;

    private void Update()
    {
        //Cast ray cast downwards at tiles
        Vector3 battlePhaseCheckRayCast = transform.TransformDirection(new Vector3(0, -1, 0));

        RaycastHit battlePhaseCheckRCHit;

        Debug.DrawRay(transform.position, battlePhaseCheckRayCast, Color.black);

        if (Physics.Raycast(transform.position, battlePhaseCheckRayCast, out battlePhaseCheckRCHit))
        {
            Debug.Log("Battle Phase Ray Cast Check hit" +battlePhaseCheckRCHit.collider.gameObject.tag);
        }

        if (battlePhaseCheckRCHit.collider != null && battlePhaseCheckRCHit.collider.gameObject.CompareTag(PRE_BATTLE_PHASE_TILE))
        {
            Debug.Log("StartBattlePhase");
        }
    }
}
