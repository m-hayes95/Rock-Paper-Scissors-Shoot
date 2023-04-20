using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    private PlayerInputActions playerInputActions;

    [SerializeField]
    private GameObject pauseMenuFirstButton, howToPlayMenuFirstButton, optionsMenuFirstButton, quitMenuFirstButton;
    [SerializeField]
    private GameObject buttonCard1, buttonCard2, buttonCard3, buttonCard4, buttonCard5, buttonCard6, buttonCard7, buttonCard8, buttonCard9, buttonCard10;

    private void Awake()
    { 

        //Enable controller & subscribe to pause action on performed.
        playerInputActions = new PlayerInputActions();
        // Ignore action context (Ref Brackeys "CONTROLLER INPUT in Unity!" @ https://www.youtube.com/watch?v=p-3S73MaDP8)
        playerInputActions.Menu.PauseGame.performed += ctx => Pause();
        playerInputActions.Menu.ResumeGame.performed += ctx => Resume();
    }

    private void Update()
    {
        //Debug.Log("Game is paused = " + GameIsPaused);
    }

    public void Resume()
    {
        //Debug.Log("Resume " + context);
        pauseMenuUI.SetActive(false);
        // Set time scale to default.
        Time.timeScale = 1f;
        GameIsPaused = false;

    }
    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        EventSystem.current.SetSelectedGameObject(pauseMenuFirstButton);
        // Stop time with time scale.
        Time.timeScale = 0f;
        GameIsPaused = true; 
    }

    public void LoadMenu()
    {
        //Debug.Log("Loading Menu...");
        GameManager.PlayerIsDead = true;
        SceneManager.LoadScene(0);
    }
    // Used to select the first option of a menu when called.
    public void PauseToHowToPlayMenu()
    {
        EventSystem.current.SetSelectedGameObject(howToPlayMenuFirstButton);
    }
    public void PauseToOptionsMenu()
    {
        EventSystem.current.SetSelectedGameObject(optionsMenuFirstButton);
    }
    public void PauseToQuitGameMenu()
    {
        EventSystem.current.SetSelectedGameObject(quitMenuFirstButton);
    }
    public void ReturnToPauseMenu() // Used when returning to pause menu from another menu.
    {
        EventSystem.current.SetSelectedGameObject(pauseMenuFirstButton);
    }
    public void PauseQuitGame()
    {
        Application.Quit();
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

    private void OnEnable()
    {
        playerInputActions.Menu.Enable();
    }
    private void OnDisable()
    {
        playerInputActions.Menu.Disable();
    }
}

