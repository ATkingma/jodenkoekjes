using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    //privates
    private GameObject[] enemies;
    private Saves safe;

    private void Start()
    {
        safe = FindObjectOfType<Saves>();

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        KillEnemie();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            safe.SaveEverything();
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
