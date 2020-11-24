using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameMenu : MainMenu
{

    //privates
    private bool menuOn, OptionsOn;
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
                if(OptionsOn)
                {
                    OptionsOn = false;
                }
                else
                {
                    menuOn = false;
                    trig.menuIsActive = false;
                }
            }
            else
            {
                menuOn = true;
                trig.menuIsActive = true;
            }
        }
        if(menuOn)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        menu.SetActive(menuOn);
    }
}
