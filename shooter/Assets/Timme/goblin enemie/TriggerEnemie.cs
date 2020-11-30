using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemie : MonoBehaviour
{
    //public
    public bool goblin, groot, ranged;
    public GameObject enemy;
    public void OnTriggerEnter(Collider gameobject)
    {
        if (gameobject.gameObject.tag == "Player")
        {
            if (goblin)
            {
                enemy.GetComponent<EnemieScript>().PlayerInTrigger = true;
                print("y");
            }
            if (groot)
            {
                enemy.GetComponent<GrootRangedScript>().PlayerInTrigger = true;
            }
            if (ranged)
            {
                enemy.GetComponent<RangedEnemieScript>().PlayerInTrigger = true;
            }
        }
    }
    public void OnTriggerExit(Collider gameobject)
    {
        if (gameobject.gameObject.tag == "Player")
        {
            if (goblin)
            {
                enemy.GetComponent<EnemieScript>().PlayerInTrigger = false;
                print("n");
            }
            if (groot)
            {
                enemy.GetComponent<GrootRangedScript>().PlayerInTrigger = false;
            }
            if (ranged)
            {
                enemy.GetComponent<RangedEnemieScript>().PlayerInTrigger = false;
            }
        }
    }
}
