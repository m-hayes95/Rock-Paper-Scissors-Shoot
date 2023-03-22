using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // ref to phase & tile & game manager and ray cast scripts
    [SerializeField] private GameObject _playerPhase;
    [SerializeField] private PlayerPhase playerPhase;
    [SerializeField] private GameObject _tileManager;
    [SerializeField] private TileManager tileManager;
    [SerializeField] private GameManager gameManager;

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

    private const string PLAYER = "Player";
    private const string TILE_MANAGER_TAG = "TileManagerTag";



    private void Start()
    {
        // Assign Phase and Tile manger scripts
        _playerPhase = GameObject.FindGameObjectWithTag(PLAYER);
        playerPhase = _playerPhase.GetComponent<PlayerPhase>();
        _tileManager = GameObject.FindGameObjectWithTag(TILE_MANAGER_TAG);
        tileManager = _tileManager.GetComponent<TileManager>();

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
                
                if (playerPhase.checkpoint2 == true)
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
                
                if (playerPhase.checkpoint3 == true)
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
                

                if (playerPhase.checkpoint4 == true)
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
            
                if (playerPhase.battlePhaseCheckPoint == true)
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

                    // check what the current tile is for the battle phase to see who wins
                    //Player Wins
                    if (tileManager.playerRock && tileManager.enemyScissors == true) {
                        gameManager.GamePlayerWin();
                    }
                    if (tileManager.playerPaper && tileManager.enemyRock == true)
                    {
                        gameManager.GamePlayerWin();
                    }
                    if (tileManager.playerScissors && tileManager.enemyPaper == true)
                    {
                        gameManager.GamePlayerWin();
                    }
                    //Enemy wins
                    if (tileManager.playerRock && tileManager.enemyPaper == true)
                    {
                        gameManager.GameEnemyWin();
                    }
                    if (tileManager.playerPaper && tileManager.enemyScissors == true)
                    {
                        gameManager.GameEnemyWin();
                    }
                    if (tileManager.playerScissors && tileManager.enemyRock == true)
                    {
                        gameManager.GameEnemyWin();
                    }
                    //Draws
                    if (tileManager.playerRock && tileManager.enemyRock == true)
                    {
                        gameManager.GameDraw();
                    }
                    if (tileManager.playerPaper && tileManager.enemyPaper == true)
                    {
                        gameManager.GameDraw();
                    }
                    if (tileManager.playerScissors && tileManager.enemyScissors == true)
                    {
                        gameManager.GameDraw();
                    }
                }
                break;

            default:
                // Check if there is no state available
                Debug.Log(enemyState);
                break;
        }

       
    }
}
