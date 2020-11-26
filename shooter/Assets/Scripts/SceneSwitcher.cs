using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    //public
    public int maxScenes;
    //private
    private int scenes;
    void Start()
    {
        scenes= PlayerPrefs.GetInt("scene");
    }
    public void SceneLoader()
    {
        if (scenes <= 2)
        {
        FindObjectOfType<LoadingScreen>().StartLoadingScreenNormalMap();
        }
        if (scenes >= 3)
        {
        FindObjectOfType<LoadingScreen>().StartLoadingScreenNormaBossMap();
        }
        Plus();
    }
    public void ResetDieShit()
    {
        PlayerPrefs.SetFloat("TimeSaved", 0f);
        PlayerPrefs.SetInt("scene", 0);
    }
    public void Plus()
    {
        scenes++;
    }
    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("scene", scenes);
    }
}
