using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    ///public
    public bool bosmap, finalbossmapfu;
    //privates
    private Saves safe;
    private int levelscom;
    private void Start()
    {
        safe = FindObjectOfType<Saves>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!finalbossmapfu)
            {


                if (!bosmap)
                {

                    FindObjectOfType<Spawner>().SaveTime();
                }
                safe.SaveEverything();
                levelscom = PlayerPrefs.GetInt("levels", 0);
                levelscom++;
                PlayerPrefs.SetInt("levels", levelscom);
                FindObjectOfType<SceneSwitcher>().SceneLoader();
            }
        }
        if (finalbossmapfu)
        {
            FindObjectOfType<FinalBossLevelObliveration>().StartOb();            
        }
    }
}
