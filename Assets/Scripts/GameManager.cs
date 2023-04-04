using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // How many points player will recieve for a win or draw.
    private int winPointsRecieved = 1000;
    private int drawPointsRecieved = 500;

    public float timer = 0f;
    private float waitTime = 0.5f;

    private void Update()
    {
        // Debug Test, add to high score on input.
        if (Input.GetKeyDown(KeyCode.M))
        {
            HighScoreManager.Instance.AddToHighScore(2000);
        }

        
    }

    // On Game win, lose or draw
    public void GamePlayerWin()
    {
        Debug.Log("Player Wins");
        HighScoreManager.Instance.AddToHighScore(1000);
        RestartLevel();

    }
    public void GameEnemyWin()
    {
        Debug.Log("Enemy Wins");
        RestartLevel();
    }
    public void GameDraw()
    {
        Debug.Log("Draw");
        HighScoreManager.Instance.AddToHighScore(500);
        RestartLevel();
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
