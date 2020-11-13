﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : BaseHealthScript
{
    public override void ReceiveDamage(float amount)
    {
        health = Mathf.Clamp(health - amount, 0, maxHealth);
        Transform text = Instantiate(popup, transform.position, Quaternion.identity, transform);
        text.GetComponent<DamagePopup>().damageAmount = amount;

        if (health == 0)
        {
            
        }
    }

}
