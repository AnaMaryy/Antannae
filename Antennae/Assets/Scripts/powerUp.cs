using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    private float speed = 6.0f;
    public int score = 10;
    private Rigidbody2D rb;
    public int charge = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);

       // Camera mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        //screenBounds = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -5) * Time.deltaTime * 20);
        //destroy asteroids that are off screen
        if (transform.position.x < levelController.screenBounds.x * 1.5 * -1)
        {
            Destroy(this.gameObject);
        }
    }
}
