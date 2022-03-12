using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class guiDisplay : MonoBehaviour
{
    private int health;
    private int powerup;
    private spaceShip spaceship;
    public Text healthText;
    public Text poweupText;
    // Start is called before the first frame update
    void Start()
    {
       spaceship = (spaceShip)FindObjectOfType(typeof(spaceShip));
        health = spaceship.health;
        powerup = spaceship.powerUp;
    }

    // Update is called once per frame
    void Update()
    {
        health = spaceship.health;
        powerup = spaceship.powerUp;
        healthText.text = "Health : " + health;
        poweupText.text = "PowerUp : " + powerup; 


    }
}
