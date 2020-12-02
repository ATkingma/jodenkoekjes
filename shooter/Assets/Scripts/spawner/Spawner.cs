using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //public
    public List<GameObject> spawnPoints, enemie,emergencySpawnPoint;
    public GameObject Time, portal;
    public int maxEnemiesTokill,enemiesDied;
    public TextMeshProUGUI text, emeiesDiedCount;
    //private
    private float SpawnCoolDown,coolDownTime, countminup;
    private int maxEnemiesToSpawn,remeberme,plusmax;
    private bool isSpawning, doingCooldDown,gettingHard;
    void Start()
    {
        spawnPoints.AddRange(GameObject.FindGameObjectsWithTag("SpawnPoint"));
        SpawnCoolDown = 20;
        maxEnemiesToSpawn = 100;
        plusmax = PlayerPrefs.GetInt("MaxEnemiesToKill");
        plusmax = +1;
        PlayerPrefs.SetInt("MaxEnemiesToKill",plusmax);
        maxEnemiesTokill = PlayerPrefs.GetInt("MaxEnemiesToKill");
        remeberme = 10;
        countminup = 5;
        portal = FindObjectOfType<Portal>().gameObject;
        portal.SetActive(false);
    }
    void Update()
    {
        if(enemiesDied >= maxEnemiesTokill)
        {
            portal.SetActive(true);
        }
        float minutes = Mathf.Floor(Time.GetComponent<TimeTime>().timeToSafe / 60);
        float seconds = Time.GetComponent<TimeTime>().timeToSafe % 60;
        text.text = minutes + ":" + Mathf.RoundToInt(seconds);
        emeiesDiedCount.text = enemiesDied.ToString();
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
    public void LoadScene()
    {
        GetComponent<SceneSwitcher>().SceneLoader();
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
            }
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
    public void GettingHarder()
    {
        gettingHard = true;
        remeberme += 50;
        countminup += 5;
        Invoke("GettingHarderbool", 0.1f);
    }
    public void GettingHarderbool()
    {
        maxEnemiesToSpawn = remeberme;
        //maxEnemiesTokill = maxEnemiesToSpawn;
        gettingHard = false;
        SpawnCoolDown -= 0.1f;
    }
}