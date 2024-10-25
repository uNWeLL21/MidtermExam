using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownBlade : MonoBehaviour
{
    void Start()
    {
        if(down){
            StartCoroutine(Move());
        }
        else{
            StartCoroutine(Move2());
        }
    }

    public bool down = true;
    public float start = 2.3625f;
    public float end = -2.8651f;
    private bool moveUp = true;
    private bool moveUp2 = false;
    public float moveSpeed = 10.0f;

    void Update()
    {
    }

    private IEnumerator Move()
    {
        while (true)
        {
            if (moveUp)
            {
                // Move downwards
                while (transform.position.y > end)
                {
                    transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
                    yield return null;
                }
                moveUp = false;
            }
            else
            {
                // Move upwards
                while (transform.position.y < start)
                {
                    transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
                    yield return null;
                }
                moveUp = true;
                
                float delayDuration = Random.Range(1.0f, 10.0f);
                yield return new WaitForSeconds(delayDuration);
            }
        }
    }

    private IEnumerator Move2()
    {
        while (true)
        {
            if (moveUp2)
            {
                // Move downwards
                while (transform.position.y > end)
                {
                    transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
                    yield return null;
                }
                moveUp2 = false;
                
                float delayDuration = Random.Range(1.0f, 10.0f);
                yield return new WaitForSeconds(delayDuration);
            }
            else
            {
                // Move upwards
                while (transform.position.y < start)
                {
                    transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
                    yield return null;
                }
                moveUp2 = true;
            }
        }
    }
}
