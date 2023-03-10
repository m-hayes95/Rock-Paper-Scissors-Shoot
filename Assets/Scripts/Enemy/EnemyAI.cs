using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // ref to phase manager and ray cast scripts
    [SerializeField] private PhaseManager phaseManager;
    [SerializeField] private EnemyUpRayCast enemyUpRayCast;
    [SerializeField] private EnemyLeftRayCast enemyLeftRayCast;
    [SerializeField] private EnemyRightRayCast enemyRightRayCast;
    [SerializeField] private EnemyBattlePhaseRayCast enemyBattlePhaseRayCast;
    [SerializeField] private EnemyCurrentTileCheckRayCast enemyCurrentTileCheckRayCast;

    // check if enemy can move this turn
    [SerializeField] private bool canMovePhase1 = false, canMovePhase2 = false, canMovePhase3 = false, canMovePhase4 = false, isBattlePhase = false;

    // define a list for potential moves
    private List<System.Action> moves = new List<System.Action>(); 

    // statemachine for enemy ai phases
    public enum EnemyAISM { phase1, phase2, phase3, phase4, battlePhase }
    public EnemyAISM enemyState;

    private void Start()
    {
        // Add potential moves to the moves list
        moves.Add(enemyUpRayCast.EnemyMoveUp);
        moves.Add(enemyRightRayCast.EnemyMoveRight);
        moves.Add(enemyLeftRayCast.EnemyMoveLeft);
    }

    private void Update()
    {
        // Check enemys current tile]
        enemyCurrentTileCheckRayCast.CheckEnemysCurrentTile();

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
                        // Generate a random index within the range of the list
                        int randomIndex = Random.Range(0, moves.Count);
                        // Invoke the method at the random index
                        moves[randomIndex].Invoke();
                        // Return the can move boolean to false
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
                        int randomIndex = Random.Range(0, moves.Count);
                        moves[randomIndex].Invoke();
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
                        int randomIndex = Random.Range(0, moves.Count);
                        moves[randomIndex].Invoke();
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
                        int randomIndex = Random.Range(0, moves.Count);
                        moves[randomIndex].Invoke();
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
