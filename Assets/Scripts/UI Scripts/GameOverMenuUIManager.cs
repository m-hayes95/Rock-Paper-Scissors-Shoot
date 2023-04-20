using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverMenuUIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI endGameHighScore;

    private void Update()
    {
        // Display players current high score.
        endGameHighScore.text = HighScoreManager.Instance.playersHighScore.ToString();
    }
    public void GoToStartMenu()
    {
        // Destroy high score when player goes back to start menu.
        HighScoreManager.Instance.gameHasResetHighScore = true;
        SceneManager.LoadScene(0);
    }

    public void GameOverMenuQuitGame()
    {
        Debug.Log("Quit Game");
        // Destroy high score when player quits game.
        GameManager.PlayerIsDead = true;

        Application.Quit();
    }
}
