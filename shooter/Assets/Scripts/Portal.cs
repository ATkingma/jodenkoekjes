﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    //privates
    private Saves safe;
    private void Start()
    {
        safe = FindObjectOfType<Saves>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            safe.SaveEverything();
            FindObjectOfType<SceneSwitcher>().SceneLoader();
        }
    }
}
