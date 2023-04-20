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

    private void OnEnable()
    {
        playerInputActions.Menu.Enable();
    }
    private void OnDisable()
    {
        playerInputActions.Menu.Disable();
    }
}

