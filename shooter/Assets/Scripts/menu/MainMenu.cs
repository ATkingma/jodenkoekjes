using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject menu, options, items, stats;
    public List<int> enemiesKilled, killedBy;
    public List<TextMeshProUGUI> enemiesList, gunList;
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
    public void ToItems()
    {
        itemsOn = true;
        menuOn = false;
    }
    public void ToStats()
    {
        statsOn = true;
        menuOn = false;
        for (int i = 0; i < killedBy.Count; i++)
        {
            killedBy[i] = PlayerPrefs.GetInt("gun" + i, 0);
        }
        for (int o = 0; o < enemiesKilled.Count; o++)
        {
            enemiesKilled[o] = PlayerPrefs.GetInt("enemy" + o, 0);
        }
        for(int q = 0; q < enemiesList.Count; q++)
        {
            enemiesList[q].text = enemiesKilled[q].ToString();
        }
        for(int m = 0; m < gunList.Count; m++)
        {
            gunList[m].text = killedBy[m].ToString();
        }
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
