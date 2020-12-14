using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemie : MonoBehaviour
{
    //public
    public bool goblin, groot, ranged,boss,golem;
    public GameObject enemy;
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
            if (golem)
            {
                enemy.GetComponent<Goblin>().PlayerInTrigger = true;
            }
        }
        if (golem)
        {
            if (gameobject.gameObject.tag == "Goblin")
            {
                enemy.GetComponent<Goblin>().goblinInTrigger = true;
                Destroy(gameobject);
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
            if (golem)
            {
                enemy.GetComponent<Goblin>().PlayerInTrigger = false;
            }
        }
        if (golem)
        {
            if (gameobject.gameObject.tag == "Goblin")
            {
                enemy.GetComponent<Goblin>().goblinInTrigger = false;
                //doe hier 1 en de bools
            }
        }
    }
}
//als goblin in box zit
//destroy die
//en zet bool aan dat die aan het gooien is
//als player in zit sla die
//onder tussen gooi de goblins naar de player hoe

//zet bool aan
//pak hem op
//zet de gene in de hand aan
//kijk 1 keer naar de player voordat je gaat gooien
//dan instantiate op het goeie moment op de positie in de hand die goblin met scripts enz
//en geef zijn rigid body velocity omhoog zodat dat gebeurt met een soort boogje
//zet bool uit

