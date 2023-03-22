using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{
    [SerializeField] private GameObject phaseDistanceChecker;
    [SerializeField]
    private GameObject player;
    private const string PLAYER = "Player";
    [SerializeField] private PlayerSpawner playerSpawner;
    private float vector3Distance;
    // Distance ref to switch current phase.
    private float phaseDistanceCheckpoint2 = 3.7f, phaseDistanceCheckpoint3 = 2.8f, phaseDistanceCheckpoint4 = 1.9f;
    private float battlePhaseDistanceCheckpoint = 1.2f;
    // Bool to check if distance has been reached.
    public bool checkpoint1 = false, checkpoint2 = false, checkpoint3 = false, checkpoint4 = false, battlePhaseCheckPoint = false;
    [SerializeField]
    private bool playerExists = false;

    private void Update()
    {   
        if (playerSpawner.playerHasSpawned == true && playerExists == false) {
            player = GameObject.FindGameObjectWithTag(PLAYER);
            playerExists = true;

            if (playerExists == true)
            {
                PhaseDistanceChecker();
                checkpoint1 = true; // phase 1 
            }
            
        }
        
    }
    private void PhaseDistanceChecker()
    {
        // use vector distance from player 
        // with checkpoint that change the current phase
        vector3Distance = Vector3.Distance(player.transform.position, phaseDistanceChecker.transform.position);

        Debug.Log("PHASE  " + vector3Distance);

        // Phase 1
        
        // Phase 2
        if (vector3Distance <= phaseDistanceCheckpoint2 && !checkpoint2)
        {
            checkpoint2 = true;
        }
        // Phase 3
        if (vector3Distance <= phaseDistanceCheckpoint3 && !checkpoint3)
        {
            checkpoint3 = true;
        }
        // Phase 4
        if (vector3Distance <= phaseDistanceCheckpoint4 && !checkpoint4)
        {
            checkpoint4 = true;
        }
        // Battle Phase
        if (vector3Distance <= battlePhaseDistanceCheckpoint && !battlePhaseCheckPoint)
        {
            battlePhaseCheckPoint = true;
        }

    }

}
