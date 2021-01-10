using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    //public
    //private
    private int scenes,countScenes;
    void Start()
    {
        PlayerPrefs.SetInt("scenecount", 5);
        scenes = PlayerPrefs.GetInt("scene");
        countScenes = PlayerPrefs.GetInt("scenecount");
    }
    public void SceneLoader()
    {
        countScenes = PlayerPrefs.GetInt("scenecount");
        scenes = PlayerPrefs.GetInt("scene");
        if (countScenes >= 20)
        {
            FindObjectOfType<LoadingScreen>().StartLoadingScreenFinalBossMap();
            PlayerPrefs.SetInt("scenecount", countScenes);
            PlayerPrefs.SetInt("scene", scenes);
        }
        else if (countScenes < 20)
        {
            if (scenes >= 3)
            {
                Ples();
                PlayerPrefs.SetInt("scenecount", countScenes);
                PlayerPrefs.SetInt("scene", scenes);
                FindObjectOfType<LoadingScreen>().StartLoadingScreenNormaBossMap();
            }
            if (scenes <= 2)
            {
                Ples();
                Plus();
                PlayerPrefs.SetInt("scenecount", countScenes);
                PlayerPrefs.SetInt("scene", scenes);
                FindObjectOfType<LoadingScreen>().StartLoadingScreenNormalMap();
            }
        }
    }
    public void mainMenu()
    {
        FindObjectOfType<LoadingScreen>().MainMenu();
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
    public void Ples()
    {
        countScenes++;
    }
    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("scenecount", countScenes);
        PlayerPrefs.SetInt("scene", scenes);
    }
    private void Update()
    {
        print(countScenes);
    }
}
