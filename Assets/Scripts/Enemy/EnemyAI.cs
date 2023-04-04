using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Ref to phase & tile & game manager and ray cast scripts
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

    // Check if enemy can move this turn
    [SerializeField] private bool canMovePhase1 = false, canMovePhase2 = false, canMovePhase3 = false, canMovePhase4 = false, isBattlePhase = false;

    // Define a list for potential moves
    private List<System.Action> moves = new List<System.Action>();
    // Define a list for moves that have been used
    private List<System.Action> usedMoves = new List<System.Action> ();
    // Define a list containing the two methods that can be used to randomly move the enemy,
    // before and after a special tile reset.
    private List<System.Action> randomMovesOrUsedMove = new List<System.Action>();
    [SerializeField]
    private bool enemyMovesReset = false;

    // Statemachine for enemy ai phases
    public enum EnemyAISM { phase1, phase2, phase3, phase4, battlePhase }
    public EnemyAISM enemyState;

    private const string PLAYER = "Player";
    private const string TILE_MANAGER_TAG = "TileManagerTag";

   
    private void Start()
    {
        // Assign Phase and Tile manger scripts.
        _playerPhase = GameObject.FindGameObjectWithTag(PLAYER);
        playerPhase = _playerPhase.GetComponent<PlayerPhase>();
        _tileManager = GameObject.FindGameObjectWithTag(TILE_MANAGER_TAG);
        tileManager = _tileManager.GetComponent<TileManager>();

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

    private void Update()
    {
        // Check how many and which current moves are available for the enemy.
        Debug.Log("Enemy Moves Available " + moves.Count);
        foreach (var move in moves)
        {
            var method = move.Method;
            Debug.Log("Available move: " + method.Name);
        }
        // Check how many and which moves are in the used moves list.
        if (usedMoves != null)
        {
            Debug.Log("Enemy Used Moves " + usedMoves.Count);

            foreach (var usedMove in usedMoves)
            {
                var usedMethod = usedMove.Method;
                Debug.Log("Used Move: " + usedMethod.Name);
            }
        }

        // Check enemys current tile]
        enemyCurrentTileCheckRayCast.CheckEnemysCurrentTile();

        // Enemy ai state machine
        switch (enemyState)
        {
            case EnemyAISM.phase1: // Phase one, enemy makes their first move to the second row.
                
                if (playerPhase.checkpoint2 == true)
                {
                    // check if player has moved, if yes enemy can now make 1st move.
                    canMovePhase1 = true;
                    if (canMovePhase1 == true)
                    {
                        EnemyRandomMove(); // Call method to randomly move enemy.

                        canMovePhase1 = false; // Return the can move boolean to false.
                    }

                    enemyState = EnemyAISM.phase2; // Change current phase.
                }
                break;

            case EnemyAISM.phase2: // Enemy makes their 2nd move to the 3rd row.
                
                if (playerPhase.checkpoint3 == true)
                {
                    canMovePhase2 = true;
                    // Check if enemy's moves have been reset. If false, just call the enemy random move method.
                    if (canMovePhase2 == true && enemyMovesReset == false)
                    {
                        EnemyRandomMove();
                        canMovePhase2 = false;
                    }
                    // If check is true...
                    if (canMovePhase2 == true && enemyMovesReset == true)
                    {
                        // Create a random index to randomly select a move called from either the moves or used moves lists.
                        int randomIndexForMethods = Random.Range(0, randomMovesOrUsedMove.Count);
                        // Use the random index to randomly call a move from the moves or used moves list.
                        randomMovesOrUsedMove[randomIndexForMethods].Invoke();
                        canMovePhase2 = false;
                    }
                       
                    enemyState = EnemyAISM.phase3;
                }
                break;

            case EnemyAISM.phase3: // Enemy makes their final move to the 4th row.
                

                if (playerPhase.checkpoint4 == true)
                {
                    canMovePhase3 = true;
                    if (canMovePhase3 == true && enemyMovesReset == false)
                    {
                        EnemyRandomMove();
                        canMovePhase3 = false;
                    }

                    if (canMovePhase3 == true && enemyMovesReset == true)
                    {
                        int randomIndexForMethods = Random.Range(0, randomMovesOrUsedMove.Count);
                        randomMovesOrUsedMove[randomIndexForMethods].Invoke();
                        canMovePhase3 = false;
                    }
                    enemyState = EnemyAISM.phase4;
                }
                break;

            case EnemyAISM.phase4: // Enemy now on 4th row, then moves to battle phase.
            
                if (playerPhase.battlePhaseCheckPoint == true)
                {
                    canMovePhase4 = true;
                    if (canMovePhase4 == true)
                    {
                        canMovePhase4 = false;
                    }
                    enemyState = EnemyAISM.battlePhase;
                }
                break;

            case EnemyAISM.battlePhase: // Enemy battle phase conditions. 
                isBattlePhase = true;
                if (isBattlePhase == true)
                {
                    // move to enemy podium
                    enemyBattlePhaseRayCast.EnemyEnterBattlePhase();

                    // check what the current tile is for the battle phase to see who wins
                    CallGameWinLoseDraw();
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
        Debug.Log("Enemy moves reset");
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

    private void CallGameWinLoseDraw()
    {
        //Player Wins
        if (tileManager.playerRock && tileManager.enemyScissors == true)
        {
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
}
