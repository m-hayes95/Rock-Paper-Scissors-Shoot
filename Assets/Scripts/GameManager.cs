using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // How many points player will recieve for a win or draw.
    private int winPointsRecieved = 1000;
    private int drawPointsRecieved = 500;
    private int healthLostOnPlayerLoss = 1;

    public float timer = 0f;
    private float waitTime = 0.5f;

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
        if (PlayerHealth.Instance.health <= 0)
        {
            OnPlayerDeath();
        }
    }

    // On Game win, lose or draw
    public void GamePlayerWin()
    {
        Debug.Log("Player Wins");
        // If player wins add winning points to the players current points, uisng Highscore manager singleton.
        HighScoreManager.Instance.AddToHighScore(winPointsRecieved);
        RestartLevel();

    }
    public void GameEnemyWin()
    {
        Debug.Log("Enemy Wins");
        // If enemy wins the round, take health from player using PlayerHealth singleton.
        PlayerHealth.Instance.TakePlayersHealthAfterLoss(healthLostOnPlayerLoss);
        RestartLevel();
    }
    public void GameDraw()
    {
        Debug.Log("Draw");
        // If player draws add drawing points to the players current points, uisng Highscore manager singleton.
        HighScoreManager.Instance.AddToHighScore(drawPointsRecieved);
        RestartLevel();
    }

    private void OnPlayerDeath()
    {
        Debug.Log("The Player Died! :'(");
    }

    private void RestartLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        int randomScenePicker = Random.Range(0, 2);
        SceneManager.LoadScene(randomScenePicker);
    }

    /*
     * if (timer >= waitTime)
        {
            RestartLevel();
            timer = 0f;
        }
        else timer += Time.deltaTime;
    */


}
