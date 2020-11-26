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
        if (scenes == 3)
        {
            SceneManager.LoadScene(3);
        }
        if (scenes<=2)
        {
        int sceneindex = Random.Range(1, maxScenes);
        SceneManager.LoadScene(sceneindex);
         Plus();
        }
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
