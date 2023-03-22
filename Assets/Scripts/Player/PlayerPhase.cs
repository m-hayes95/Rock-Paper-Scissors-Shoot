using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPhase : MonoBehaviour
{
    private GameObject centerPointOfBoard; // Ref to center point of the board.
    private const string CENTER_OF_BOARD = "CenterOfBoard";
    private Player player;
    private float distanceVector; // Ref to vector distance.

    // Distance ref to switch current phase.
    private float phaseDistanceCheckpoint2 = 4.6f, phaseDistanceCheckpoint3 = 3.7f, phaseDistanceCheckpoint4 = 2.9f;
    private float battlePhaseDistanceCheckpoint = 1.5f;
    // Bool to check if distance has been reached.
    public bool checkpoint1 = false, checkpoint2 = false, checkpoint3 = false, checkpoint4 = false, battlePhaseCheckPoint = false;
    
    private void Start()
    {
        centerPointOfBoard = GameObject.FindGameObjectWithTag(CENTER_OF_BOARD);
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if (player!= null) // Check if the player exists first.
        {
            CheckDistnaceBetweenPlayerAndCenterOfBoard();
            checkpoint1 = true; // Player spawned so set to phase one.
            if (battlePhaseCheckPoint == false) // Stop calculating distance after reaching battle phase.
            {
                PhaseDistanceChecker();
            }
        }
    }

    private void CheckDistnaceBetweenPlayerAndCenterOfBoard()
    {
        // Use VectorDistance Singleton to calcualate distance between player and the center of the board.
        distanceVector = VectorDistance.Instance.CalculateVectorDistance(gameObject.transform.position, centerPointOfBoard.transform.position);
        //Debug.Log("Player is " + distanceVector + "from center of board");
    }

    private void PhaseDistanceChecker()
    {
        // Phase 2
        if (distanceVector <= phaseDistanceCheckpoint2 && !checkpoint2)
        {
            // If player passes checkpoint, switch to next phase.
            checkpoint2 = true;
        }
        // Phase 3
        if (distanceVector <= phaseDistanceCheckpoint3 && !checkpoint3)
        {
            checkpoint3 = true;
        }
        // Phase 4
        if (distanceVector <= phaseDistanceCheckpoint4 && !checkpoint4)
        {
            checkpoint4 = true;
        }
        // Battle Phase
        if (distanceVector <= battlePhaseDistanceCheckpoint && !battlePhaseCheckPoint)
        {
            battlePhaseCheckPoint = true;
        }

    }
}
