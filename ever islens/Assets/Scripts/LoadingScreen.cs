using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public Slider slider;
    public int scene;
    public GameObject loadingScreen;
    public TextMeshProUGUI text;

    private void Start()
    {
        scene = Random.Range(1, 4);
    }
    public void StartLoadingScreenNormalMap()
    {
        StartCoroutine(LoadSceneNormalEnumerator());
    }
    public void StartLoadingScreenNormaBossMap()
    {
        StartCoroutine(LoadSceneBossEnumerator());
    }
    public void StartLoadingScreenFinalBossMap()
    {
        StartCoroutine(LoadSceneFinalBossEnumerator());
    }
    public void MainMenu()
    {
        StartCoroutine(LoadMainMenu());
    }

    IEnumerator LoadSceneNormalEnumerator()
    {
            AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            text.text = progress * 100f + "%";
            yield return null; 
        }
    }
    IEnumerator LoadSceneBossEnumerator()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(5);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            text.text = progress * 100f + "%";
            yield return null;
        }
    }
    IEnumerator LoadSceneFinalBossEnumerator()///final  
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(6);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            text.text = progress * 100f + "%";
            yield return null;
        }
    }
    IEnumerator LoadMainMenu()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(0);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            text.text = progress * 100f + "%";
            yield return null;
        }
    }
    public void MainMainMenu()
    {
        for (int i = 0; i < 20; i++)
        {
            PlayerPrefs.SetFloat("itemQuantity" + i, 0);
        }
        PlayerPrefs.SetInt("CurrentGun", 0);
        PlayerPrefs.SetFloat("seconde", 0);
        PlayerPrefs.SetFloat("minuut", 0);
        PlayerPrefs.SetFloat("uur", 0);
        PlayerPrefs.SetInt("scene", 0);
        PlayerPrefs.SetInt("scenecount", 0);
        PlayerPrefs.SetInt("scene", 1);
    }
}