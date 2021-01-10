using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetFinalBossInt : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("scenecount", 0);
    }
}