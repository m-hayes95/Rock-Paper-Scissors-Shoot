using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Ref to phase & tile & game manager and ray cast scripts
    [SerializeField] private GameObject _playerPhase;
    [SerializeField] private PlayerPhase playerPhase;
    
    
    private GameManager gameManager;
    private GameObject _gameManager;

    [SerializeField] private EnemyUpRayCast enemyUpRayCast;
    [SerializeField] private EnemyLeftRayCast enemyLeftRayCast;
    [SerializeField] private EnemyRightRayCast enemyRightRayCast;
    [SerializeField] private EnemyBattlePhaseRayCast enemyBattlePhaseRayCast;
    [SerializeField] private EnemyCurrentTileCheckRayCast enemyCurrentTileCheckRayCast;

    [SerializeField] private GameObject enemyTrailCube1, enemyTrailCube2;
    // Check if we have instantiated a enemy trail light yet.
    private bool phase1EnemyTrailInstantiated = false;
    private bool phase2EnemyTrailInstantiated = false;
    private bool phase3EnemyTrailInstantiated = false;
    private bool phase4EnemyTrailInstantiated = false;

    // Check if enemy can move this turn.
    [SerializeField] private bool canMovePhase1 = false, canMovePhase2 = false, canMovePhase3 = false, canMovePhase4 = false, isBattlePhase = false;
    private bool enemyMadeFistMove = false, enemyMadeSecondMove = false, enemyMadeThridMove = false;
    // Check if enemy position vector is false.
    private bool phase1PositionEmpty = true;
    private bool phase2PositionEmpty = true;
    private bool phase3PositionEmpty = true;
    private bool phase4PositionEmpty = true;
    // Store each phase location.
    public Vector3 enemyPhase1Location;
    public Vector3 enemyPhase2Location;
    public Vector3 enemyPhase3Location;
    public Vector3 enemyPhase4Location;
    

    // Define a list for potential moves
    private List<System.Action> moves = new List<System.Action>();
    // Define a list for moves that have been used
    private List<System.Action> usedMoves = new List<System.Action> ();
    // Define a list containing the two methods that can be used to randomly move the enemy,
    // before and after a special tile reset.
    private List<System.Action> randomMovesOrUsedMove = new List<System.Action>();
    // Check if enemys moves have been reset before deciding to use used moves list to Invoke actions.
    [SerializeField]
    private bool enemyMovesReset = false;

    // Statemachine for enemy ai phases
    public enum EnemyAISM { phase1, phase2, phase3, phase4, battlePhase }
    public EnemyAISM enemyState;

    private const string PHASE_MANAGER = "PhaseManagerTag";
    private const string TILE_MANAGER_TAG = "TileManagerTag";
    private const string GAME_MANAGER = "GameManagerTag";


    // Timer
    private float timer = 0f;
    private float enemyMoveDelay = 0.5f;



    private void Start()
    {
        // Assign Phase and Tile manger scripts.
        _playerPhase = GameObject.FindGameObjectWithTag(PHASE_MANAGER);
        playerPhase = _playerPhase.GetComponent<PlayerPhase>();

        // Assign Game manger scripts.
        _gameManager = GameObject.FindGameObjectWithTag(GAME_MANAGER);
        gameManager = _gameManager.GetComponent<GameManager>();

        // Add potential moves to the moves list.
        moves.Add(enemyUpRayCast.EnemyMoveUp);
        moves.Add(enemyRightRayCast.EnemyMoveRight);
        moves.Add(enemyLeftRayCast.EnemyMoveLeft);
        // Make sure the used moves list is empty.
        usedMoves.Clear();

        // Add methods to new list for random moves and random used moves
        randomMovesOrUsedMove.Add(EnemyRandomMove);
        randomMovesOrUsedMove.Add(EnemyRandomMoveAfterReset);
    }

    private void FixedUpdate()
    {
        // Check how many and which current moves are available for the enemy.
        //Debug.Log("Enemy Moves Available " + moves.Count);
        foreach (var move in moves)
        {
            var method = move.Method;
            //Debug.Log("Available move: " + method.Name);
        }
        // Check how many and which moves are in the used moves list.
        if (usedMoves != null)
        {
            //Debug.Log("Enemy Used Moves " + usedMoves.Count);

            foreach (var usedMove in usedMoves)
            {
                var usedMethod = usedMove.Method;
                //Debug.Log("Used Move: " + usedMethod.Name);
            }
        }

        // Check enemys current tile.
        enemyCurrentTileCheckRayCast.CheckEnemysCurrentTile();
        // Store current enemy position.
        EnemyLastTransformPosition();
        // Spawn a light up trail of where the enemy has been.
        InstantiateEnemyCubeTrail();

        // Enemy ai state machine
        switch (enemyState)
        {
            case EnemyAISM.phase1: // Phase one, enemy makes their first move to the second row.
                
                // Timer for delay of enemy moves. Makes the enemy feel like they are thinking about the next move.
                if (timer >= enemyMoveDelay)
                {
                    if (playerPhase.checkpoint2 == true)
                    {
                        // check if player has moved, if yes enemy can now make 1st move.
                        canMovePhase1 = true;
                        if (canMovePhase1 == true)
                        {
                            EnemyRandomMove(); // Call method to randomly move enemy.
                            enemyMadeFistMove = true; // Ref in enemy last transform position method.
                            canMovePhase1 = false; // Return the can move boolean to false.
                        }

                        enemyState = EnemyAISM.phase2; // Change current phase.
                    }
                    timer = 0f; // Reset timer to 0.
                }
                else timer += Time.deltaTime; // Increase timer until it goes past defined threshold.
                
                break;

            case EnemyAISM.phase2: // Enemy makes their 2nd move to the 3rd row.
                
                if (timer >= enemyMoveDelay)
                {
                    if (playerPhase.checkpoint3 == true)
                    {
                        canMovePhase2 = true;
                        // Check if enemy's moves have been reset. If false, just call the enemy random move method.
                        if (canMovePhase2 == true && enemyMovesReset == false)
                        {
                            EnemyRandomMove();
                            enemyMadeSecondMove =true;
                            canMovePhase2 = false;
                        }
                        // Check current phase is correct, then check if enemy has stepped on special tile,
                        // then check that there is one or more actions within the used moves list.
                        if (canMovePhase2 == true && enemyMovesReset == true && usedMoves.Count >= 1)
                        {
                            // Create a random index to randomly select a move called from either the moves or used moves lists.
                            int randomIndexForMethods = Random.Range(0, randomMovesOrUsedMove.Count);
                            // Use the random index to randomly call a move from the moves or used moves list.
                            randomMovesOrUsedMove[randomIndexForMethods].Invoke();
                            canMovePhase2 = false;
                        }

                        enemyState = EnemyAISM.phase3;
                    }
                    timer = 0f;
                } else timer += Time.deltaTime;

                
                break;

            case EnemyAISM.phase3: // Enemy makes their final move to the 4th row.

                if (timer >= enemyMoveDelay)
                {
                    if (playerPhase.checkpoint4 == true)
                    {
                        canMovePhase3 = true;
                        if (canMovePhase3 == true && enemyMovesReset == false)
                        {
                            EnemyRandomMove();
                            enemyMadeThridMove= true;
                            canMovePhase3 = false;
                        }

                        if (canMovePhase3 == true && enemyMovesReset == true && usedMoves.Count >= 1)
                        {
                            int randomIndexForMethods = Random.Range(0, randomMovesOrUsedMove.Count);
                            randomMovesOrUsedMove[randomIndexForMethods].Invoke();
                            canMovePhase3 = false;
                        }
                        enemyState = EnemyAISM.phase4;
                    }
                    timer = 0f;
                }
                else timer += Time.deltaTime;
                
                break;

            case EnemyAISM.phase4: // Enemy now on 4th row, then moves to battle phase.
                if (timer >= enemyMoveDelay)
                {
                    if (playerPhase.battlePhaseCheckPoint == true)
                    {
                        canMovePhase4 = true;
                        if (canMovePhase4 == true)
                        {
                            canMovePhase4 = false;
                        }
                        enemyState = EnemyAISM.battlePhase;
                    }
                    timer = 0f;
                }
                else timer += Time.deltaTime;

                
                break;

            case EnemyAISM.battlePhase: // Enemy battle phase conditions. 
                isBattlePhase = true;
                if (isBattlePhase == true)
                {
                    // move to enemy podium
                    enemyBattlePhaseRayCast.EnemyEnterBattlePhase();

                    // check what the current tile is for the battle phase to see who wins
                    gameManager.CallGameWinLoseDraw();
                }
                break;

            default:
                // Check if there is no state available
                Debug.Log(enemyState);
                break;
        }

       
    }

    public void EnemyOnSpecialTileEffect()
    {
        // Reset the enemy moves if they land on a special tile.
        //Debug.Log("Enemy moves reset");
        enemyMovesReset = true;
    }

    private void EnemyRandomMove()
    {
        // Generate a random index within the range of the list.
        int randomIndex = Random.Range(0, moves.Count);
        // Invoke the method at the random index.
        moves[randomIndex].Invoke();
        // Create a variable for the last used aciton.
        System.Action lastUsedActionInList = moves[randomIndex];
        // Move the last used action to new list of used moves.
        usedMoves.Add(lastUsedActionInList);
        // Remove the action used from the list.
        moves.RemoveAt(randomIndex); 
    }

    private void EnemyRandomMoveAfterReset()
    {
        // Generate a random index for the used moves.
        int randomIndexUsedMoves = Random.Range(0, usedMoves.Count);
        // Ivoke a method from the used moves list using the random index.
        usedMoves[randomIndexUsedMoves].Invoke();
        // Remove the random mehod when Invoked.
        usedMoves.RemoveAt(randomIndexUsedMoves);
    }

    public void EnemyLastTransformPosition()
    {
        // Get enemy current position and assign it to a new vector 3.
        Vector3 currentEnemyTransformPosition = transform.position;
        //Debug.Log("Current enemy pos " + currentEnemyTransformPosition);

        // Store Phase 1 pos into a new vector if it is currently empty.
        if (phase1PositionEmpty == true) 
        {
            enemyPhase1Location = currentEnemyTransformPosition;
            //Debug.Log("Phase 1 pos " + enemyPhase1Location);
            phase1PositionEmpty = false;    
        }
        
        if (enemyMadeFistMove == true && phase2PositionEmpty == true)
        {
            // Store vector for phase 2.
            enemyPhase2Location = currentEnemyTransformPosition;
            //Debug.Log("Phase 2 pos " + enemyPhase2Location);
            phase2PositionEmpty = false;
        }
        if (enemyMadeSecondMove == true && phase3PositionEmpty == true)
        {
            // Store vector for phase 3.
            enemyPhase3Location = currentEnemyTransformPosition;
            //Debug.Log("Phase 3 pos " + enemyPhase3Location);
            phase3PositionEmpty = false;
        }
        if (enemyMadeThridMove == true && phase4PositionEmpty == true)
        {
            // Store vector for phase 4.
            enemyPhase4Location = currentEnemyTransformPosition;
            //Debug.Log("Phase 4 pos " + enemyPhase4Location);
            phase4PositionEmpty = false;
        }
        
    }

    private void InstantiateEnemyCubeTrail()
    {
        // Hight offset to Instantiate light below enemy.
        Vector3 tileHeightOffset = new Vector3(0, -.5f, 0);

        // Check current state and then Instantiate trail cube on the previous phases location vector.
        if (enemyState == EnemyAISM.phase2 && phase1EnemyTrailInstantiated == false)
        {
            Instantiate(enemyTrailCube1, enemyPhase1Location + tileHeightOffset, Quaternion.identity);
            // Prevent multiple cubes being spawned.
            phase1EnemyTrailInstantiated= true;
        }

        if (enemyState == EnemyAISM.phase3 && phase2EnemyTrailInstantiated == false)
        {
            Instantiate(enemyTrailCube2, enemyPhase2Location + tileHeightOffset, Quaternion.identity);
            phase2EnemyTrailInstantiated= true;
        }

        if (enemyState == EnemyAISM.phase4 && phase3EnemyTrailInstantiated == false)
        {
            Instantiate(enemyTrailCube1, enemyPhase3Location + tileHeightOffset, Quaternion.identity);
            phase3EnemyTrailInstantiated= true;
        }

        if (enemyState == EnemyAISM.battlePhase && phase4EnemyTrailInstantiated == false)
        {
            Instantiate(enemyTrailCube2, enemyPhase4Location + tileHeightOffset, Quaternion.identity);
            phase4EnemyTrailInstantiated= true;
        }
    }

    
}
