using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu, options, items;

    //privates
    protected bool menuOn, optionsOn, itemsOn;
    private int chosenScene;
    private void Start()
    {
        menuOn = true;
    }

    //hier doet ie laat scene timme
    public void StartGame()
    {
        RollScenes();
        SceneManager.LoadScene(chosenScene);
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
    public void ExitGame()
    {
        Application.Quit();
    }
    private void Update()
    {
        menu.SetActive(menuOn);
        options.SetActive(optionsOn);
        items.SetActive(itemsOn);
    }
}
