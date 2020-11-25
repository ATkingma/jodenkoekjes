using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemieScript : MonoBehaviour
{
    //public
    public float attackCoolDown, damageValue;
    public Animator anim;
    //private
    private GameObject player;
    private bool doingDamage, isAtacking, PlayerInTrigger,death,doingDead, deathIsDoing;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (GetComponent<EnemyHealth>().health <= 0)
        {
            death = true;
            if (!doingDead)
            {
                if (!deathIsDoing)
                {

            Death();
                }

            }
        }
        if (!death)
        {
            float dist = Vector3.Distance(player.transform.position, transform.position);
            if (dist <= 4)
            {

                if (isAtacking == false)
                {
                    if (PlayerInTrigger == true)
                    {
                        Attacking();
                        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
                        agent.destination = gameObject.transform.position;
                    }
                }
            }
            if (dist >= 5.4f)
            {
                ResetAnim();
                UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
                agent.destination = player.transform.position;

                Vector3 forward = transform.TransformDirection(Vector3.forward);
                Vector3 toOther = player.transform.position - transform.position;
                if (Vector3.Dot(forward, toOther) < 0)
                {
                    gameObject.transform.LookAt(player.transform);
                }
            }
        }
    }
    public void Attacking()
    {
        if (doingDamage == false)
        {
            Invoke("DoDamage", 0.5f);
            Invoke("DoDamage2", 1);
            Atack();
        }
        isAtacking = true;
    }

    //damage
    public void DoDamage()
    {
        Invoke("Resset", attackCoolDown);
        Invoke("DoTaunt", attackCoolDown / 2);
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist <= 6.4f)
        {
            Collider[] hit = Physics.OverlapSphere(transform.position + transform.forward + transform.up * 2, 2);
            foreach (Collider hitCollider in hit)
            {
                if (hitCollider.gameObject.tag == "Player")
                {
                    hitCollider.GetComponent<PlayerHealth>().ReceiveDamage(damageValue);
                }
            }
        }
        doingDamage = true;
    }
    public void DoDamage2()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist <= 6.4f)
        {
            Collider[] hit = Physics.OverlapSphere(transform.position + transform.forward + transform.up * 2, 2);
            foreach (Collider hitCollider in hit)
            {
                if (hitCollider.gameObject.tag == "Player")
                {
                    hitCollider.GetComponent<PlayerHealth>().ReceiveDamage(damageValue);
                }
            }
        }
    }
    public void DoTaunt()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist <= 4.5f)
        {
            Taunt();
        }
    }
    public void Resset()
    {
        ResetAnim();
        isAtacking = false;
        doingDamage = false;
    }
    public void Taunt()
    {
        ResetAnim();
        anim.SetBool("IsTaunting", true);
    }
    public void Atack()
    {
        ResetAnim();
        anim.SetBool("IsAttacking", true);
    }
    public void ResetAnim()
    {
        anim.SetBool("IsAttacking", false);
        anim.SetBool("IsTaunting", false);
    }
    public void Death()
    {
        deathIsDoing = true;
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = gameObject.transform.position;
        anim.SetBool("Death", true);
        //hier andere shit
        WhatItemWeGonGet();
        Invoke("IsDeath", 3);
    }
    public void IsDeath()
    {
        Destroy(gameObject);      
    }
   public  void OnTriggerEnter(Collider gameobject)
    {
        if (gameobject.gameObject.tag == "Player")
        {
            PlayerInTrigger = true;
        }
    }
    public void OntriggerExit(Collider gameobject)
    {
        if (gameobject.gameObject.tag == "Player")
        {
            PlayerInTrigger = false;
        }
    }
    public void WhatItemWeGonGet()
    {
        int number=Random.Range(1, 16);
        if (number <= 4)
        {
            print("niks nederlandder");
        }
        if (number <= 8 & number >4)
        {
            print("niks nederlandd");
        }
        if (number <= 12 & number > 8)
        {
            WeaponDrop();
        }
        if (number <= 16 & number > 12)
        {
            ItemDrop();
        }
    }
    public void WeaponDrop()
    {
        int number = Random.Range(1, 16);
        if (number <= 4)
        {
            print("gannu 1");
        }
        if (number <= 8 & number > 4)
        {
            print("gannu 2");
        }
        if (number <= 12 & number > 8)
        {
            print("gannu 3");
        }
    }
    public void ItemDrop()
    {
        int number = Random.Range(1, 16);
        if (number <= 6)
        {
            print("comman");
        }
        if (number <= 12 & number > 6)
        {
            print("comman");
        }
        if (number <= 18 & number > 12)
        {
            print("comman");
        }
        if (number <= 24 & number > 18)
        {
            print("comman");
        }
        if (number <= 26 & number > 24)
        {
            print("rarereder");
        }
        if (number <= 28 & number > 26)
        {
            print("rarereder");
        }
        if (number <= 30 & number > 28)
        {
            print("rarereder");
        }
        if (number <= 32 & number > 30)
        {
            print("rarereder");
        }
        if (number <= 34 & number > 32)
        {
            print("rarereder");
        }
        if (number <= 36 & number > 34)
        {
            print("rarereder");
        }
        if (number <= 38 & number > 36)
        {
            print("rarereder");
        }
    }
}