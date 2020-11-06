using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float item;

    public void OnTriggerEnter(Collider player)
    {
        if(player.tag == "Player")
        {
            player.GetComponent<ItemList>().itemQuantity[(int)item] += 1;
            Destroy(gameObject);
        }
    }
}
