using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FinalBossLevelObliveration : MonoBehaviour
{
    public GameObject jemoeder, youshure;

    private void Start()
    {
        print(jemoeder);
    }
    public void WerktNiet()
    {
        print(jemoeder);
        jemoeder.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }
    public void Yes()
    {
        youshure.SetActive(true);
    }
    public void No()
    {
        jemoeder.SetActive(false);
    }
    public void YesYes()
    {
        youshure.SetActive(false);
        jemoeder.SetActive(false);
        MainMenu();
    }
    public void NoNo()
    {
        youshure.SetActive(false);
        jemoeder.SetActive(false);
    }
    public void MainMenu()
    {
        FindObjectOfType<LoadingScreen>().MainMenu();
    }
    private void Update()
    {
        
    }
}