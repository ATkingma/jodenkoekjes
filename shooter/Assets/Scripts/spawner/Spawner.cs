using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //public
    public List<GameObject> spawnPoints, enemie;
    //private
    private float SpawnCoolDown;
    private bool isSpawning;
    void Start()
    {
        spawnPoints.AddRange(GameObject.FindGameObjectsWithTag("SpawnPoint"));
    }
    void Update()
    {
        if (SpawnCoolDown <= Time.deltaTime)
        {
            if (isSpawning == false)
            {
            Spawn();
            }
        }
    }
    public void Spawn()
    {
        foreach (GameObject spawnPoint in spawnPoints)
        {
            if (spawnPoint.GetComponent<SpawnPoint>().SpawnAble == true)
            {               
               int enemiePrefab= Random.Range(0, enemie.Count);
                      Instantiate(enemie[enemiePrefab], spawnPoint.transform.position, Quaternion.identity);
            }
        }
        isSpawning = true;
    }
}