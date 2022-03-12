using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyOne : MonoBehaviour
{
    public int damage = 30;
    public int score = 30;
    private int health = 40;
    public float speed = 1f;
    public float aplitude = 1f;
    public float frequency = 0.2f;
    private float startY;
    private Vector2 screenBounds;


    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startY = transform.position.y;
        Camera mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }
    private void FixedUpdate()
    {

        //rb.velocity =new Vector2(-speed, 0);


        Vector2 position = transform.position;


        position.y = startY + Mathf.Sin(position.x * frequency) *aplitude;
        position.x -= speed * Time.fixedDeltaTime;
        transform.position = position;
    }
    // Update is called once per frame
    void Update()
    {
        //destroy if off screen
        if (transform.position.x < screenBounds.x * 1.5 * -1)
        {
            Destroy(this.gameObject);
        }
    }
}
