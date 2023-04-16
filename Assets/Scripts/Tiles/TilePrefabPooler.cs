using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

// Reference: "OBJECT POOLING in Unity" by Brackeys
// https://www.youtube.com/watch?v=tdSmKaJvCoA&t=6s

public class TilePrefabPooler : MonoBehaviour
{
    // Editable in inspector class with multiple components that is inputed into a list.
    [System.Serializable]
    public class TilePrefabPool
    {
        public string tag; // Name of pool.
        public GameObject tilePrefab; // Which Prefab is stored in this pool.
        public int amount; // How many prefabs are stored in this pool.
    }

    // Turn class into a singleton pattern so it can be easily accessed elsewhere.
    #region Singleton pattern

    public static TilePrefabPooler Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public List<TilePrefabPool> tilePrefabPools; // List of each Tile Prefab Pool created.
    public Dictionary<string, Queue<GameObject>> tilePrefabPoolDictionary; // Dictionary holding all tile prefab pools inside.

    private void Start()
    {
        // Instantiate the dictionary to store all pools inside.
        tilePrefabPoolDictionary= new Dictionary<string, Queue<GameObject>>();
        // Add each pool to the dictionary using a for each loop.
        foreach (TilePrefabPool _tilePrefabPool in tilePrefabPools)
        {
            // Create a list of instantiated game objects (tile prefabs), that will be contained within the tile prefab pool list.
            Queue<GameObject> tilePrefabs = new Queue<GameObject>();

            // Instantiate each prefab within the tile prefab list using a for loop, set to the amount set within the TilePrefabPool class.
            for (int i = 0; i < _tilePrefabPool.amount; i++)
            {
                // Store the instantiated game object into a variable.
                GameObject obj = Instantiate(_tilePrefabPool.tilePrefab);
                // Set the instantiated game object to inactive within the scene.
                obj.SetActive(false);
                // Store the new game object into the Tile Prefabs list.
                tilePrefabs.Enqueue(obj);
            }
            // Add new tile prefab list to the dictionary.
            tilePrefabPoolDictionary.Add(_tilePrefabPool.tag, tilePrefabs);
        }
    }

    public GameObject SpawnTilePrefabFromPool (string tag, Vector3 position, Quaternion rotation)
    {
        // Give an error if a pool with an incorrect tag attempts to call this method.
        if (!tilePrefabPoolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist");
            return null;
        }

        // Remove the in active instantiated game object from the dictionary, and assign it to a new game object.
        GameObject tileToSpawn = tilePrefabPoolDictionary[tag].Dequeue();
        // Set the game object to active.
        tileToSpawn.SetActive(true);
        // Set the position and rotation inputted parameters.
        tileToSpawn.transform.position = position;
        tileToSpawn.transform.rotation = rotation;
        // After the game object has been set to activate, place it back into the dictionary.
        tilePrefabPoolDictionary[tag].Enqueue(tileToSpawn);
        
        return tileToSpawn;
    }
}
