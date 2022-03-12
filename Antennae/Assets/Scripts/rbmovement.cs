using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// rigidbody movement based on user input
public class rbmovement : MonoBehaviour
{

    public float speed = 10.0f;
    public Rigidbody2D rb;
    public Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //detect input
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
    private void FixedUpdate()
    {
        move(movement);
    }
    private void move(Vector2 direction)
    {
        //rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
        rb.velocity= direction * speed;
       // rb.AddForce(direction * speed);
    }
}
