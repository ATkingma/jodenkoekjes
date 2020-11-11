using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealthScript : MonoBehaviour
{
    public float maxHealth;

    //privates
    protected float health, maxMaxHealth;
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
}
