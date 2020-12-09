using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathPlayer : MonoBehaviour
{
    public GameObject player,deathUI;

    //privates
    private Saves clear;

    private void Start()
    {
        clear = FindObjectOfType<Saves>();
        player = FindObjectOfType<PlayerHealth>().gameObject;
    }
    void Update()
    {
        if (player.GetComponent<PlayerHealth>().health <= 0)
        {
            clear.ClearSaves();
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            deathUI.SetActive(true);
        }
    }
    public void MainMenu()
    {
        clear.ClearSaves();
        SceneManager.LoadScene(0);
    }
}