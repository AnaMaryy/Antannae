using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 15.0f;
    private Vector2 screenBounds;
    public GameObject Explosion;
    // Start is called before the first frame update
    void Start()
    {
       
        Camera mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        Debug.Log("bounds" + screenBounds.x);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > screenBounds.x * 2)
        {
            Destroy(this.gameObject);
        }
    }
    public void something()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Asteroid")
        {
            GameObject explosion = Instantiate(Explosion);
            explosion.transform.position = transform.position;

            Destroy(other.gameObject);
            Destroy(this.gameObject);
            Destroy(explosion, 1);



        }
    }
}
