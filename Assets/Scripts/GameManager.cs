using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerSpawner playerSpawner;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private TileManager tileManager;
    [SerializeField] private NewHeartsVisual heartsVisual;


    // How many points player will recieve for a win or draw.
    private int winPointsRecieved = 1000;
    private int drawPointsRecieved = 500;
    private int healthLostOnPlayerLoss = 1;

    

    public bool playerIsDead = false;
    // Need this to stop high score being inputted more than once on win.
    private bool isGameOverCalled = false;

    private void Start()
    {
        // Set player is dead to false on new start.
        playerIsDead = false;
    }
    private void Update()
    {
        
        // Debug Test, add to high score on input.
        if (Input.GetKeyDown(KeyCode.M))
        {
            HighScoreManager.Instance.AddToHighScore(2000);
        }
        // Debug Test, remove 1 hp from player's current health.
        if (Input.GetKeyDown(KeyCode.H))
        {
            PlayerHealth.Instance.TakePlayersHealthAfterLoss(healthLostOnPlayerLoss);
            heartsVisual.PlayerTakenDamage();
        }
        // Call on player death method, when player health reaches or falls below 0.
        if (PlayerHealth.Instance.health <= 0 && playerIsDead == false)
        {
            playerIsDead=true;
            OnPlayerDeath();
        }

        
    }

    // On Game win, lose or draw
    public void GamePlayerWin()
    {
        Debug.Log("Player Wins");
        // If player wins add winning points to the players current points, uisng Highscore manager singleton.
        HighScoreManager.Instance.AddToHighScore(winPointsRecieved);
        playerSpawner.PlayerSpawnerOnNextLevel();
        enemySpawner.EnemySpawnerOnNextLevel();
        MoveToNextLevel();

    }
    public void GameEnemyWin()
    {
        Debug.Log("Enemy Wins");
        // If enemy wins the round, take health from player using PlayerHealth singleton.
        PlayerHealth.Instance.TakePlayersHealthAfterLoss(healthLostOnPlayerLoss);
        // Remove 1 heart from player hearts UI.
        heartsVisual.PlayerTakenDamage();
        playerSpawner.PlayerSpawnerOnNextLevel();
        enemySpawner.EnemySpawnerOnNextLevel();
        MoveToNextLevel();
    }
    public void GameDraw()
    {
        Debug.Log("Draw");
        // If player draws add drawing points to the players current points, uisng Highscore manager singleton.
        HighScoreManager.Instance.AddToHighScore(drawPointsRecieved);
        playerSpawner.PlayerSpawnerOnNextLevel();
        enemySpawner.EnemySpawnerOnNextLevel();
        MoveToNextLevel();
    }

    private void OnPlayerDeath()
    {
        Debug.Log("The Player Died! :'(");
        
        SceneManager.LoadScene(3);
    }

    private void MoveToNextLevel()
    {
        
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        int randomScenePicker = Random.Range(1, 3);
        SceneManager.LoadScene(randomScenePicker);
    }

    private void ResetScriptBoolOnNewScene()
    {
        // Reset bools here for new loaded scene.
    }

    public void CallGameWinLoseDraw()
    {
        // Check player current tile and enemy current tile using tile manager script.
        // Then check if the game over method has been run before before calling nested code.
        //Player Wins
        if (tileManager.playerRock && tileManager.enemyScissors == true && isGameOverCalled == false)
        {
            GamePlayerWin();
            isGameOverCalled = true;
        }
        if (tileManager.playerPaper && tileManager.enemyRock == true && isGameOverCalled == false)
        {
            GamePlayerWin();
            isGameOverCalled = true;
        }
        if (tileManager.playerScissors && tileManager.enemyPaper == true && isGameOverCalled == false)
        {
            GamePlayerWin();
            isGameOverCalled = true;
        }
        //Enemy wins
        if (tileManager.playerRock && tileManager.enemyPaper == true && isGameOverCalled == false)
        {
            GameEnemyWin();
            isGameOverCalled = true;
        }
        if (tileManager.playerPaper && tileManager.enemyScissors == true && isGameOverCalled == false)
        {
            GameEnemyWin();
            isGameOverCalled = true;
        }
        if (tileManager.playerScissors && tileManager.enemyRock == true && isGameOverCalled == false)
        {
            GameEnemyWin();
            isGameOverCalled = true;
        }
        //Draws
        if (tileManager.playerRock && tileManager.enemyRock == true && isGameOverCalled == false)
        {
            GameDraw();
            isGameOverCalled = true;
        }
        if (tileManager.playerPaper && tileManager.enemyPaper == true && isGameOverCalled == false)
        {
            GameDraw();
            isGameOverCalled = true;
        }
        if (tileManager.playerScissors && tileManager.enemyScissors == true && isGameOverCalled == false)
        {
            GameDraw();
            isGameOverCalled = true;
        }
    }
    /*
     * 
     //public float timer = 0f;
     //private float waitTime = 0.5f;
     * if (timer >= waitTime)
        {
            RestartLevel();
            timer = 0f;
        }
        else timer += Time.deltaTime;
    */


}
