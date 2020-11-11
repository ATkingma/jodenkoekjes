using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public bool SpawnAble;
    void Start()
    {
        SpawnAble = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider gameobject)
    {
        if (gameobject.gameObject.tag == "Wall")
        {
            SpawnAble = false;
        }
    }
    public void OntriggerExit(Collider gameobject)
    {
        if (gameobject.gameObject.tag == "Wall")
        {
            SpawnAble = true;
        }
    }
}
