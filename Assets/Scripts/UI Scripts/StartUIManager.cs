using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class StartUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenuFirstButton, howToPlayMenuFirstButton, optionsMenuFirstButton;

    private void Start()
    {
        SelectMainMenuFirstButton();
    }
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

    public void SelectMainMenuFirstButton()
    {
        EventSystem.current.SetSelectedGameObject(mainMenuFirstButton);
    }

    public void SelectHowToPlayMenuFirstButton()
    {
        EventSystem.current.SetSelectedGameObject(howToPlayMenuFirstButton);
    }
    public void SelectOptionsMenuFirstButton()
    {
        EventSystem.current.SetSelectedGameObject(optionsMenuFirstButton);
    }
}
