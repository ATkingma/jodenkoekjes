using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : BaseHealthScript
{
    public override void ReceiveDamage(float amount)
    {
        health = Mathf.Clamp(health - amount, 0, maxHealth);

        if (health >= 0)
        {
            print("enemy krijgt ouwie");
        }
    }

}
