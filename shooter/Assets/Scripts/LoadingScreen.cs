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
    public void StartLoadingScreenNormalMap()
    {
        StartCoroutine(LoadSceneNormalEnumerator());
    }
    public void StartLoadingScreenNormaBossMap()
    {
        StartCoroutine(LoadSceneBossEnumerator());
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
        AsyncOperation operation = SceneManager.LoadSceneAsync(3);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            text.text = progress * 100f + "%";
            yield return null;
        }
    }
}