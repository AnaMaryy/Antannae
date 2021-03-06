using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour
{
    private float speed = 8.0f;
    private Rigidbody2D rb;
    public int damage = 20;
    public int health = 20;
    public int score = 20;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        //rb.collisionDetectionMode =CollisionDetectionMode2D.Continuous;

       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 10) * Time.deltaTime * 20);
        //destroy asteroids that are off screen
        if (transform.position.x < levelController.screenBounds.x*1.5 *-1)
        {
            Destroy(this.gameObject);
        }
    }
    
}
