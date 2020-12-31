using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject menu, options, items, stats;
    public List<TextMeshProUGUI> enemiesList, gunList, itemList;
    public TextMeshProUGUI timesDied, time, levels, games;
    public List<GameObject> achievementLocks, soundSliders, gunSkins;
    public AudioSource confirmButton;
    //list
    //0 = all; 1 = goblin; 2 = fire elemental; 3 = groot; 4 = golem; 5 = boss; 6 = final boss;
    //0 = pistol; 1 = launcher; 2 = rifle; 3 = staff;

    public AudioMixer master;

    //privates                                              
    public bool menuOn, optionsOn, itemsOn, anyIsOn, statsOn,
        slider0, slider1, slider2, slider3;
    protected Saves clear;
    private void Start()
    {
        menuOn = true;
        clear = FindObjectOfType<Saves>();
        master.SetFloat("master", PlayerPrefs.GetFloat("mastervolume", 0));
        master.SetFloat("music", PlayerPrefs.GetFloat("musicvolume", 0));
        master.SetFloat("sfx", PlayerPrefs.GetFloat("sfxvolume", 0));
        master.SetFloat("ui", PlayerPrefs.GetFloat("uivolume", 0));

        soundSliders[0].GetComponent<Slider>().value = PlayerPrefs.GetFloat("mastervolume", 0);
        soundSliders[1].GetComponent<Slider>().value = PlayerPrefs.GetFloat("musicvolume", 0);
        soundSliders[2].GetComponent<Slider>().value = PlayerPrefs.GetFloat("sfxvolume", 0);
        soundSliders[3].GetComponent<Slider>().value = PlayerPrefs.GetFloat("uivolume", 0);
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
        PlayerPrefs.SetInt("scene", 0);
        FindObjectOfType<SceneSwitcher>().SceneLoader();
    }

    public void ToMenu()
    {
        confirmButton.Play();
        menuOn = true;
        optionsOn = false;
        itemsOn = false;
        statsOn = false;
    }
    public void ToOptions()
    {
        confirmButton.Play();
        optionsOn = true;
        menuOn = false;
    }

    public void ToItems()
    {
        confirmButton.Play();
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
        confirmButton.Play();
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
            if(PlayerPrefs.GetInt("gun" + m, 0) >= 100)
            {
                gunSkins[m].SetActive(true);
            }
        }
        if(PlayerPrefs.GetInt("goldenpistol", 0) == 0)
        {
            gunSkins[0].GetComponent<Toggle>().isOn = false;
        }
        else
        {
            gunSkins[0].GetComponent<Toggle>().isOn = true;
        }
        if (PlayerPrefs.GetInt("goldenlauncher", 0) == 0)
        {
            gunSkins[1].GetComponent<Toggle>().isOn = false;
        }
        else
        {
            gunSkins[1].GetComponent<Toggle>().isOn = true;
        }
        if (PlayerPrefs.GetInt("goldenrifle", 0) == 0)
        {
            gunSkins[2].GetComponent<Toggle>().isOn = false;
        }
        else
        {
            gunSkins[2].GetComponent<Toggle>().isOn = true;
        }

        for (int s = 0; s < itemList.Count; s++)
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
        confirmButton.Play();
        //clear.ClearSaves();
        Application.Quit();
    }
    private void Update()
    {
        menu.SetActive(menuOn);
        options.SetActive(optionsOn);
        items.SetActive(itemsOn);
        stats.SetActive(statsOn);
    }
    #region sliders
    public void MasterVolume(Slider slider)
    {
        if(slider0)
        {
            slider0 = false;
            Invoke("SliderCooldownSlider0", 0.1f);
            confirmButton.Play();
        }
        master.SetFloat("master", slider.value);
        PlayerPrefs.SetFloat("mastervolume", slider.value);
    }
    public void SfxVolume(Slider slider)
    {
        if (slider1)
        {
            slider1 = false;
            Invoke("SliderCooldownSlider1", 0.1f);
            confirmButton.Play();
        }
        master.SetFloat("sfx", slider.value);
        PlayerPrefs.SetFloat("sfxvolume", slider.value);
    }
    public void MusicVolume(Slider slider)
    {
        if (slider2)
        {
            slider2 = false;
            Invoke("SliderCooldownSlider2", 0.1f);
            confirmButton.Play();
        }
        master.SetFloat("music", slider.value);
        PlayerPrefs.SetFloat("musicvolume", slider.value);
    }
    public void UiVolume(Slider slider)
    {
        if (slider3)
        {
            slider3 = false;
            Invoke("SliderCooldownSlider3", 0.1f);
            confirmButton.Play();
        }
        master.SetFloat("ui", slider.value);
        PlayerPrefs.SetFloat("uivolume", slider.value);
    }
    
    //slider sound
    public void SliderCooldownSlider0()
    {
        slider0 = true;
    }
    public void SliderCooldownSlider1()
    {
        slider1 = true;
    }
    public void SliderCooldownSlider2()
    {
        slider2 = true;
    }
    public void SliderCooldownSlider3()
    {
        slider3 = true;
    }
    #endregion
    //golden skins
    public void GoldenPistolOn()
    {
        confirmButton.Play();
        PlayerPrefs.SetInt("goldenpistol", 1);
    }
    public void GoldenLauncherOn()
    {
        confirmButton.Play();
        PlayerPrefs.SetInt("goldenlauncher", 1);
    }
    public void GoldenRifleOn()
    {
        confirmButton.Play();
        PlayerPrefs.SetInt("goldenrifle", 1);
    }
}
