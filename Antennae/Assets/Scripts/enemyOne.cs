using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyOne : MonoBehaviour
{
    public int damage = 30;
    public int score = 40;
    public int health = 40;
    private int halfHealth;
    private float speed  = 5f;
    private float aplitude = 1f;
    private float frequency = 1f;
    private float startY;


    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        halfHealth = health / 2;
        rb = GetComponent<Rigidbody2D>();
        startY = transform.position.y;
    }
    private void FixedUpdate()
    {

        rb.velocity =new Vector2(-speed, 0);


        Vector2 position = transform.position;


        position.y = startY + Mathf.Sin(position.x * frequency) *aplitude;
        //position.x -= speed * Time.fixedDeltaTime;
        transform.position = position;
    }
    // Update is called once per frame
    void Update()
    {
        //destroy if off screen
        if (transform.position.x < levelController.screenBounds.x * 1.5 * -1)
        {
            Destroy(this.gameObject);
        }
    }
    public void takeDamage(int amount)
    {
        health += amount;
        if(health <= halfHealth)
            this.GetComponentInChildren<SpriteRenderer>().color = Color.red;
    }
}
