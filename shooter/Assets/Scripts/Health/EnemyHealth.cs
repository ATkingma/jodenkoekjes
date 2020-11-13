using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : BaseHealthScript
{
    public override void ReceiveDamage(float amount)
    {
        if (list.itemQuantity[13] > 0)
        {
            CalculateExecute();
        }
        health = Mathf.Clamp(health - amount, 0, maxHealth);
        Transform text = Instantiate(popup, transform.position, Quaternion.identity, transform);
        text.GetComponent<DamagePopup>().damageAmount = amount;

        if (health == 0 || health <= executebelow)
        {
            Die();
        }
    }
    public void Die()
    {
        print("Je die is dood!");
    }
    public void CalculateExecute()
    {
        executebelow = maxMaxHealth / 20 * list.itemQuantity[13];
    }
}
