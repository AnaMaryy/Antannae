using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 15.0f;
    public int damage = 20;
    public GameObject Explosion;
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > levelController.screenBounds.x * 2)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Asteroid")
        {

            other.gameObject.GetComponent<asteroid>().health -= this.damage;
            if (other.gameObject.GetComponent<asteroid>().health <= 0)
            {
                GameObject explosion = Instantiate(Explosion);
                explosion.transform.position = transform.position;

                levelController.score += other.gameObject.GetComponent<asteroid>().score;
                Destroy(other.gameObject);
                Destroy(explosion, 1);
            }
            //destroy bullet
            Destroy(gameObject);



        }
        if (other.gameObject.tag == "Enemy1" )
        {

            other.gameObject.GetComponent<enemyOne>().takeDamage(-this.damage);
            if (other.gameObject.GetComponent<enemyOne>().health <= 0)
            {
                GameObject explosion = Instantiate(Explosion);
                explosion.transform.position = transform.position;

                levelController.score += other.gameObject.GetComponent<enemyOne>().score;
                Destroy(other.gameObject);
                Destroy(explosion, 1);
            }
            //destroy bullet
            Destroy(gameObject);


        }
    }
}
