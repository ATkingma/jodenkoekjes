﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    //public
    public float attackCoolDown, damageValue;
    public Animator anim;
    public bool PlayerInTrigger, isAtacking, goblinInTrigger, isTrowing,isOnCoolDown;
    public GameObject goblinToSpawn, goblinSpawn, goblinToSetActive;

    public AudioSource walking,trowing,smacking,dying,taunting;
    //private
    private GameObject player, itemHolder, lookat;
    private bool doingDamage, death, doingDead, deathIsDoing, didto0;
    private float coolDownTime = 15,placholder;
    void Start()
    {
        lookat = GameObject.FindGameObjectWithTag("LookAPlayer");
        player = GameObject.FindGameObjectWithTag("Player");
        itemHolder = GameObject.FindGameObjectWithTag("GameManager");
        goblinToSetActive.SetActive(false);
    }
    void Update()
    {
        if (GetComponent<EnemyHealth>().health <= GetComponent<EnemyHealth>().executebelow)
        {
            if (!didto0)
            {
                GetComponent<EnemyHealth>().health = 0;
            }
        }
        if (GetComponent<EnemyHealth>().health <= 0)
        {
            death = true;
            if (!doingDead)
            {
                if (!deathIsDoing)
                {
                    FindObjectOfType<Saves>().AddKill(4); //goblin
                    FindObjectOfType<Spawner>().enemiesAlive--;
                    Death();
                }
            }
        }
        if (!death)
        {

            CoolDown();
            float dist = Vector3.Distance(player.transform.position, transform.position);
            if (dist <= 4)
            {
                if (!isAtacking)
                {
                    if (!PlayerInTrigger)
                    {
                        if (!isTrowing)
                        {
                            UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
                            if (agent.velocity.sqrMagnitude > Mathf.Epsilon)
                            {
                                if (dist <= 1)
                                {
                                    transform.rotation = Quaternion.LookRotation(agent.velocity.normalized);
                                }
                            }
                        }
                    }
                    if (PlayerInTrigger == true)
                    {
                        if (!isTrowing)
                        {
                            Attacking();
                        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
                        agent.destination = gameObject.transform.position;
                            }
                    }
                }
            }
            if (!isTrowing)
            {
                if (dist <= 1)
                {
                    UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
                    if (agent.velocity.sqrMagnitude > Mathf.Epsilon)
                    {
                        transform.rotation = Quaternion.LookRotation(agent.velocity.normalized);
                    }
                }
                if (dist <= 1)
                {
                    UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
                    agent.destination = gameObject.transform.position;
                }
                if (dist >= 2.4f)
                {
                    ResetAnim();
                    UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
                    agent.destination = player.transform.position;

                    Vector3 forward = transform.TransformDirection(Vector3.forward);
                    Vector3 toOther = player.transform.position - transform.position;
                    if (Vector3.Dot(forward, toOther) < 0)
                    {

                        gameObject.transform.LookAt(lookat.transform);
                        if (agent.velocity.sqrMagnitude > Mathf.Epsilon)
                        {
                            transform.rotation = Quaternion.LookRotation(agent.velocity.normalized);
                        }

                    }
                }
            }
        }
    }
    public void Attacking()
    {
        if (doingDamage == false)
        {
                Invoke("DoDamage", 0.5f);
            Atack();
        }
        isAtacking = true;
    }
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
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        isAtacking = false;
        doingDamage = false;
        gameObject.transform.LookAt(lookat.transform);
        if (agent.velocity.sqrMagnitude > Mathf.Epsilon)
        {
            transform.rotation = Quaternion.LookRotation(agent.velocity.normalized);
        }
    }
    public void Taunt()
    {
        ResetAnim();
        anim.SetBool("IsTaunting", true);
        taunting.Play();
    }
    public void Atack()
    {
        ResetAnim();
        anim.SetBool("IsAttacking", true);
        smacking.Play();
        Invoke("AudioSecondhit", 1.2f);
    }
    public void AudioSecondhit()
    {
        smacking.Play();
    }
    public void ResetAnim()
    {
        anim.SetBool("IsAttacking", false);
        anim.SetBool("IsTaunting", false);
        anim.SetBool("isTrowing", false);
        anim.SetBool("isPickingUp", false);        
    }
    public void Death()
    {
        deathIsDoing = true;
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = gameObject.transform.position;
        anim.SetBool("Death", true);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        itemHolder.GetComponent<Spawner>().enemiesDied++;
        dying.Play();
        WhatItemWeGonGet();
        Invoke("IsDeath", 3);
    }
    public void IsDeath()
    {
        Destroy(gameObject);
    }
    public void WhatItemWeGonGet()
    {
        int number = Random.Range(1, 16);
        if (number <= 4)
        {
            WeaponDrop();
        }
        if (number <= 8 & number > 4)
        {
            ItemDrop();
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
        int number = Random.Range(1, 12);
        if (number <= 4)
        {
            Instantiate(itemHolder.GetComponent<ItemHolder>().guns[0], gameObject.transform.position, Quaternion.identity);
        }
        if (number <= 8 & number > 4)
        {
            Instantiate(itemHolder.GetComponent<ItemHolder>().guns[1], gameObject.transform.position, Quaternion.identity);
        }
        if (number <= 12 & number > 8)
        {
            Instantiate(itemHolder.GetComponent<ItemHolder>().guns[2], gameObject.transform.position, Quaternion.identity);
        }
    }
    public void ItemDrop()
    {
        int number = Random.Range(1, 36);
        if (number <= 8)
        {
            Instantiate(itemHolder.GetComponent<ItemHolder>().comonItems[0], gameObject.transform.position, Quaternion.identity);
        }
        if (number <= 16 & number > 8)
        {
            Instantiate(itemHolder.GetComponent<ItemHolder>().comonItems[1], gameObject.transform.position, Quaternion.identity);
        }
        if (number <= 24 & number > 16)
        {
            Instantiate(itemHolder.GetComponent<ItemHolder>().comonItems[2], gameObject.transform.position, Quaternion.identity);
        }
        if (number <= 26 & number > 24)
        {
            Instantiate(itemHolder.GetComponent<ItemHolder>().rareItems[0], gameObject.transform.position, Quaternion.identity);
        }
        if (number <= 28 & number > 26)
        {
            Instantiate(itemHolder.GetComponent<ItemHolder>().rareItems[1], gameObject.transform.position, Quaternion.identity);
        }
        if (number <= 30 & number > 28)
        {
            Instantiate(itemHolder.GetComponent<ItemHolder>().rareItems[2], gameObject.transform.position, Quaternion.identity);
        }
        if (number <= 32 & number > 30)
        {
            Instantiate(itemHolder.GetComponent<ItemHolder>().rareItems[3], gameObject.transform.position, Quaternion.identity);
        }
        if (number <= 34 & number > 32)
        {
            Instantiate(itemHolder.GetComponent<ItemHolder>().rareItems[4], gameObject.transform.position, Quaternion.identity);
        }
        if (number <= 36 & number > 34)
        {
            Instantiate(itemHolder.GetComponent<ItemHolder>().rareItems[5], gameObject.transform.position, Quaternion.identity);
        }
        if (number <= 38 & number > 36)
        {
            Instantiate(itemHolder.GetComponent<ItemHolder>().rareItems[6], gameObject.transform.position, Quaternion.identity);
        }
    }
    public void StartTrow()
    {
        isTrowing = true;
        GrabGoblin();
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = gameObject.transform.position;
        Invoke("On", 2.5f);
        Invoke("Off", 9.5f);
        Invoke("Spawn", 9.55f);
    }
    public void GrabGoblin()
    {
        Invoke("TrowGoblin", 6);
        ResetAnim();
        anim.SetBool("isPickingUp", true);
    }
    public void TrowGoblin()
    {
        Invoke("ResetTrow", 5);
        anim.SetBool("isTrowing", true);
    }
    public void ResetTrow()
    {
        ResetAnim();
        isTrowing = false;
        isOnCoolDown = true;
        placholder = coolDownTime += Time.deltaTime;
    }
    public void Off()
    {
        goblinToSetActive.SetActive(false);
    }
    public void On()
    {
        goblinToSetActive.SetActive(true);
    }
    public void Spawn()
    {
        Instantiate(goblinToSpawn, goblinSpawn.transform.position, Quaternion.identity);
        trowing.Play();
    }
    public void CoolDown()
    {
        if (placholder < Time.deltaTime)
        {
            isOnCoolDown = false;
        }
    }
    public void DAMAge()
    {
        if(PlayerInTrigger)
        {
            player.GetComponent<PlayerHealth>().ReceiveDamage(damageValue, 0);
        }
    }
}