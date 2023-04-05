using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
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
        health = maxHealth;
    }
    public int TakePlayersHealthAfterLoss (int healthLost)
    {
        health -= healthLost;
        return health;
    }
}
