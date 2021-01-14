using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefDeleter : MonoBehaviour
{
    void Update()
    {
    }
    public void Delte()
    {
        Screen.fullScreen = true;
        PlayerPrefs.DeleteAll();
    }
}
