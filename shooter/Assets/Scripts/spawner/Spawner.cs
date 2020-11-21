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
    private float SpawnCoolDown,coolDownTime,fiveminits,tenminits,chingChongSpawntimeShitTussenStukjeFadi;
    private int maxEnemiesToSpawn,remeberme;
    private bool isSpawning, doingCooldDown,gettingHard;
    void Start()
    {
        spawnPoints.AddRange(GameObject.FindGameObjectsWithTag("SpawnPoint"));
        SpawnCoolDown = 5f;
        tenminits = 600;
        maxEnemiesToSpawn = 10;
        remeberme = 10;
        fiveminits = 300;
    }
    void Update()
    {
        float hard = Time.GetComponent<TimeTime>().timeToSafe;
        text.text = hard.ToString();
        if (fiveminits <= hard)
        {
            if (!gettingHard)
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
        fiveminits += 300;
        gettingHard = true;
        remeberme += 10;
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