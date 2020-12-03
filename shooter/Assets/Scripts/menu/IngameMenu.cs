﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameMenu : MainMenu
{

    //privates
    private Trigger trig;

    private void Start()
    {
        trig = FindObjectOfType<Trigger>();
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
        if(menuOn || itemsOn || optionsOn)
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
        menuOn = false;
        optionsOn = false;
        itemsOn = false;
    }
}
