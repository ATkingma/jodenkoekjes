﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            print("ringdigndijgnng");
            FindObjectOfType<SceneSwitcher>().SceneLoader();
        }
    }
}
