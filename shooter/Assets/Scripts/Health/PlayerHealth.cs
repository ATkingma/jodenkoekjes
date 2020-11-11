using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : BaseHealthScript
{
    public void CalculateStats()
    {
        maxMaxHealth = maxMaxHealth + (10 * list.itemQuantity[2]);
        maxHealth = maxMaxHealth;
        //glasscannon health stat
        float lastGlassCannon = 0;
        if (list.itemQuantity[11] > lastGlassCannon)
        {
            lastGlassCannon = list.itemQuantity[11];
            maxHealth = maxMaxHealth / Mathf.Pow(2, list.itemQuantity[11]);
        }
    }
}
