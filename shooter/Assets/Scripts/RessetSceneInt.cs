using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessetSceneInt : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("scene", 1);
    }
}
