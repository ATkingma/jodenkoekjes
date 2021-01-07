using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FinalBossLevelObliveration : MonoBehaviour
{
    public GameObject ui,youshure;
    public void StartOb()
    {
        ui.SetActive(true); 
    }
    public void Yes()
    {
        youshure.SetActive(true);
    }
    public void No()
    {
        ui.SetActive(false);
    }
    public void YesYes()
    {
        youshure.SetActive(false);
        MainMenu();
    }
    public void NoNo()
    {
        youshure.SetActive(false);
        ui.SetActive(false);
    }
    public void MainMenu()
    {
        FindObjectOfType<LoadingScreen>().MainMenu();
    }
}