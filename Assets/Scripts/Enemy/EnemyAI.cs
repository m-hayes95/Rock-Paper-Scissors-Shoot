using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // ref to phase manager for checkpoint / phase check
    [SerializeField] private PhaseManager phaseManager;
    // check if enemy can move this turn
    [SerializeField] private bool canMove1 = false, canMove2 = false, canMove3 = false, canMove4 = false, battlePhase = false;
    // statemachine for enemy ai moves
    public enum EnemyAISM { phase1, phase2, phase3, phase4, battlePhase }
    public EnemyAISM enemyState;

    private void Update()
    {
        // Enemy ai state machine
        switch (enemyState)
        {
            case EnemyAISM.phase1:
                // enemy make 1st move
                canMove1 = true;

                // change phase
                if (phaseManager.checkpoint2 == true)
                {
                    enemyState = EnemyAISM.phase2;
                }
                break;

            case EnemyAISM.phase2:
                canMove2 = true;

                if (phaseManager.checkpoint3 == true)
                {
                    enemyState = EnemyAISM.phase3;
                }
                break;

            case EnemyAISM.phase3:
                canMove3 = true;

                if (phaseManager.checkpoint4 == true)
                {
                    enemyState = EnemyAISM.phase4;
                }
                break;

            case EnemyAISM.phase4:
                canMove4 = true;

                if (phaseManager.battlePhaseCheckPoint == true)
                {
                    enemyState = EnemyAISM.battlePhase;
                }
                break;

            case EnemyAISM.battlePhase:
                battlePhase = true;
                break;

            default:
                // Check if there is no state available
                Debug.Log(enemyState);
                break;
        }
    }
}
