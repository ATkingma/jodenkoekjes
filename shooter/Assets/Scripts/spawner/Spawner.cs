using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //public
    public List<GameObject> spawnPoints, enemie,emergencySpawnPoint;
    public GameObject Time;
    public int maxEnemiesTokill;
    public TextMeshProUGUI text;
    //private
    private float SpawnCoolDown,coolDownTime,chingChongSpawntimeShitTussenStukjeFadi, countminup;
    private int maxEnemiesToSpawn,remeberme;
    private bool isSpawning, doingCooldDown,gettingHard;
    void Start()
    {
        spawnPoints.AddRange(GameObject.FindGameObjectsWithTag("SpawnPoint"));
        SpawnCoolDown = 30f;
        maxEnemiesToSpawn = 100;
        remeberme = 10;
        countminup = 5;
    }
    void Update()
    {
        float minutes = Mathf.Floor(Time.GetComponent<TimeTime>().timeToSafe / 60);
        float seconds = Time.GetComponent<TimeTime>().timeToSafe % 60;
        text.text = minutes + ":" + Mathf.RoundToInt(seconds);
            if (minutes==countminup)
            {
                      if (doingCooldDown == false)
                      { 
                      GettingHarder();
                      }
            }
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
            if (maxEnemiesToSpawn > 0)
            {
               int enemiePrefab= Random.Range(0, enemie.Count);
               Instantiate(enemie[enemiePrefab], spawnPoint.transform.position, Quaternion.identity);
                maxEnemiesToSpawn -= 1;
                print("spawned");
            }
        }
        isSpawning = true;
    }
    public void Cooldown()
    {
        doingCooldDown = true;
        coolDownTime = SpawnCoolDown + Time.GetComponent<TimeTime>().timeToSafe;
        Invoke("CoolBool", 0.5f);
        print("cooldowndingen");
    }
    public void CoolBool()
    {
        doingCooldDown = false;
    }
    public void GettingHarder()
    {
        print("wordmoeilijkerneef");
        gettingHard = true;
        remeberme += 20;
        countminup += 5;
        Invoke("GettingHarderbool", 0.1f);
    }
    public void GettingHarderbool()
    {
        maxEnemiesToSpawn = remeberme;
        maxEnemiesTokill = maxEnemiesToSpawn;
        gettingHard = false;
        SpawnCoolDown -= 0.1f;
    }
}