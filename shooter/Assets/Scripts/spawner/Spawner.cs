using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //public
    public List<GameObject> spawnPoints, enemie,emergencySpawnPoint;
    //private
    private float SpawnCoolDown,chingChongSpawntimeShitTussenStukjeFadi;
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
               int enemiePrefab= Random.Range(0, enemie.Count);
               Instantiate(enemie[enemiePrefab], spawnPoint.transform.position, Quaternion.identity);
        }
        isSpawning = true;
    }
}