using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathToEnemies : MonoBehaviour
{
    private GameObject[] enemies;
    private void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        KillEnemie();
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
