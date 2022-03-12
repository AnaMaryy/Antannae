using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnAsteroids : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float respawnTime = 1.0f;
    public Vector2 screenBounds; 
    // Start is called before the first frame update
    void Start()
    {
        Camera mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        StartCoroutine(wave());
    }
    private void spawn()
    {
        GameObject obj = Instantiate(asteroidPrefab) as GameObject;
        obj.transform.position = new Vector2(screenBounds.x * 2, Random.Range(screenBounds.y, -screenBounds.y));

    }
    private IEnumerator wave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawn();
        }
    }

}
