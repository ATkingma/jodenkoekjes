using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class TimeTime : MonoBehaviour
{
    public float timeToSafe;
    public bool volgendee;
    public bool clearndieshit;

    public void Update()
    {
        if (volgendee)
        {
            SceneManager.LoadScene(1);
        }
        if (clearndieshit)
        {
            PlayerPrefs.SetFloat("TimeSaved", 0f);
        }
        timeToSafe += Time.deltaTime;
    }
    void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("TimeSaved", timeToSafe);
    }
}
//risk of rain type beat
//safe time
//als alle enemys dood zijn die gespawned zijn nieuwe
//als alle enemies == enemies to kill
//enemies to kill gaat door tot???


    //op tijd spawnen tijd==gesaved
    // niet zo dat je kan uitrekenen wnr die spawned
    //max enemies die je mag spawnen omhoog
    //speler moet t niet te makkelijk krijgen
    //overtijd ook meer enemies laten spawnen
