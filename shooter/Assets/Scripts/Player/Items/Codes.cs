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
    }

    //damage
    public void GiveDamage()
    {
        list.itemQuantity[0] += 10;
    }

    //attackspeed
    public void GiveAttackspeed()
    {
        list.itemQuantity[1] += 10;
    }

    //health
    public void GiveHealth()
    {
        list.itemQuantity[1] += 10;
    }
    
    //movementspeed
    public void GiveMovementSpeed()
    {
        list.itemQuantity[1] += 5;
    }

    //double shot
    public void GiveDoubleShot()
    {
        list.itemQuantity[1] += 1;
    }

    //glasscannon
    public void GiveGlasscannon()
    {
        list.itemQuantity[1] += 1;
    }

    //explosive
    public void GiveExplosive()
    {
        list.itemQuantity[1] += 2;
    }

    //exeecute
    public void GiveExecute()
    {
        list.itemQuantity[1] += 2;
    }

    //lifesteal
    public void GiveLifesteal()
    {
        list.itemQuantity[1] += 1;
    }

    //slow bullets
    public void GiveSlowBullets()
    {
        list.itemQuantity[1] += 1;
    }

    //damage reduction
    public void GiveDamageReduction()
    {
        list.itemQuantity[1] += 1;
    }

    //double jump
    public void GiveDoubleJump()
    {
        list.itemQuantity[1] += 1;
    }

    //crit
    public void GiveCrit()
    {
        list.itemQuantity[1] += 4;
    }

    //richocet
    public void GiveRichocet()
    {
        list.itemQuantity[1] += 1;
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
}
