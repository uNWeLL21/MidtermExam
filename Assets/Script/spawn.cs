using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class spawn : MonoBehaviour
{
    /*public GameObject[] gameObjects; // Array of game objects to activate sequentially
    private int currentIndex = 0;
    public TextMeshProUGUI destroyedCountText; // Reference to the TextMeshProUGUI component
    private int destroyedCount = 0;

    private void Start()
    {
        // Deactivate all objects initially
        foreach (GameObject obj in gameObjects)
        {
            obj.SetActive(false);
        }

        // Activate the first object if it exists
        if (gameObjects.Length > 0)
        {
            ActivateObject(currentIndex);
        }

        // Initialize the destroyed count text
        UpdateDestroyedCountText();
    }

    void ActivateObject(int index)
    {
        if (index >= 0 && index < gameObjects.Length)
        {
            gameObjects[index].SetActive(true);
            // Subscribe to the object's destruction event
            DestroyHandler destroyHandler = gameObjects[index].AddComponent<DestroyHandler>();
            destroyHandler.OnDestroyed += HandleObjectDestroyed;
        }
    }

    void HandleObjectDestroyed()
    {
       
        UpdateDestroyedCountText(); // Update the text display

        currentIndex++; // Move to the next object in the array

        if (currentIndex < gameObjects.Length)
        {
            ActivateObject(currentIndex); // Activate the next object
        }
    }

    void UpdateDestroyedCountText()
    {
        // Update the TextMeshProUGUI with the current count of destroyed objects
        if (destroyedCountText != null)
        {
            //*destroyedCountText.text = "" + DestroyerHandler.totalDestroyedCount;
        }
    }
}

/*public class DestroyHandler : MonoBehaviour
{
    public delegate void Destroyed();
    public event Destroyed OnDestroyed;
    public static int totalDestroyedCount = 0;
    private void OnDestroy()
    {
        totalDestroyedCount++;
        OnDestroyed?.Invoke(); // Trigger the event when the object is destroyed
    }*/
}
