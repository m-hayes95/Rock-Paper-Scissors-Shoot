using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class StartUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenuFirstButton, howToPlayMenuFirstButton, optionsMenuFirstButton, tutorialMenuFirstButton;
    [SerializeField] 
    private GameObject buttonCard1, buttonCard2, buttonCard3, buttonCard4, buttonCard5, buttonCard6, buttonCard7, buttonCard8, buttonCard9, buttonCard10;

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
    // Select first button in menus for controller.
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
    public void SelectTutorialMenuFirstButton()
    {
        EventSystem.current.SetSelectedGameObject(tutorialMenuFirstButton);
    }

    // Choose first button on new card with gamepad.
    public void GoToCard1() 
    {
        EventSystem.current.SetSelectedGameObject(buttonCard1);
    }
    public void GoToCard2()
    {
        EventSystem.current.SetSelectedGameObject(buttonCard2);
    }
    public void GoToCard3()
    {
        EventSystem.current.SetSelectedGameObject(buttonCard3);
    }
    public void GoToCard4()
    {
        EventSystem.current.SetSelectedGameObject(buttonCard4);
    }
    public void GoToCard5()
    {
        EventSystem.current.SetSelectedGameObject(buttonCard5);
    }
    public void GoToCard6()
    {
        EventSystem.current.SetSelectedGameObject(buttonCard6);
    }
    public void GoToCard7()
    {
        EventSystem.current.SetSelectedGameObject(buttonCard7);
    }
    public void GoToCard8()
    {
        EventSystem.current.SetSelectedGameObject(buttonCard8);
    }
    public void GoToCard9()
    {
        EventSystem.current.SetSelectedGameObject(buttonCard9);
    }
    public void GoToCard10()
    {
        EventSystem.current.SetSelectedGameObject(buttonCard10);
    }
}
