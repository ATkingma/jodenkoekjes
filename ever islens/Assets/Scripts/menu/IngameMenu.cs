using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class IngameMenu : MainMenu
{
    public GameObject deathscreen;

    //privates
    private Trigger trig;

    private void Start()
    {
        trig = FindObjectOfType<Trigger>();
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
    private void Update()
    {
        if(Input.GetButtonDown("Escape"))
        {
            if (menuOn)
            {
                if(optionsOn || itemsOn)
                {
                    optionsOn = false;
                    itemsOn = false;
                }
                else
                {
                    menuOn = false;
                }
            }
            else
            {
                if (optionsOn || itemsOn)
                {
                    optionsOn = false;
                    itemsOn = false;
                }
                menuOn = true;
            }
        }
        if(menuOn || itemsOn || optionsOn || statsOn || deathscreen.activeInHierarchy)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            anyIsOn = true;
            trig.menuIsActive = true;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            anyIsOn = false;
            trig.menuIsActive = false;
        }
        menu.SetActive(menuOn);
        options.SetActive(optionsOn);
        items.SetActive(itemsOn);
    }
    public void Resume()
    {
        confirmButton.Play();
        menuOn = false;
        optionsOn = false;
        itemsOn = false;
    }
}
