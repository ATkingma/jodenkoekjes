using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutMapDamageScript : MonoBehaviour
{
    private void OnTriggerStay(Collider gameobject)
    {
        if (gameobject.gameObject.tag == "Player")
        {
            gameobject.GetComponent<PlayerHealth>().ReceiveDamage(2.2f*Time.deltaTime/0.15f, 0);
        }
    }    
}