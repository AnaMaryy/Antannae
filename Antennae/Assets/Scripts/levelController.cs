using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class levelController :MonoBehaviour
{
    public static int score { get; set; } = 0;
    public static int powerUp { get; set; } = 0;

    public static levelController LC;


    public static Camera mainCamera;


    public static Vector2 screenBounds;

    public gameOverScreen GameOverScreen;

    public GameObject SpaceShip;
    
    void Awake()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));


        if (LC != null)
            GameObject.Destroy(LC);
        else
            LC = this;

        DontDestroyOnLoad(this);
    }
    private void Start()
    {
    }
    private void Update()
    {
        checkGameEnd();
    }
    
    public static void resetLevel()
    {
        score = 0;
        powerUp = 0;
    }
    private void checkGameEnd()
    {

        if (SpaceShip.GetComponent<spaceShip>().health <= 0)
        {
            Debug.Log("GameOver");
            GameOverScreen.create(score);
            SpaceShip.SetActive(false);

        }

    }

}
