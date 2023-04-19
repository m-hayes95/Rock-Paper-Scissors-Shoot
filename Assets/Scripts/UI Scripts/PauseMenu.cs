using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    private PlayerInputActions playerInputActions;

    private void Awake()
    { 

        //Enable controller & subscribe to pause action on performed.
        playerInputActions = new PlayerInputActions();
        //playerInputActions.Menu.Enable();
        // Ignore action context (Ref Brackeys "CONTROLLER INPUT in Unity!" @ https://www.youtube.com/watch?v=p-3S73MaDP8)
        playerInputActions.Menu.PauseGame.performed += ctx => Pause();
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
         // Stop time with time scale.
         Time.timeScale = 0f;
         GameIsPaused = true; 
    }

    public void LoadMenu()
    {
        //Debug.Log("Loading Menu...");
        SceneManager.LoadScene(0);
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

