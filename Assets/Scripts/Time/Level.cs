using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private bool[] tasks = new bool[1000000];
    public GameObject midBoss;

    void Start()
    {
        Time.fixedDeltaTime = 0.001f;
    }

    void FixedUpdate()
    {
        if (TimeManager.ifTimeIs(2f, ref tasks[0]))
        {
            Instantiate(midBoss, new Vector3(-11.5f, 5.5f, 0f),Quaternion.identity);
        } 
    }
}
