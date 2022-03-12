using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// repeats the background
public class backgroundRepeat : MonoBehaviour
{
    public GameObject[] backgroundImages;
    private Camera mainCamera;
    private float speed = 4.0f;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        foreach(GameObject obj in backgroundImages)
            loadChildObjects(obj);

    }
    //creates new child gameobjects of the background image
    void loadChildObjects(GameObject parent)
    {
        float parentWidth = parent.GetComponent<SpriteRenderer>().bounds.size.x;
        int numberOfChildren = (int)Mathf.Ceil(screenBounds.x * 2 / parentWidth)+1;

        GameObject clone = Instantiate(parent) as GameObject;
        for( int i = 0; i < numberOfChildren; i++)
        {
            GameObject child = Instantiate(clone) as GameObject;
            child.name = parent.name + i;
            child.transform.SetParent(parent.transform);
            child.transform.position = new Vector2(parentWidth * i, parent.transform.position.y);
            //flip every odd image
            if(i%2 != 0)
            {
                child.GetComponent<SpriteRenderer>().flipX= true;
            }
        }
        Destroy(clone);
        Destroy(parent.GetComponent<SpriteRenderer>());
    }
    //switches the order of child background images based on camera bounds -> puts the first child as the last
    private void setChildPosition(GameObject parent)
    {
        Transform[] children = parent.GetComponentsInChildren<Transform>();
        if (children.Length > 1)
        {
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;
            float halfWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x;
            //camera right edge 
            if (mainCamera.transform.position.x + screenBounds.x > lastChild.transform.position.x + halfWidth)
            {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector2(lastChild.transform.position.x + halfWidth * 2, lastChild.transform.position.y);
            }
        }   
    }
    private void FixedUpdate()
    {
        //moves background
        foreach (GameObject obj in backgroundImages)
        {
            obj.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
    private void LateUpdate()
    {
        foreach(GameObject obj in backgroundImages)
        {
            setChildPosition(obj);
        }
    }
    
}
