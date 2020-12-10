using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeReference : MonoBehaviour
{
    public float baseAttackSpeed, baseDamage, hitRange;

    public Transform attackPos;

    public Vector3 attack;

    public void Fire1(float damage)
    {
        transform.Rotate(attack);
        Collider[] hitcolliders = Physics.OverlapSphere(attackPos.position, hitRange);
        foreach (Collider hitcollider in hitcolliders)
        {
            if (hitcollider.GetComponent<EnemyHealth>())
            {
                hitcollider.GetComponent<EnemyHealth>().ReceiveDamage(damage);
            }
        }
        Invoke("Return", 0.2f);
    }
    public void Return()
    {
        transform.Rotate(-attack);
    }
}
