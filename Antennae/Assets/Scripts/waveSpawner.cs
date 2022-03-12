using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public GameObject powerUpPrefab;
    public GameObject enemyOnePrefab;


    public float respawnTime = 1.0f;
    public Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        Camera mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        StartCoroutine(wave());
    }

    private void spawnAsteroids()
    {
        GameObject obj = Instantiate(asteroidPrefab);
        obj.transform.position = new Vector2(screenBounds.x * 2, Random.Range(screenBounds.y, -screenBounds.y));

    }
    private void spawnPowerUps()
    {
        GameObject obj = Instantiate(powerUpPrefab);
        obj.transform.position = new Vector2(screenBounds.x * 2, Random.Range(screenBounds.y, -screenBounds.y));

    }
    private void spawnEnemyOne()
    {
        GameObject obj = Instantiate(enemyOnePrefab);
        obj.transform.position = new Vector2(screenBounds.x * 2, Random.Range(screenBounds.y, -screenBounds.y));

    }
    private void spawnEnemyCluster()
    {
        float spacing = 0;
        float y = Random.Range(screenBounds.y, -screenBounds.y);


        float shipLength = enemyOnePrefab.GetComponentInChildren<SpriteRenderer>().bounds.extents.x;
        for (int i = 0; i < 5; i++)
        {
            GameObject obj = Instantiate(enemyOnePrefab);
            obj.transform.position = new Vector2(screenBounds.x * 2 + spacing, y);
            spacing += shipLength + 20;
        }

    }
    private IEnumerator wave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            //spawnAsteroids();
            spawnPowerUps();
            spawnEnemyCluster();

        }
    }
}
