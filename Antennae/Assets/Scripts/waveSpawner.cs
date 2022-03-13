using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class waveSpawner : MonoBehaviour
{

    public GameObject asteroidPrefab;
    public GameObject powerUpPrefab;
    public GameObject enemyOnePrefab;

    [System.Serializable]
    public class Wave {
        public int countAsteroid = 1;
        public int countEnemyOneCluster = 1;
        public float countPowerUp = 0.5f;
        public float respawnTime = 2f;
        public int waveCount = 0;

       
    }
    
    public static class WaveLimit
    {
        public static float respawnTime = 0.25f;
    }
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    public List<Wave> waves;
    public int nextWave = 0;

    public float timeBetweenWaves = 4f;
    public float countDownWave;

  

    private SpawnState state = SpawnState.COUNTING;
    // Start is called before the first frame update
    void Start()
    {
        countDownWave = timeBetweenWaves;

        waves = new List<Wave>();
        waves.Add( new Wave());
        //StartCoroutine(wave());
    }
    private void Update()
    {
        if(state == SpawnState.WAITING)
        {
            newWave();
        }
        if(countDownWave <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                
                StartCoroutine(wave(waves[nextWave]));
                //wave(waves[nextWave]);

            }
        }
        else
        {
            countDownWave -= Time.deltaTime;
        }
    }
   
    private void newWave()
    {
        Debug.Log("previous wave completed, creating new one");
        state = SpawnState.COUNTING;
        countDownWave = timeBetweenWaves;
        //create a new wave
        int previousWave = nextWave;
        nextWave++;

        Wave newWave = new Wave();
        newWave.countAsteroid = waves[previousWave].countAsteroid +2;
        newWave.countEnemyOneCluster = waves[previousWave].countEnemyOneCluster +1;
        newWave.countPowerUp = waves[previousWave].countPowerUp + 0.5f;
        if (waves[previousWave].respawnTime - 0.25f >= WaveLimit.respawnTime)
        {
            newWave.respawnTime = waves[previousWave].respawnTime - 0.25f;
        }
        else
        {
            newWave.respawnTime = WaveLimit.respawnTime;
        }

        newWave.waveCount = waves[previousWave].waveCount + 1;

        waves.Add(newWave);
    }

    private IEnumerator wave(Wave wave)
    {
        Debug.Log("Spawning Wave: "+wave.waveCount);
        state = SpawnState.SPAWNING;

        int countPowerUp = 0;
        int countAsteroid = 0;
        int countEnemyOneCluster = 0;
        int countGameObjects = Mathf.FloorToInt(wave.countPowerUp + wave.countAsteroid + wave.countEnemyOneCluster);
        for (int i = 0; i < countGameObjects; i++)
        {
            if(countAsteroid < wave.countAsteroid)
            {
                spawnAsteroid();
                countAsteroid++;
                countGameObjects++;
                yield return new WaitForSeconds(wave.respawnTime);
            }
            if (countPowerUp < wave.countPowerUp)
            {
                spawnPowerUp();
                countPowerUp++;
                countGameObjects++;
                yield return new WaitForSeconds(wave.respawnTime);
            }
            if(countEnemyOneCluster < wave.countEnemyOneCluster)
            {
                spawnEnemyOneCluster();
                countEnemyOneCluster++;
                countGameObjects++;
                yield return new WaitForSeconds(wave.respawnTime);
            }

        }
        
        state = SpawnState.WAITING;
        yield break;


    }
   
    private void spawnPowerUp()
    {
        GameObject obj = Instantiate(powerUpPrefab);
        obj.transform.position = new Vector2(levelController.screenBounds.x * 2, Random.Range(levelController.screenBounds.y, -levelController.screenBounds.y));

    }
    private void spawnAsteroid()
    {
        GameObject obj = Instantiate(asteroidPrefab);
        obj.transform.position = new Vector2(levelController.screenBounds.x * 2, Random.Range(levelController.screenBounds.y, -levelController.screenBounds.y));

    }

    private void spawnEnemyOneCluster()
    {
        float spacing = 0;
        float y = Random.Range(levelController.screenBounds.y, -levelController.screenBounds.y);


        float spriteLength = enemyOnePrefab.GetComponentInChildren<SpriteRenderer>().bounds.extents.x;
        for (int i = 0; i < 5; i++)
        {
            GameObject obj = Instantiate(enemyOnePrefab);
            obj.transform.position = new Vector2(levelController.screenBounds.x * 2 + spacing, y);
            spacing += spriteLength + 1;
        }
    }
    
}
