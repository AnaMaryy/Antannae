using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceShip : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private float shipWidth;
    public int health = 100;
    public int powerUp = 0;

    //public Transform gun;
    public gun Gun;
    //public GameObject Bullet;
    public GameObject Explosion;

    //private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shipWidth = GetComponentInChildren<SpriteRenderer>().bounds.extents.x;

    }

    // Update is called once per frame
    void Update()
    {
        //detect input
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetKeyDown("space"))
        {
            if(powerUp > 0){ 
                Gun.shootMultipleBullets();
                powerUp -= 1;
            }
            else
            {
                Gun.shootBullet();
            }
        }
        checkDeath();


    }
    private void FixedUpdate()
    {
        moveShip(movement);
    }
    private void checkDeath()
    {
        if(health <= 0)
        {
            Debug.Log("GameOver");
        }
    }
    public void takeDamage(int damage)
    {
        health -= damage;
    }
    private void moveShip(Vector2 direction)
    {
        //rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
        rb.velocity = direction * speed;
        // rb.AddForce(direction * speed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Asteroid")
        {
            Debug.Log("Asteroid collision detected");
            GameObject explosion = Instantiate(Explosion);
            explosion.transform.position = transform.position;
            
            int damage = other.gameObject.GetComponent<asteroid>().damage;
            takeDamage(damage);
            //removes asteroid
            Destroy(other.gameObject);
            Destroy(explosion, 1);
            //hides ship
            //this.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "PowerUp")
        {
            int charge = other.gameObject.GetComponent<powerUp>().charge;
            powerUp += charge;
            Destroy(other.gameObject);
        }

    }
}
