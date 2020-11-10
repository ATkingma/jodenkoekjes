using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<BaseHealthScript>())
        {
            other.GetComponent<BaseHealthScript>().ReceiveDamage(damage);
        }
    }
}
