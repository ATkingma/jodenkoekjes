using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UMayAttack : MonoBehaviour
{
    void Start()
    {
        Invoke("CanAttack", 2.5f);
        GetComponent<TriggerEnemie>().enabled = false;
    }
    public void CanAttack()
    {
        GetComponent<TriggerEnemie>().enabled=true;
    }
    
}
