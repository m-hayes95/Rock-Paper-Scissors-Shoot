using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // ref to phase manager for checkpoint / phase check
    [SerializeField] private PhaseManager phaseManager;
    [SerializeField] private EnemyUpRayCast enemyUpRayCast;
    [SerializeField] private EnemyLeftRayCast enemyLeftRayCast;
    [SerializeField] private EnemyRightRayCast enemyRightRayCast;
    [SerializeField] private EnemyBattlePhaseRayCast enemyBattlePhaseRayCast;

    // check if enemy can move this turn
    [SerializeField] private bool canMovePhase1 = false, canMovePhase2 = false, canMovePhase3 = false, canMovePhase4 = false, isBattlePhase = false;
    // statemachine for enemy ai moves
    public enum EnemyAISM { phase1, phase2, phase3, phase4, battlePhase }
    public EnemyAISM enemyState;

    private void Update()
    {
        // Enemy ai state machine
        switch (enemyState)
        {
            case EnemyAISM.phase1:
                
                if (phaseManager.checkpoint2 == true)
                {
                    // check if player has moved, if yes enemy can now make 1st move
                    canMovePhase1 = true;
                    if (canMovePhase1 == true)
                    {
                        enemyUpRayCast.EnemyMoveUp(); // enemy make 1st move
                        canMovePhase1 = false;
                    }
                    enemyState = EnemyAISM.phase2; // change current phase
                }
                break;

            case EnemyAISM.phase2:
                
                if (phaseManager.checkpoint3 == true)
                {
                    canMovePhase2 = true;
                    if (canMovePhase2 == true)
                    {
                        enemyRightRayCast.EnemyMoveRight();
                        canMovePhase2 = false;
                    }
                    enemyState = EnemyAISM.phase3;
                }
                break;

            case EnemyAISM.phase3:
                

                if (phaseManager.checkpoint4 == true)
                {
                    canMovePhase3 = true;
                    if (canMovePhase3 == true)
                    {
                        enemyLeftRayCast.EnemyMoveLeft();
                        canMovePhase3 = false;
                    }
                    enemyState = EnemyAISM.phase4;
                }
                break;

            case EnemyAISM.phase4:
            
                if (phaseManager.battlePhaseCheckPoint == true)
                {
                    canMovePhase4 = true;
                    if (canMovePhase4 == true)
                    {
                        enemyUpRayCast.EnemyMoveUp();
                        canMovePhase4 = false;
                    }
                    enemyState = EnemyAISM.battlePhase;
                }
                break;

            case EnemyAISM.battlePhase:
                isBattlePhase = true;
                if (isBattlePhase == true)
                {
                    // move to enemy podium
                    enemyBattlePhaseRayCast.EnemyEnterBattlePhase();
                }
                break;

            default:
                // Check if there is no state available
                Debug.Log(enemyState);
                break;
        }
    }
}
