using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : BaseHealthScript
{
    public override void ReceiveDamage(float amount, int usedWeapon)
    {
        if(list.itemQuantity[8] > 0)
        {
            FindObjectOfType<PlayerHealth>().Heal(amount * (0.1f * list.itemQuantity[14]));
        }
        if (list.itemQuantity[7] > 0)
        {
            CalculateExecute();
        }
        health = Mathf.Clamp(health - amount, 0, maxHealth);

        //damage numbers
        if (damageNumbersBool)
        {
            Transform text = Instantiate(popup, transform.position + new Vector3(0, popupheight, 0), Quaternion.identity);
            text.GetComponent<DamagePopup>().damageAmount = amount;
        }

        if (health == 0 || health <= executebelow)
        {
            FindObjectOfType<Saves>().AddKilledBy(usedWeapon);
        }
    }
    public void DifficultyIncrease(int UwU)
    {
        //health * min + bosses killed
        maxHealth *= 1 + (0.1f * UwU) + (0.1f * PlayerPrefs.GetInt("bossesKilled", 0));
        health *= 1 + (0.1f * UwU) + (0.1f * PlayerPrefs.GetInt("bossesKilled", 0));
        maxMaxHealth *= 1 + (0.1f * UwU) + (0.1f * PlayerPrefs.GetInt("bossesKilled", 0));
    }
}
