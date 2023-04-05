using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Singleton called in game manager script, to reduce health of player when they lose a round.
    public static PlayerHealth Instance { get; private set; }
    private int maxHealth = 3;
    public int health;

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
    private void Start()
    {
        health = maxHealth; // Set the players starting Hp to the max hp value.
    }
    public int TakePlayersHealthAfterLoss (int healthLost)
    {
        health -= healthLost; // Reduce health by an incominng int value.
        return health; // Return the updated health value as an int value.
    }
}
