using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float damage, normalHitRange, explosionRange;
    public bool explode;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            HitEnemy(other.transform.position);
        }
    }
    public void HitEnemy(Vector3 pos)
    {
        if (explode)
        {
            normalHitRange = explosionRange;
        }
        else
        {
            normalHitRange = 1;
        }
        Collider[] hitcolliders = Physics.OverlapSphere(transform.position, normalHitRange);
        foreach (Collider hitcollider in hitcolliders)
        {
            if (hitcollider.GetComponent<BaseHealthScript>())
            {
                hitcollider.GetComponent<BaseHealthScript>().ReceiveDamage(damage);
            }
        }
        Destroy(gameObject);
    }
}
