using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Codes : MonoBehaviour
{
    public ItemList list;

    //damage/attackspeed/movement/health
    public void Common()
    {
        GiveDamage();
        GiveAttackspeed();
        GiveMovementSpeed();
        GiveHealth();
        UpdateItems();
    }

    //damage
    public void GiveDamage()
    {
        list.itemQuantity[0] += 10;
        UpdateItems();
    }

    //attackspeed
    public void GiveAttackspeed()
    {
        list.itemQuantity[1] += 10;
        UpdateItems();
    }

    //health
    public void GiveHealth()
    {
        list.itemQuantity[2] += 10;
        UpdateItems();
    }
    
    //movementspeed
    public void GiveMovementSpeed()
    {
        list.itemQuantity[3] += 5;
        UpdateItems();
    }

    //double shot
    public void GiveDoubleShot()
    {
        list.itemQuantity[4] += 1;
        UpdateItems();
    }

    //glasscannon
    public void GiveGlasscannon()
    {
        list.itemQuantity[5] += 1;
        UpdateItems();
    }

    //explosive
    public void GiveExplosive()
    {
        list.itemQuantity[6] += 2;
        UpdateItems();
    }

    //exeecute
    public void GiveExecute()
    {
        list.itemQuantity[7] += 2;
        UpdateItems();
    }

    //lifesteal
    public void GiveLifesteal()
    {
        list.itemQuantity[8] += 1;
        UpdateItems();
    }

    //slow bullets
    public void GiveSlowBullets()
    {
        list.itemQuantity[9] += 1;
        UpdateItems();
    }

    //damage reduction
    public void GiveDamageReduction()
    {
        list.itemQuantity[10] += 1;
        UpdateItems();
    }

    //double jump
    public void GiveDoubleJump()
    {
        list.itemQuantity[11] += 1;
        UpdateItems();
    }

    //crit
    public void GiveCrit()
    {
        list.itemQuantity[12] += 4;
        UpdateItems();
    }

    //richocet
    public void GiveRichocet()
    {
        list.itemQuantity[13] += 1;
        UpdateItems();
    }

    //unlock
    public void Skins()
    {
        for(int i = 0; i < 3; i++)
        {
            PlayerPrefs.SetInt("gun" + i, 100);
        }
    }

    //to boss
    public void ToBoss()
    {
        FindObjectOfType<Saves>().SaveEverything();
        SceneManager.LoadScene(5);
    }

    //to final boss
    public void ToFinalBoss()
    {
        FindObjectOfType<Saves>().SaveEverything();
        SceneManager.LoadScene(6);
    }

    public void UpdateItems()
    {
        FindObjectOfType<Trigger>().CalculateStats();
        //damage
        //attackspeed
        //doubleshot
        //explosive
        //slow bullets

        FindObjectOfType<Movement>().CalculateStats();
        //movementspeed

        FindObjectOfType<PlayerHealth>().CalculateStats();
        //+maxhealth
        //execute
        //lifesteal
        //glasscannon

        FindObjectOfType<Index>().AddItem();
    }
}
