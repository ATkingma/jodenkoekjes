using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float damage, normalHitRange, explosionRange, executePrecent, explosionCount;
    public bool explode;
    public GameObject explosionRadius;

    //privates
    private Vector3 prefLocation;

    private void Start()
    {
        Destroy(gameObject, 10);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            HitEnemy(transform.position);
        }
    }
    public void HitEnemy(Vector3 pos)
    {
        if (explode)
        {
            normalHitRange = explosionRange * explosionCount;
            GameObject boom = Instantiate(explosionRadius, pos, Quaternion.identity);
            boom.transform.localScale = new Vector3(normalHitRange, normalHitRange, normalHitRange) * 2;
            Destroy(boom, 0.1f);
        }
        else
        {
            normalHitRange = 0.2f;
        }
        Collider[] hitcolliders = Physics.OverlapSphere(pos, normalHitRange);
        foreach (Collider hitcollider in hitcolliders)
        {
            if (hitcollider.GetComponent<BaseHealthScript>())
            {
                hitcollider.GetComponent<BaseHealthScript>().ReceiveDamage(damage);
            }
        }
        Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        if(prefLocation != Vector3.zero)
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.forward, out hit, 1))
            {
                if (hit.transform.tag == "Enemy")
                {
                    HitEnemy(hit.point);
                }
            }
        }
        prefLocation = transform.position;
    }
}
