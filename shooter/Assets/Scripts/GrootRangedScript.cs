using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GrootRangedScript : MonoBehaviour
{
    //publics
    public int tester;
    public float attackCoolDown;
    public Animator anim;
    public GameObject defenceSphere, attackline_1, attackline_2, idleLine_1, idleLine_2;
    public bool PlayerInTrigger;
    //privates
    private bool playerIsClose, doingDamage, didto0, isAtacking, death, doingDead, settingLine,doingIdle, deathIsDoing;
    private GameObject player, itemHolder;
    private float speed;
    RaycastHit hit;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        speed = GetComponent<NavMeshAgent>().speed;
        defenceSphere.SetActive(false);
        Invoke("LookAtHim", 0.5f);
        itemHolder = GameObject.FindGameObjectWithTag("GameManager");
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
                    Death();
                }
            }
        }
        if (!death)
        {
            if (settingLine)
            {
                attackline_1.GetComponent<LineRenderer>().SetPosition(0, attackline_1.transform.position);
                attackline_2.GetComponent<LineRenderer>().SetPosition(0, attackline_2.transform.position);
            }
            if (doingIdle)
            {
                idleLine_1.SetActive(true);
                idleLine_1.GetComponent<LineRenderer>().SetPosition(1, idleLine_1.transform.position);
                idleLine_1.GetComponent<LineRenderer>().SetPosition(0, idleLine_2.transform.position);               
            }
            float dist = Vector3.Distance(player.transform.position, transform.position);
            if (dist <= 10)
            {
                playerIsClose = true;
                GetComponent<NavMeshAgent>().speed = 0;
            }
            if (dist >= 12)
            {
                playerIsClose = false;
                GetComponent<NavMeshAgent>().speed = speed;
            }
            if (playerIsClose == true)
            {
                if (PlayerInTrigger == true)
                {
                    if (isAtacking == false)
                    {
                        Attacking();
                    }
                }
            }
            if (playerIsClose == false)
            {
                UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
                agent.destination = player.transform.position;
                ResetAnim();
                isAtacking = false;
                doingDamage = false;
                attackline_1.SetActive(false);
                attackline_2.SetActive(false);
                doingIdle = false;
                settingLine = false;
                idleLine_1.SetActive(false);
                idleLine_2.SetActive(false);
                defenceSphere.SetActive(false);
            }
            if (playerIsClose == true)
            {
                if (Physics.Raycast(transform.position, transform.forward, out hit, 10))
                {
                }
                else
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
            DoDamage();
            Atack();
        }
        isAtacking = true;
    }
    public void DoDamage()
    {
        Invoke("DoTaunt", attackCoolDown / 2);
        doingDamage = true;
    }
    public void DoTaunt()
    {
        Taunt();
    }
    public void Resset()
    {
        ResetAnim();
        isAtacking = false;
        doingDamage = false;
        attackline_1.SetActive(false);
        attackline_2.SetActive(false);
        doingIdle = false;
        settingLine = false;
        idleLine_1.SetActive(false);
        idleLine_2.SetActive(false);
        defenceSphere.SetActive(false);
    }
    public void Taunt()
    {
        ResetAnim();
        if (playerIsClose == true)
        {
            RandomTaunt();
        }   
    }
    public void LookAtHim()
    {
        gameObject.transform.LookAt(player.transform);
    }
    public void RandomTaunt()
    {
        float RandomIdle = Random.Range(1, 3);
        if (RandomIdle == 1)
        {
            anim.SetBool("IsTaunting", true);
            doingIdle = true;
            Invoke("Resset", 11);
            attackline_1.SetActive(false);
            attackline_2.SetActive(false);
        }
        if (RandomIdle == 2)
        {
            anim.SetBool("IsTaunting", true);
            doingIdle = true;
            Invoke("Resset", 11);
            attackline_1.SetActive(false);
            attackline_2.SetActive(false);
        }
        if (RandomIdle == 3)
        {
            Invoke("DefenceShieldOn",2);
            anim.SetBool("isDefending", true);
            Invoke("Resset", 6);
            attackline_1.SetActive(false);
            attackline_2.SetActive(false);
        }
    }
    public void Atack()
    {      
        ResetAnim();
        anim.SetBool("IsAttacking", true);
        Invoke("DoLine", 1.5f);
    }
    public void DoLine()
    {
        settingLine = true;
        attackline_1.GetComponent<LineRenderer>().SetPosition(1, player.transform.position);
        attackline_2.GetComponent<LineRenderer>().SetPosition(1, player.transform.position);
        attackline_1.SetActive(true);
        attackline_2.SetActive(true);
    }
    public void Death()
    {
        deathIsDoing = true;
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = gameObject.transform.position;
        anim.SetBool("Death", true);
        //hier andere shit
        itemHolder.GetComponent<Spawner>().enemiesDied++;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        WhatItemWeGonGet();
        Invoke("IsDeath", 3);
    }
    public void IsDeath()
    {
        Destroy(gameObject);
    }
    public void ResetAnim()
    {
        anim.SetBool("isDefending", false);
        anim.SetBool("IsAttacking", false);
        anim.SetBool("IsTaunting", false);
    }
    public void DefenceShieldOn()
    {
        defenceSphere.SetActive(true);
    }
    public void WhatItemWeGonGet()
    {
        int number = Random.Range(1, 16);
        if (number <= 4)
        {
            print("niks nederlandder");
        }
        if (number <= 8 & number > 4)
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
        int number = Random.Range(1, 16);
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
}
///beter leaves textures