using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public GameObject powerUpPrefab;
    public GameObject enemyOnePrefab;


    public float respawnTimePowerUp = 1.0f;
    private float respawnTimeEnemyOneCluster = 5f;
    private float respawnTimeEnemyOne= 5f;
    private float respawnTimeAsteroid = 5f;


    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(wave());
    }

    private void spawnAsteroids()
    {
        GameObject obj = Instantiate(asteroidPrefab);
        obj.transform.position = new Vector2(levelController.screenBounds.x * 2, Random.Range(levelController.screenBounds.y, -levelController.screenBounds.y));

    }
    private void spawnPowerUps()
    {
        GameObject obj = Instantiate(powerUpPrefab);
        obj.transform.position = new Vector2(levelController.screenBounds.x * 2, Random.Range(levelController.screenBounds.y, -levelController.screenBounds.y));

    }
    private void spawnEnemyOne()
    {
        GameObject obj = Instantiate(enemyOnePrefab);
        obj.transform.position = new Vector2(levelController.screenBounds.x * 2, Random.Range(levelController.screenBounds.y, -levelController.screenBounds.y));

    }
    private void spawnEnemyOneCluster()
    {
        float spacing = 0;
        float y = Random.Range(levelController.screenBounds.y, -levelController.screenBounds.y);


        float shipLength = enemyOnePrefab.GetComponentInChildren<SpriteRenderer>().bounds.extents.x;
        for (int i = 0; i < 5; i++)
        {
            GameObject obj = Instantiate(enemyOnePrefab);
            obj.transform.position = new Vector2(levelController.screenBounds.x * 2 + spacing, y);
            spacing += shipLength + 1;
        }

    }
    private IEnumerator wave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTimePowerUp);
            //spawnAsteroids();
            spawnPowerUps();
            yield return new WaitForSeconds(respawnTimeEnemyOneCluster);
            spawnEnemyOneCluster();

        }
    }
}
