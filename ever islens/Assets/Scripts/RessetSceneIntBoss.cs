using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessetSceneIntBoss : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("scene", 0);
    }
}
