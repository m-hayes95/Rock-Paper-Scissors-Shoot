using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool PlayerIsDead = false;

    [SerializeField] private PlayerSpawner playerSpawner;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private TileManager tileManager;
    [SerializeField] private NewHeartsVisual newHeartsVisual;
    [SerializeField] private UIManager uiManager;



    // How many points player will recieve for a win or draw.
    private int winPointsRecieved = 1000;
    private int drawPointsRecieved = 500;
    private int healthLostOnPlayerLoss = 1;


    // Need this to stop high score being inputted more than once on win.
    public bool isGameOverCalled = false;

    private void Start()
    {
        // Set player is dead to false on new start.
        PlayerIsDead = false;
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
            
        }
        
        // Call on player death method, when player health reaches or falls below 0.
        if (PlayerHealth.Instance.health <= 0 && PlayerIsDead == false)
        {
            PlayerIsDead = true;
            // Destroy player hearts singleton when player dies.
            newHeartsVisual.noHeartsLeft = true;
            OnPlayerDeath();
        }

        
    }

    private IEnumerator CountSeconds() // Add a coutdown / timer before a function is called.
    {
        //Debug.Log( " second(s) have passed");
        yield return new WaitForSeconds(2f);
        MoveToNextLevel();

    }

    // On Game win, lose or draw
    public void GamePlayerWin()
    {
        //Debug.Log("Player Wins");
        
        uiManager.gameWon = true; // Show banner on round over.
        GameplayMusic.Insatance.PlayCrowdCheerSound();
        //Debug.Log(uiManager.gameWon
        HighScoreManager.Instance.AddToHighScore(winPointsRecieved); // Add points to players current points.
        playerSpawner.PlayerSpawnerOnNextLevel();
        enemySpawner.EnemySpawnerOnNextLevel();
        StartCoroutine(CountSeconds());
        

    }
    public void GameEnemyWin()
    {
        //Debug.Log("Enemy Wins");
        
        uiManager.gameLost = true;
        GameplayMusic.Insatance.PlayCrowdGaspSound();
        //Debug.Log(uiManager.gameLost);
        // On lose, take health from player.
        PlayerHealth.Instance.TakePlayersHealthAfterLoss(healthLostOnPlayerLoss);
        playerSpawner.PlayerSpawnerOnNextLevel();
        enemySpawner.EnemySpawnerOnNextLevel();
        StartCoroutine(CountSeconds());
       
    }
    public void GameDraw()
    {
        //Debug.Log("Draw");
        
        uiManager.gameDraw = true;
        GameplayMusic.Insatance.PlayCrowdCheerSound();
        //Debug.Log(uiManager.gameDraw
        HighScoreManager.Instance.AddToHighScore(drawPointsRecieved);
        playerSpawner.PlayerSpawnerOnNextLevel();
        enemySpawner.EnemySpawnerOnNextLevel();
        StartCoroutine(CountSeconds());
        
    }

    private void OnPlayerDeath()
    {
        //Debug.Log("The Player Died! 
        // Go to game over screen.
        int gameOverSceneIndexRef = 2;
        SceneManager.LoadScene(gameOverSceneIndexRef);
    }

    private void MoveToNextLevel()
    {
        //Reload scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
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
            GameplayMusic.Insatance.PlayRockSound();
            isGameOverCalled = true;
        }
        if (tileManager.playerPaper && tileManager.enemyRock == true && isGameOverCalled == false)
        {
            GamePlayerWin();
            GameplayMusic.Insatance.PlayPaperSound();
            isGameOverCalled = true;
        }
        if (tileManager.playerScissors && tileManager.enemyPaper == true && isGameOverCalled == false)
        {
            GamePlayerWin();
            GameplayMusic.Insatance.PlayScissorsSound();
            isGameOverCalled = true;
        }
        //Enemy wins
        if (tileManager.playerRock && tileManager.enemyPaper == true && isGameOverCalled == false)
        {
            GameEnemyWin();
            GameplayMusic.Insatance.PlayRockSound();
            isGameOverCalled = true;
        }
        if (tileManager.playerPaper && tileManager.enemyScissors == true && isGameOverCalled == false)
        {
            GameEnemyWin();
            GameplayMusic.Insatance.PlayPaperSound();
            isGameOverCalled = true;
        }
        if (tileManager.playerScissors && tileManager.enemyRock == true && isGameOverCalled == false)
        {
            GameEnemyWin();
            GameplayMusic.Insatance.PlayScissorsSound();
            isGameOverCalled = true;
        }
        //Draws
        if (tileManager.playerRock && tileManager.enemyRock == true && isGameOverCalled == false)
        {
            GameDraw();
            GameplayMusic.Insatance.PlayRockSound();
            isGameOverCalled = true;
        }
        if (tileManager.playerPaper && tileManager.enemyPaper == true && isGameOverCalled == false)
        {
            GameDraw();
            GameplayMusic.Insatance.PlayPaperSound();
            isGameOverCalled = true;
        }
        if (tileManager.playerScissors && tileManager.enemyScissors == true && isGameOverCalled == false)
        {
            GameDraw();
            GameplayMusic.Insatance.PlayScissorsSound();
            isGameOverCalled = true;
        }
    }
    


}
