using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class levelController :MonoBehaviour
{
    public static int score { get; set; } = 0;
    public static int powerUp { get; set; } = 0;
    void Awake()
    {
        DontDestroyOnLoad(this);
    }

}
