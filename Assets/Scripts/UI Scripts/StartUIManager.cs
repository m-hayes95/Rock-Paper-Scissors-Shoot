using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUIManager : MonoBehaviour
{

    public void StartGame()
    {
        // Start the game.
        Debug.Log("Start Game");
        SceneManager.LoadScene(1);
    }

    public void QuitApplication()
    {
        // Quit the application.
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
