using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    //public
    public GameObject top,door,spawner,spawn1,spawn2,spawn3;
    //private
    private bool triggert, isDown,dontDoAnny, stopRightHere;
    private GameObject[] spawnpoints;
    void Start()
    {
        spawnpoints = GameObject.FindGameObjectsWithTag("ButtonSpawn");
        RandomButtonSpawn();
    }
    void Update()
    {
        if (isDown)
        {
            if (!stopRightHere)
            {
            stopRightHere = true;
            door.SetActive(false);
            spawner.GetComponent<Spawner>().spawnPoints.Add(spawn1);
            spawner.GetComponent<Spawner>().spawnPoints.Add(spawn2);
            spawner.GetComponent<Spawner>().spawnPoints.Add(spawn3);
            }
        }
        if (!dontDoAnny)
        {

        if (top.transform.position.y <= -0.332f)
        {
            isDown = true;
                dontDoAnny = true;
        }
        if (triggert)
        {
            if (!isDown)
            {
                top.transform.position -= new Vector3(0, 0.3f, 0) * Time.deltaTime;
            }
        }
    }
      }
    public void OnTriggerEnter(Collider gameobject)
    {
        if (gameobject.gameObject.tag == "Player")
        {
            triggert = true;
        }
    }
    public void RandomButtonSpawn()
    {
        int spawn = Random.Range(0, spawnpoints.Length);
        gameObject.transform.position = spawnpoints[spawn].transform.position;
    }
}
