using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealthScript : MonoBehaviour
{
    public float maxHealth, executebelow, popupheight;
    public Transform popup;

    //privates
    public float health, maxMaxHealth;
    protected ItemList list;

    private void Start()
    {
        maxMaxHealth = maxHealth;
        health = maxHealth;
        list = FindObjectOfType<ItemList>();
    }
    public virtual void ReceiveDamage(float amount)
    {
        health = Mathf.Clamp(health - amount, 0, maxHealth);

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
            executebelow = maxMaxHealth / 20 * list.itemQuantity[13];
        }
    }

    //calaculate
    public void CalculateStats()
    {
        maxMaxHealth = maxMaxHealth + (10 * list.itemQuantity[2]);
        maxHealth = maxMaxHealth;
        //glasscannon health stat
        if (list.itemQuantity[11] > 0)
        {
            maxHealth = maxMaxHealth / Mathf.Pow(2, list.itemQuantity[11]);
        }
    }
}
