using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemie : MonoBehaviour
{
    //public
    public bool goblin, groot, ranged, boss, golem, fireBoss;
    public GameObject enemy;
    //private
    private bool trowing;
    private GameObject deletingThis;
    private void Update()
    {
        if (golem)
        {
            trowing = enemy.GetComponent<Goblin>().isTrowing;
        }
    }
    public void OnTriggerEnter(Collider gameobject)
    {
        if (gameobject.gameObject.tag == "Player")
        {
            if (goblin)
            {
                enemy.GetComponent<EnemieScript>().PlayerInTrigger = true;
            }
            if (groot)
            {
                enemy.GetComponent<GrootRangedScript>().PlayerInTrigger = true;
            }
            if (ranged)
            {
                enemy.GetComponent<RangedEnemieScript>().PlayerInTrigger = true;
            }
            if (boss)
            {
                enemy.GetComponent<Boss>().PlayerInTrigger = true;
            }
            if (fireBoss)
            {
                enemy.GetComponent<FinalBoss>().PlayerInTrigger = true;
            }
            if (golem)
            {
                enemy.GetComponent<Goblin>().PlayerInTrigger = true;
            }
        }
        if (golem)
        {
            if (gameobject.gameObject.tag == "Goblin")
            {
                if (!trowing)
                {
                    if (enemy.GetComponent<Goblin>().isOnCoolDown == false)
                    {
                        enemy.GetComponent<Goblin>().StartTrow();
                        deletingThis = gameobject.gameObject;
                        Invoke("Destroygoblin", 2.5f);
                    }
                }
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
            }
            if (groot)
            {
                enemy.GetComponent<GrootRangedScript>().PlayerInTrigger = false;
            }
            if (ranged)
            {
                enemy.GetComponent<RangedEnemieScript>().PlayerInTrigger = false;
            }
            if (boss)
            {
                enemy.GetComponent<Boss>().PlayerInTrigger = false;
            }
            if (fireBoss)
            {
                enemy.GetComponent<FinalBoss>().PlayerInTrigger = false;
            }
            if (golem)
            {
                enemy.GetComponent<Goblin>().PlayerInTrigger = false;
            }
        }
    }
    public void Destroygoblin()
    {
        Destroy(deletingThis);
    }
}