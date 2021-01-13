using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    //private
    private GameObject[] spawnpoints;

    void Start()
    {
        spawnpoints = GameObject.FindGameObjectsWithTag("PlayerSpawnPoints");
        RandomButtonSpawn();
    }
    public void RandomButtonSpawn()
    {
        int spawn = Random.Range(0, spawnpoints.Length);
        gameObject.transform.position = spawnpoints[spawn].transform.position;
    }
}
