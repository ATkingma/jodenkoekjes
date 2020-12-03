using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    //public
    //private
    private int scenes;
    void Start()
    {
        scenes = PlayerPrefs.GetInt("scene");       
    }
    public void SceneLoader()
    {
        scenes = PlayerPrefs.GetInt("scene");
        if (scenes <= 2)
        {
            Plus();
            PlayerPrefs.SetInt("scene", scenes);
            FindObjectOfType<LoadingScreen>().StartLoadingScreenNormalMap();
            print("normal map");
        }   
        if (scenes >= 3)
        {
            PlayerPrefs.SetInt("scene", scenes);
        FindObjectOfType<LoadingScreen>().StartLoadingScreenNormaBossMap();
            print("boss");
        }
    }
    public void ResetDieShit()
    {
        PlayerPrefs.SetFloat("TimeSaved", 0f);
        PlayerPrefs.SetInt("scene", 1);
    }
    public void Plus()
    {
        scenes++;
        print("plus");
    }
    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("scene", scenes);
    }
}
