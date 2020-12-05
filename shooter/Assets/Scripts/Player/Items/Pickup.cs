using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float item;

    //private
    private Index index;

    private void Start()
    {
        index = FindObjectOfType<Index>();
        StatChanges();
    }
    public void OnTriggerEnter(Collider player)
    {
        if(player.tag == "Player")
        {
            player.GetComponent<ItemList>().itemQuantity[(int)item] += 1;
            StatChanges();
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
