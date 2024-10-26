using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyContact : MonoBehaviour
{
    public Vector3 respawnPosition = new Vector3(-8.19f, -0.18f, 0.0f);
    public CoinManager CM;

    // Start is called before the first frame update
    void Start()
    {
        // Optionally get the SpriteRenderer component if not assigned in the Inspector
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

    }
    
    private float size = 5.0f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")){
            //size--;
            //if(size <= 1.0f){
            //    transform.position = respawnPosition;
            //    size = .5f;
            //    ChangeSprite();
            //    SceneManager.LoadScene(3);
            //}
            //transform.localScale = new Vector3(size, size, size);
            transform.position = respawnPosition;
        }
        else if(collision.gameObject.CompareTag("Coin")){
            CM.coin++;
            GameData.coin++;
            collision.gameObject.SetActive(false);
        }
        else if(collision.gameObject.CompareTag("Finish")){
            GameData.score = CM.coin;
            SceneManager.LoadScene(2);
        }
        transform.Rotate(0, 0, 0);
    }

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    public void ChangeSprite()
    {
        if (newSprite != null)
        {
            spriteRenderer.sprite = newSprite;
        }
    }
}
