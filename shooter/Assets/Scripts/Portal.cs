using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    ///public
    public bool bosmap;
    //privates
    private Saves safe;
    private void Start()
    {
        safe = FindObjectOfType<Saves>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!bosmap)
            {

            FindObjectOfType<Spawner>().SaveTime();
            }
            safe.SaveEverything();
            FindObjectOfType<SceneSwitcher>().SceneLoader();
        }
    }
}
