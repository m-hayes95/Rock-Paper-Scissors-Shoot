using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorDistance : MonoBehaviour
{
    // Create a Singleton pattern to calculate the vector distance of 2 game objects.
    public static VectorDistance Instance { get; private set; } // Allow other scripts to read but not edit this Instance.

    private void Awake()
    {
        if (Instance == null) // Check if there is an instance already.
        {
            Instance = this;
        } 
        else
        {
            Destroy(gameObject); // Don't allow 2 Vector Distances.
        }
    }
    // Input 2 transform positions as vector3.
    public float CalculateVectorDistance (Vector3 position1, Vector3 position2)
    {
        // Calcuate the distance between the 2 vector positions.
        float calculatedVectorDistance = Vector3.Distance(position1, position2);
        // Return the value as a float.
        return calculatedVectorDistance;
    }
}
