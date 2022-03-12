using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//keeps object in ortographic camera bounds
public class boundaries : MonoBehaviour
{
    public Camera MainCamera;
    public Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;


    // Start is called before the first frame update
    void Start()
    {
        MainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = GameObject.Find("SpaceShip/Sprite").transform.GetComponent<SpriteRenderer>().bounds.extents.x; 
        objectHeight = GameObject.Find("SpaceShip/Sprite").transform.GetComponent<SpriteRenderer>().bounds.extents.y; 
    }
    private void LateUpdate()
    {
        Vector3 position = transform.position;
       
        position.x = Mathf.Clamp(position.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        position.y = Mathf.Clamp(position.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);

        transform.position = position;
    }
}
