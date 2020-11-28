using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathPlayer : MonoBehaviour
{
    public GameObject player,deathUI;
    void Update()
    {
        if (player.GetComponent<PlayerHealth>().health <= 0)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            deathUI.SetActive(true);
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}