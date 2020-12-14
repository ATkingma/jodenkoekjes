using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathPlayer : MonoBehaviour
{
    public GameObject player,deathUI;

    //privates
    private Saves clear;
    private int timesDied;

    private void Start()
    {
        clear = FindObjectOfType<Saves>();
        player = FindObjectOfType<PlayerHealth>().gameObject;
    }
    void Update()
    {
        if (player.GetComponent<PlayerHealth>().health <= 0)
        {
            timesDied = PlayerPrefs.GetInt("timesdied", 0);
            timesDied++;
            PlayerPrefs.SetInt("timesdied", timesDied);
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