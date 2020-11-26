using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private GameObject[] enemies;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("ringdigndijgnng");
            FindObjectOfType<SceneSwitcher>().SceneLoader();
            GetEnemies();
        }
    }
    public void GetEnemies()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        KillEnemie();
    }
    public void KillEnemie()
    {
        foreach (GameObject enemie in enemies)
        {
            Destroy(enemie);
        }
    }
}
