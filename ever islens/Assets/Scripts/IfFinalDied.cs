using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IfFinalDied : MonoBehaviour
{
    public GameObject uiob,shure;
    void Start()
    {
        uiob.SetActive(false);
        shure.SetActive(false);
    }
    public void Obliveration()
    {
        uiob.SetActive(true);
    }
    public void Obliverat()
    {
        shure.SetActive(true);
    }
    public void Futher()
    {
    //laad hier shit
    }
    public void yes()
    {
        SceneManager.LoadScene(0);
    }
    public void no()
    {
        uiob.SetActive(false);
        shure.SetActive(false);
    }
}