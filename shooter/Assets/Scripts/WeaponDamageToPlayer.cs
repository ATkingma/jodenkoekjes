using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WeaponDamageToPlayer : MonoBehaviour
{
    //public
    public GameObject Enemie;
    //private
    private bool doingDamage;
    public void OnTriggerEnter(Collider gameobject)
    {
        if (gameobject.gameObject.tag == "Player")
        {
            if (Enemie.GetComponent<EnemieScript>().isAtacking) 
            {
                if (Enemie.GetComponent<EnemieScript>().PlayerInTrigger)
                {
                    if (!doingDamage)
                    {
                        DoDamage();
                    }
                }
            }
        }
    }
    public void DoDamage()
    {
        doingDamage = true;
        print("hoere veel damage op u moeder");
        Invoke("Resettt", 3);
    }
    public void Resettt()
    {
        doingDamage = false;
    }
}