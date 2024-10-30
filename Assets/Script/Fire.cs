using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fire : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;

    // Start is called before the first frame update
   void Start()
     {
         mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
         rb = GetComponent<Rigidbody2D>();
         mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
         Vector3 direction = mousePos - transform.position;
         Vector3 rotation = transform.position - mousePos;
         rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
         float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
         transform.rotation = Quaternion.Euler(1, 1, rot + 90);       

     }

    // Detect collision with objects tagged as "Wall" or any other specific tags
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Limit"))
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("Finish")){
            SceneManager.LoadScene(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
