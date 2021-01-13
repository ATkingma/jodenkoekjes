using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BaseHealthScript : MonoBehaviour
{
    public float maxHealth, executebelow, popupheight;
    public Transform popup;
    public bool damageNumbersBool = true;
    public int difficulty;
    public AudioSource hurt;

    //privates
    public float health, maxMaxHealth;
    public ItemList list;
    private GameObject volume;
    private VolumeProfile prof;

    public virtual void Start()
    {
        maxMaxHealth = maxHealth;
        health = maxHealth;
        list = FindObjectOfType<ItemList>();
        damageNumbersBool = PlayerPrefs.GetInt("damageNumbersBool") != 0;
        volume = GameObject.FindGameObjectWithTag("volume");

        if(GetComponent<Boss>())
        {
            float temp = PlayerPrefs.GetFloat("minuut", 0);
            GetComponent<EnemyHealth>().DifficultyIncrease((int)temp * 3);
        }
    }
    public virtual void ReceiveDamage(float amount, int usedWeapon)
    {
        if(gameObject.tag == "Player")
        {
            amount = Mathf.Clamp(amount - (2 * list.itemQuantity[10]), 0, Mathf.Infinity);
        }
        health = Mathf.Clamp(health - amount, 0, maxHealth);

        if(health == 0)
        {
            if (gameObject.tag == "Player")
            {
                FindObjectOfType<DeathPlayer>().DEAD();
            }
        }
    }
    public virtual void Heal(float amount)
    {
        if(amount < 1)
        {
            amount = 1;
        }
        health = Mathf.Clamp(health + amount, 0, maxHealth);
    }
    private void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        //if(gameObject.tag == "Player")
        //{
        //    prof = volume.GetComponent<Volume>().profile;
        //    Vignette vignette;

        //    if (!prof.TryGet(out vignette)) throw new System.NullReferenceException(nameof(vignette));

        //    vignette.intensity.Override(0.5f);
        //    if (health < maxHealth * 0.3f)
        //    {
        //        float value = Mathf.Clamp((health / 100) * Time.deltaTime, 0, 0.3f);
        //        vignette.intensity.Override(value);
        //    }
        //    else
        //    {
        //        float value = Mathf.Clamp((health / 100) * Time.deltaTime, 0, 0.3f);
        //        vignette.intensity.Override(value);
        //    }
        //}
    }

    //execute
    public void CalculateExecute()
    {
        if(gameObject.tag != "Player")
        {
            executebelow = maxMaxHealth / 20 * list.itemQuantity[7];
        }
    }

    //calaculate
    public void CalculateStats()
    {
        maxHealth = maxMaxHealth + (10 * list.itemQuantity[2]);
        //glasscannon health stat
        if (list.itemQuantity[5] > 0)
        {
            maxHealth = Mathf.Clamp(maxHealth = (maxMaxHealth + (10 * list.itemQuantity[2])) / Mathf.Pow(2, list.itemQuantity[5]), 10, Mathf.Infinity); 
        }
    }
}
