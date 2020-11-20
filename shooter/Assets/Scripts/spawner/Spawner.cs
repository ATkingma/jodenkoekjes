using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //public
    public List<GameObject> spawnPoints, enemie,emergencySpawnPoint;
    public GameObject Time;
    //private
    private float SpawnCoolDown,coolDownTime,chingChongSpawntimeShitTussenStukjeFadi;
    private bool isSpawning, doingCooldDown;
    void Start()
    {
        spawnPoints.AddRange(GameObject.FindGameObjectsWithTag("SpawnPoint"));
        SpawnCoolDown = 3f;
    }
    void Update()
    {
        float time = Time.GetComponent<TimeTime>().timeToSafe;
        if (coolDownTime <= time)
        {         
            Spawn();
            if (!doingCooldDown)
            {
            Cooldown();
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
    public void Cooldown()
    {
        doingCooldDown = true;
        coolDownTime = SpawnCoolDown + Time.GetComponent<TimeTime>().timeToSafe;
        Invoke("CoolBool", 0.5f);
    }
    public void CoolBool()
    {
        doingCooldDown = false;
    }
}