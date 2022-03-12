using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class gameOverScreen : MonoBehaviour
{
    public Text scoreText;
    public GameObject gui;
    public GameObject spaceShip;

    public void create(int score)
    {
        gameObject.SetActive(true);
        gui.SetActive(false);

        scoreText.text = "SCORE : " + score;
    }
    public void buttonRestart()
    {
         Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        // NetworkManager.singleton.ServerChangeScene(scene);
        levelController.resetLevel();
        Debug.Log("Restart game");
    }

}
