using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    // On Game win, lose or draw
    public void GamePlayerWin()
    {
        Debug.Log("Player Wins");
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
        RestartLevel();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }



}
