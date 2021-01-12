using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float item;
    public List<float> itemStats;

    //private
    private Index index;

    private void Start()
    {
        index = FindObjectOfType<Index>();
        Invoke("StatChanges", 0.1f);
    }
    public void OnTriggerEnter(Collider player)
    {
        if(player.tag == "Player")
        {
            player.GetComponent<ItemList>().itemQuantity[(int)item] += 1;
            player.GetComponent<ItemList>().PrintItemInChat((int)item);
            StatChanges();
            //stats
            for(int i = 0; i < itemStats.Count; i++)
            {
                itemStats[i] = PlayerPrefs.GetFloat("itemstats" + i, 0);
            }
            itemStats[0]++;
            itemStats[(int)item]++;
            for (int i = 0; i < itemStats.Count; i++)
            {
                PlayerPrefs.SetFloat("itemstats" + i, itemStats[i]);
            }
            Destroy(gameObject);
        }
    }
    public void StatChanges()
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

        index.AddItem();
    }

    private void Update()
    {
        transform.Rotate(0, 100 * Time.deltaTime, 0);
    }
}
