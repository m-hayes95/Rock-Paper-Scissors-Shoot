using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoreManager : MonoBehaviour
{
    // Create a singleton to manage players current high score

    // Allow other scripts to read but not edit this Instance.
    public static HighScoreManager Instance { get; private set; }
    
    // Define a variable of int datatype to manage player's current high score.
    public int playersHighScore = 0;
    public bool gameHasReset = false;

   
    private void Awake()
    {
        if (Instance == null) // Check if there is an instance already.
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Dont destroy game object when new scene loads.

        }
        else
        {
            Destroy(gameObject); // Don't allow 2 High Score singletons.
        }
    }

    private void Update()
    {
        // If game resets, destroy high score object.
        if (gameHasReset == true)
        {
            Destroy(gameObject);
        }
    }
    public int AddToHighScore (int addedScore)
    {
        // Take current high score and add a score value.
        playersHighScore += addedScore;
        // Return the new high score value as an integer.
        return playersHighScore;
    }

   
}
