using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float speed = 10f; // Speed of the object
    public float interval = 2f; // Time interval to move towards the player
    private bool isMoving = false;

    void Start()
    {
        // Start the movement coroutine
        StartCoroutine(MoveTowardsPlayerCoroutine());
    }

    private IEnumerator MoveTowardsPlayerCoroutine()
    {
        while (true)
        {
            // Wait for the specified interval
            // interval = Random.Range(10.0f, 15.0f);
            yield return new WaitForSeconds(interval);

            // Start moving towards the player
            isMoving = true;

            // Calculate direction to the player
            Vector3 direction = (player.position - transform.position).normalized;

            // Move the object towards the player
            while (isMoving)
            {
                transform.position += direction * speed * Time.deltaTime;

                // Check if the object is close enough to the player
                if (Vector3.Distance(transform.position, player.position) < 0.1f)
                {
                    isMoving = false; // Stop moving when close enough
                }

                yield return null; // Wait for the next frame
            }

            // Randomize the next interval
            interval = Random.Range(1f, 5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}