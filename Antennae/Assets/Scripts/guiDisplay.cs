using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class guiDisplay : MonoBehaviour
{
  

    private spaceShip ship;
    private waveSpawner waveSpawner;
    public Text healthText;
    public Text poweupText;
    public Text scoreText;
    public Text waveText;


    // Start is called before the first frame update
    void Start()
    {
        ship = (spaceShip)FindObjectOfType(typeof(spaceShip));
        waveSpawner = (waveSpawner)FindObjectOfType(typeof(waveSpawner));

    }

    // Update is called once per frame
    void Update()
    {
     
        healthText.text = "Health : " + ship.health;
        poweupText.text = "PowerUp : " + levelController.powerUp;
        scoreText.text = "Score : " + levelController.score;
        waveText.text = "Wave " + waveSpawner.waves.Count;


    }
}
