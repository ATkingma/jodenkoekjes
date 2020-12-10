﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float damage, normalHitRange, explosionRange, executePrecent, explosionCount;
    public bool explode;
    public GameObject explosionRadius;
    public float speed;
    public LayerMask mask;

    //privates
    private Vector3 prefLocation;

    private void Start()
    {
        Destroy(gameObject, 10);
        if(gameObject.tag == "ijs")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            gameObject.transform.LookAt(player.transform);
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = transform.forward * speed;
        }
        else
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = transform.forward * speed;
            //rb.velocity = new Vector3(transform.forward.x + Random.Range(-spread, spread), transform.forward.x + Random.Range(-0.1f, 0.1f), 1 * transform.forward.z) * speed;
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
            if(Physics.Raycast(transform.position, transform.forward, out hit, 1, mask))
            {
                if (hit.transform.tag == "Enemy")
                {
                    HitEnemy(hit.point);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
        prefLocation = transform.position;
    }
}
