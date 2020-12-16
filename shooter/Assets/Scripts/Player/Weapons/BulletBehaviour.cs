using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float damage, normalHitRange, explosionRange, executePrecent, explosionCount;
    public bool explode;
    public GameObject explosionRadius;
    public float speed;
    public LayerMask mask;
    public int weaponUsed, richocetAmount;
    public Rigidbody rb;

    //privates
    private Vector3 prefLocation;
    private Transform dontTouch;
    private Vector3 thisWay;

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
            if (hitcollider.GetComponent<EnemyHealth>())
            {
                hitcollider.GetComponent<EnemyHealth>().ReceiveDamage(damage, weaponUsed);
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
                    if(hit.transform != dontTouch)
                    {
                        if(richocetAmount > 0)
                        {
                            Rigidbody clone = Instantiate(rb, hit.point, Quaternion.identity);
                            clone.GetComponent<BulletBehaviour>().DoNotHit(hit.transform);
                            richocetAmount--;
                            Collider[] UwUs = Physics.OverlapSphere(hit.point, 10000);
                            foreach (Collider UwU in UwUs)
                            {
                                print(UwU);
                                if (UwU.tag == "Enemy")
                                {
                                    float dist = Vector3.Distance(clone.transform.position, UwU.transform.position);
                                    thisWay = UwU.transform.position;
                                    //if (dist < lastDist)
                                    //{
                                    //    lastDist = dist;
                                    //    thisWay = UwU.transform.position;
                                    //}
                                }
                            }
                            clone.transform.LookAt(thisWay + new Vector3(0,2,0));
                            clone.GetComponent<BulletBehaviour>().speed = speed;
                            clone.GetComponent<BulletBehaviour>().damage = damage;
                            clone.GetComponent<BulletBehaviour>().explosionCount = explosionCount;
                            clone.GetComponent<BulletBehaviour>().weaponUsed = weaponUsed;
                            clone.GetComponent<BulletBehaviour>().richocetAmount = richocetAmount;
                        }
                        HitEnemy(hit.point);
                    }
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
        prefLocation = transform.position;
    }
    public void DoNotHit(Transform gammie)
    {
        dontTouch = gammie;
    }
}
