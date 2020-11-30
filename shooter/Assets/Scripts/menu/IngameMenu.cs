using System.Collections;
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
                    trig.menuIsActive = false;
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
        options.SetActive(optionsOn);
        items.SetActive(itemsOn);
    }
}
