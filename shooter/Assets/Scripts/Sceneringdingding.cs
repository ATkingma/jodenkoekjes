using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneringdingding : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void SceneLoader()
    {
        int sceneindex = Random.Range(1, 3);
        SceneManager.LoadScene(sceneindex);
    }
}
