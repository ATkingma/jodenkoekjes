using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject menu, options, items, stats;
    public List<TextMeshProUGUI> enemiesList, gunList, itemList;
    public TextMeshProUGUI timesDied, time, levels, games;
    public List<GameObject> achievementLocks;
    //list
    //0 = all; 1 = goblin; 2 = fire elemental; 3 = groot; 4 = golem; 5 = boss; 6 = final boss;
    //0 = pistol; 1 = launcher; 2 = rifle; 3 = staff;

    //privates                                              
    public bool menuOn, optionsOn, itemsOn, anyIsOn, statsOn;
    private int chosenScene;
    protected Saves clear;
    private void Start()
    {
        menuOn = true;
        clear = FindObjectOfType<Saves>();
    }

    //hier doet ie laat scene timme
    public void StartGame()
    {
        for (int i = 0; i < 20; i++)
        {
            PlayerPrefs.SetFloat("itemQuantity" + i, 0);
        }
        PlayerPrefs.SetInt("CurrentGun", 0);
        PlayerPrefs.SetFloat("seconde", 0);
        PlayerPrefs.SetFloat("minuut", 0);
        PlayerPrefs.SetFloat("uur", 0);
        RollScenes();
        SceneManager.LoadScene(chosenScene);
        PlayerPrefs.SetInt("scene", 0);
    }

    //rollllllll
    public void RollScenes()
    {
        chosenScene = Random.Range(1, 2);
    }

    public void ToMenu()
    {
        menuOn = true;
        optionsOn = false;
        itemsOn = false;
        statsOn = false;
    }
    public void ToOptions()
    {
        optionsOn = true;
        menuOn = false;
    }
    //↓↓↓↓↓↓↓↓↓↓↓↓ voor Timme bools voor item in pool ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓ er staan saves, die kan je in andere script ophalen! UwU
    public void ToItems()
    {
        itemsOn = true;
        menuOn = false;
        if(PlayerPrefs.GetInt("enemy" + 0, 0) >= 100)
        {
            achievementLocks[0].SetActive(false);
            PlayerPrefs.SetInt("critUnlocked", 1);
        }
        if (PlayerPrefs.GetInt("timesdied", 0) >= 5)
        {
            achievementLocks[1].SetActive(false);
            PlayerPrefs.SetInt("shieldUnlocked", 1);
        }
        if (PlayerPrefs.GetInt("enemy" + 6, 0) >= 1)
        {
            achievementLocks[2].SetActive(false);
            PlayerPrefs.SetInt("featherUnlocked", 1);
        }
        if (PlayerPrefs.GetInt("enemy" + 5, 0) >= 5)
        {
            achievementLocks[3].SetActive(false);
            PlayerPrefs.SetInt("richocetUnlocked", 1);
        }
    }
    public void ToStats()
    {
        statsOn = true;
        menuOn = false;
        //saves ophalen
        for(int q = 0; q < enemiesList.Count; q++)
        {
            enemiesList[q].text = PlayerPrefs.GetInt("enemy" + q, 0).ToString();
        }
        for(int m = 0; m < gunList.Count; m++)
        {
            gunList[m].text = PlayerPrefs.GetInt("gun" + m, 0).ToString();
        }
        for(int s = 0; s < itemList.Count; s++)
        {
            itemList[s].text = PlayerPrefs.GetFloat("itemstats" + s, 0).ToString();
        }
        timesDied.text = PlayerPrefs.GetInt("timesdied", 0).ToString();
        time.text = PlayerPrefs.GetFloat("uurtotal", 0).ToString() + ":" + PlayerPrefs.GetFloat("minuuttotal", 0).ToString() + ":" + Mathf.Floor(PlayerPrefs.GetFloat("secondetotal", 0)); //text.text = uur + ":" + minuut + ":" + Mathf.RoundToInt(seconde);
        levels.text = PlayerPrefs.GetInt("levels", 0).ToString();
        games.text = PlayerPrefs.GetInt("games", 0).ToString();
    }
    public void ToMainMenu()
    {
        clear.ClearSaves();
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        clear.ClearSaves();
        Application.Quit();
    }
    private void Update()
    {
        menu.SetActive(menuOn);
        options.SetActive(optionsOn);
        items.SetActive(itemsOn);
        stats.SetActive(statsOn);
    }
}
