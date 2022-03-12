using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Bullet;
    void Start()
    {

       
    }
    void Update()
    {
       
    }
    public void shootBullet()
    {
        GameObject bullet = Instantiate(Bullet);
        float speed = bullet.GetComponent<bullet>().speed;

        bullet.transform.position = transform.position;
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        rbBullet.velocity = new Vector2(speed, 0);

    }
    public void shootMultipleBullets()
    {
        int[] degrees = { 45, 15, 0, -15, -45 };
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        for (int i = 0; i < degrees.Length; i++)
        {
            GameObject bullet = Instantiate(Bullet, transform.position, Quaternion.Euler(eulerRotation.x, eulerRotation.y, degrees[i]));
            Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
            Vector2 direction = (bullet.transform.localRotation * Vector2.right).normalized;
            float speed = bullet.GetComponent<bullet>().speed;

            rbBullet.velocity = direction * speed;
        }
    }
}
