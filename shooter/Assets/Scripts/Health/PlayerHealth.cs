using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : BaseHealthScript
{
    public void CalculateStats()
    {
        maxHealth = maxHealth * (1 + (10 * list.itemQuantity[2]));
    }
}
