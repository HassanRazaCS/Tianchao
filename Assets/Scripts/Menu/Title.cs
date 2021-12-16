using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title: MonoBehaviour
{
    public Canvas titleScreen;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            titleScreen.GetComponent<Canvas>().enabled = false;
        }
    }
}