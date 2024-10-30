using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] gameObjectsSequential; // Array for sequential activation
    public GameObject[] gameObjectsSpawn; // Array for interval-based spawning
    public float spawnInterval = 3f;
    public GameObject specialObject;// Time interval between spawns
    public GameObject Player;

    private int currentIndexSequential = 0; // Index for sequential activation
    private int currentIndexSpawn = 0; // Index for interval-based spawning
    public TextMeshProUGUI destroyedCountText; // Reference to the TextMeshProUGUI component

    private void Start()
    {
        // Reset the destroyed count on scene load
        ResetDestroyedCount();

        // Deactivate all sequential objects initially
        foreach (GameObject obj in gameObjectsSequential)
        {
            obj.SetActive(false);
        }

        // Activate the first object if it exists
        if (gameObjectsSequential.Length > 0)
        {
            ActivateSequentialObject(currentIndexSequential);
        }

        // Start the coroutine for interval-based spawning
        StartCoroutine(SpawnObjectsWithInterval());

        // Initialize the destroyed count text
        UpdateDestroyedCountText();

        // Ensure the special object is initially inactive
        if (specialObject != null)
        {
            specialObject.SetActive(false);
        }
     
    }

    // Method to reset the destroyed count
    private void ResetDestroyedCount()
    {
        DestroyHandler.totalDestroyedCount = 0;
    }


    void ActivateSequentialObject(int index)
    {
        if (index >= 0 && index < gameObjectsSequential.Length)
        {
            gameObjectsSequential[index].SetActive(true);
            // Add and subscribe to the DestroyHandler
            DestroyHandler destroyHandler = gameObjectsSequential[index].AddComponent<DestroyHandler>();
            destroyHandler.OnDestroyed += HandleObjectDestroyed;
        }
    }

    private IEnumerator SpawnObjectsWithInterval()
    {
        while (currentIndexSpawn < gameObjectsSpawn.Length)
        {
            SpawnObject(currentIndexSpawn);
            currentIndexSpawn++; // Move to the next object index
            yield return new WaitForSeconds(spawnInterval); // Wait for the spawn interval
        }
    }

    private void SpawnObject(int index)
    {
        if (index >= 0 && index < gameObjectsSpawn.Length)
        {
            Vector3 spawnPosition = gameObjectsSpawn[index].transform.position;
            GameObject obj = Instantiate(gameObjectsSpawn[index], spawnPosition, Quaternion.identity);
            obj.SetActive(true);

            // Add and subscribe to DestroyHandler
            DestroyHandler destroyHandler = obj.AddComponent<DestroyHandler>();
            destroyHandler.OnDestroyed += HandleObjectDestroyed;
        }
    }

    void HandleObjectDestroyed()
    {
        UpdateDestroyedCountText(); // Update the text display

        currentIndexSequential++; // Move to the next sequential object
        if (currentIndexSequential < gameObjectsSequential.Length)
        {
            ActivateSequentialObject(currentIndexSequential); // Activate the next sequential object
        }
    }

    void UpdateDestroyedCountText()
    {
        if (destroyedCountText != null)
        {
            destroyedCountText.text = "" + DestroyHandler.totalDestroyedCount;
        }

        // Check if the count has reached 15
        if (DestroyHandler.totalDestroyedCount >= 15)
        {
                specialObject.SetActive(true);
                 Player.SetActive(false);


        }
    }
}

public class DestroyHandler : MonoBehaviour
{
    public delegate void Destroyed();
    public event Destroyed OnDestroyed;
    public static int totalDestroyedCount = 0;

    private void OnDestroy()
    {
        totalDestroyedCount++;
        OnDestroyed?.Invoke(); // Trigger the event when the object is destroyed
    }





    /*public GameObject[] gameObjects; // Array of game objects to spawn
    public float spawnInterval = 3f; // Time interval between spawns
    private int currentIndex = 0; // Index of the next object to spawn

    public TextMeshProUGUI destroyedCountText; // Reference to the TextMeshProUGUI component
    private int destroyedCount = 0; // Counter for destroyed objects

    private void Start()
    {
        StartCoroutine(SpawnObjects()); // Start the spawning coroutine
        UpdateDestroyedCountText(); // Initialize the text display
    }

    private IEnumerator SpawnObjects()
    {
        while (currentIndex < gameObjects.Length)
        {
            SpawnObject(currentIndex); // Spawn the current object
            currentIndex++; // Move to the next object index

            // Wait for the specified spawn interval
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnObject(int index)
    {
        if (index >= 0 && index < gameObjects.Length)
        {
            // Instantiate the object at its original position (set in the prefab)
            Vector3 spawnPosition = gameObjects[index].transform.position; // Get original position from prefab
            GameObject obj = Instantiate(gameObjects[index], spawnPosition, Quaternion.identity);
            // Set the object to active
            obj.SetActive(true);

            // Debug log to confirm spawning
            Debug.Log("Spawning object: " + gameObjects[index].name + " at position: " + spawnPosition);

            // Add DestroyHandler to the spawned object
            DestroyerHandler destroyHandler = obj.AddComponent<DestroyerHandler>();
            destroyHandler.OnDestroyed += HandleObjectDestroyed; // Subscribe to the OnDestroyed event
        }
    }

    void HandleObjectDestroyed()
    { 
        UpdateDestroyedCountText(); // Update the text display
    }

    void UpdateDestroyedCountText()
    {
        // Update the TextMeshProUGUI with the current count of destroyed objects
        if (destroyedCountText != null)
        {
            destroyedCountText.text = "" + DestroyerHandler.totalDestroyedCount;
        }
    }
}

public class DestroyerHandler : MonoBehaviour
{
    public delegate void Destroyed();
    public event Destroyed OnDestroyed;

    // Static variable to keep track of total destroyed objects
    public static int totalDestroyedCount = 0;


    private void OnDestroy()
    {
        totalDestroyedCount++;
        OnDestroyed?.Invoke(); // Trigger the event when the object is destroyed
    }*/
}
