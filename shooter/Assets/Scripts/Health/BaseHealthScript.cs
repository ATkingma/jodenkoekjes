﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealthScript : MonoBehaviour
{
    public float maxHealth, executebelow, popupheight;
    public Transform popup;
    public bool damageNumbersBool = true;
    public int difficulty;
    public AudioSource hurt;

    //privates
    public float health, maxMaxHealth;
    public ItemList list;

    public virtual void Start()
    {
        maxMaxHealth = maxHealth;
        health = maxHealth;
        list = FindObjectOfType<ItemList>();
        damageNumbersBool = PlayerPrefs.GetInt("damageNumbersBool") != 0;

        if(GetComponent<Boss>())
        {
            float temp = PlayerPrefs.GetFloat("minuut", 0);
            GetComponent<EnemyHealth>().DifficultyIncrease((int)temp * 3);
        }
    }
    public virtual void ReceiveDamage(float amount, int usedWeapon)
    {
        if(gameObject.tag != "Player")
        {
            amount = Mathf.Clamp(amount - 2 * list.itemQuantity[10], 0, Mathf.Infinity);
        }
        else
        {
            health = Mathf.Clamp(health - amount, 0, maxHealth);
        }


        if(health == 0)
        {
            print("moet inheritance gebruiken!");
        }
    }
    public virtual void Heal(float amount)
    {
        health = Mathf.Clamp(health + amount, 0, maxHealth);
    }
    private void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
    }

    //execute
    public void CalculateExecute()
    {
        if(gameObject.tag != "Player")
        {
            executebelow = maxMaxHealth / 20 * list.itemQuantity[7];
        }
    }

    //calaculate
    public void CalculateStats()
    {
        maxHealth = maxMaxHealth + (10 * list.itemQuantity[2]);
        //glasscannon health stat
        if (list.itemQuantity[5] > 0)
        {
            maxHealth = Mathf.Clamp(maxHealth = (maxMaxHealth + (10 * list.itemQuantity[2])) / Mathf.Pow(2, list.itemQuantity[5]), 10, Mathf.Infinity); 
        }
    }
}
