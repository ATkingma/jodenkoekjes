using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //public
    public List<GameObject> spawnPoints, enemie,emergencySpawnPoint, activeSpawnPoints;
    public GameObject Times, portal;
    public int maxEnemiesTokill,enemiesDied, enemiesAlive;
    public TextMeshProUGUI text, emeiesDiedCount;
    //private
    private float SpawnCoolDown,coolDownTime, countminup;
    private int maxEnemiesToSpawn,remeberme,plusmax, spawnThisTime;
    private bool isSpawning, doingCooldDown,gettingHard;
    private GameObject player;

    //difficulty
    public int difficult;

    //jorn 
    private float seconde, minuut, uur, secondeTotal, minuutTotal, uurTotal;

    private void Awake()
    {
        player = FindObjectOfType<PlayerHealth>().gameObject;
        GetSpawnPoints();
        SpawnCoolDown = 20;
        maxEnemiesToSpawn = 100;
        plusmax = PlayerPrefs.GetInt("MaxEnemiesToKill");
        plusmax += 1; //balancing
        maxEnemiesTokill = (int)((PlayerPrefs.GetInt("MaxEnemiesToKill")+5 )* 1.1);
        PlayerPrefs.SetInt("MaxEnemiesToKill", maxEnemiesTokill);
        remeberme = 10;
        countminup = 5;
        portal = FindObjectOfType<Portal>().gameObject;
        portal.SetActive(false);
        seconde = PlayerPrefs.GetFloat("seconde", seconde);
        minuut = PlayerPrefs.GetFloat("minuut", minuut);
        uur = PlayerPrefs.GetFloat("uur", uur);
        secondeTotal += PlayerPrefs.GetFloat("secolndetotal", 0);
        minuutTotal += PlayerPrefs.GetFloat("minuuttotal", 0);
        uurTotal += PlayerPrefs.GetFloat("uurtotal", 0);
    }
    void Update()
    {
        //time
        seconde += Time.deltaTime;
        if (seconde >= 60)
        {
            seconde = 0;
            minuut++;

            difficult = (int)Mathf.Floor(minuut / 2);
            if (minuut >= 60)
            {
                minuut = 0;
                uur++;
            }
        }
        text.text = minuut + ":" + Mathf.RoundToInt(seconde);
        if (uur > 0)
        {
            text.text = uur + ":" + minuut + ":" + Mathf.RoundToInt(seconde);
        }
    
        if (enemiesDied >= maxEnemiesTokill)
        {
            portal.SetActive(true);
        }
        float minutes = Mathf.Floor(Times.GetComponent<TimeTime>().timeToSafe / 60);
        float seconds = Times.GetComponent<TimeTime>().timeToSafe % 60;
        //text.text = minutes + ":" + Mathf.RoundToInt(seconds);
        emeiesDiedCount.text = enemiesDied.ToString() + " / " + maxEnemiesTokill.ToString();
        //if (minutes==countminup)
        //{
        //    if (doingCooldDown == false)
        //    { 
        //        GettingHarder();
        //    }
        //}
        float time = Times.GetComponent<TimeTime>().timeToSafe;
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
        spawnThisTime = Random.Range(1, 5 * (int)((1 + 0.1f) + (0.1f * minuut)));
        foreach (GameObject spawnPoint in spawnPoints)
        {
            if (maxEnemiesToSpawn > 0)
            {
                if (enemiesAlive >= 10)
                {
                    if (spawnThisTime > 0)
                    {
                        spawnThisTime = 1;
                        float dist;
                        dist = Vector3.Distance(player.transform.position, spawnPoint.transform.position);
                        if (dist <= 200 && dist >= 15)
                        {
                            enemiesAlive++;
                            int enemiePrefab = Random.Range(0, enemie.Count);
                            GameObject clone = Instantiate(enemie[enemiePrefab], spawnPoint.transform.position, Quaternion.identity);
                            clone.GetComponent<EnemyHealth>().DifficultyIncrease((int)minuut * 3);
                            if (FindObjectOfType<GameObject>().GetComponent<Boss>())
                            {
                                clone.GetComponent<EnemieScript>().DifficultyIncrease((int)minuut);
                            }
                            spawnThisTime -= 1;
                            activeSpawnPoints.Clear();
                        }
                    }
                }
                else
                {
                    if (spawnThisTime > 0)
                    {
                        float dist;
                        dist = Vector3.Distance(player.transform.position, spawnPoint.transform.position);
                        if (dist <= 200 && dist >= 15)
                        {
                            enemiesAlive++;
                            int enemiePrefab = Random.Range(0, enemie.Count);
                            GameObject clone = Instantiate(enemie[enemiePrefab], spawnPoint.transform.position, Quaternion.identity);
                            clone.GetComponent<EnemyHealth>().DifficultyIncrease((int)minuut);
                            if (FindObjectOfType<GameObject>().GetComponent<Boss>())
                            {
                                clone.GetComponent<EnemieScript>().DifficultyIncrease((int)minuut);
                            }
                            spawnThisTime -= 1;
                            activeSpawnPoints.Clear();
                        }
                    }
                }
            }
        }
        isSpawning = true;
    }
    public void Cooldown()
    {
        doingCooldDown = true;
        coolDownTime = SpawnCoolDown + Times.GetComponent<TimeTime>().timeToSafe;
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
        //maxEnemiesToSpawn = remeberme;
        //maxEnemiesTokill = maxEnemiesToSpawn;
        gettingHard = false;
        SpawnCoolDown -= 0.1f;
    }
    public void GetSpawnPoints()
    {
        spawnPoints.AddRange(GameObject.FindGameObjectsWithTag("SpawnPoint"));
    }
    public void SaveTime()
    {
        PlayerPrefs.SetFloat("seconde", seconde);
        PlayerPrefs.SetFloat("minuut", minuut);
        PlayerPrefs.SetFloat("uur", uur);
        PlayerPrefs.SetFloat("secondetotal", seconde + secondeTotal);
        PlayerPrefs.SetFloat("minuuttotal", minuut + minuutTotal);
        PlayerPrefs.SetFloat("uurtotal", uur + uurTotal);
    }
}