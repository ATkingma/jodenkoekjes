using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu, options;

    //privates
    private int chosenScene;

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
        menu.SetActive(true);
        options.SetActive(false);
    }
    public void ToOptions()
    {
        menu.SetActive(false);
        options.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            ToMenu();
        }
    }
}
