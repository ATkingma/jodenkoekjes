using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedEnemieScript : MonoBehaviour
{
    //publics
    public float attackCoolDown;
    public Animator anim;
    public GameObject magicBall, balPosition, shield;
        public bool PlayerInTrigger;
    //privates
    private bool playerIsClose, doingDamage, isAtacking,death, doingDead, deathIsDoing, didto0;
    private GameObject player, itemHolder;
    private float speed;
    RaycastHit hit;
    void Start()
    {       
        player = GameObject.FindGameObjectWithTag("Player");
        speed = GetComponent<NavMeshAgent>().speed;
        balPosition.GetComponent<MeshRenderer>().enabled = false;
        shield.SetActive(false);
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
                    FindObjectOfType<Saves>().AddKill(2); //fire
                    Death();

                }

            }
        }
        if (!death)
        {
            float dist = Vector3.Distance(player.transform.position, transform.position);
            if (dist <= 20)
            {               
                gameObject.transform.rotation = Quaternion.Euler(0.1f, 0, 0);
                Vector3 targetPosition = player.transform.position;
                targetPosition.y = transform.position.y;
                transform.LookAt(targetPosition);
                playerIsClose = true;
                GetComponent<NavMeshAgent>().speed = 0;
            }
            if (dist >= 22)
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
                shield.SetActive(false);
                ResetAnim();
            }
            if (playerIsClose == true)
            {
                if (Physics.Raycast(transform.position, transform.forward, out hit, 20))
                {
                }
                else
                {
                    if (dist >= 2)
                    {
                    gameObject.transform.LookAt(player.transform);
                    }
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
            if (!death)
            {
                balPosition.GetComponent<MeshRenderer>().enabled = true;
            }
            Bigger();
        }
        isAtacking = true;
    }
    public void DoDamage()
    {
        Invoke("Resset", attackCoolDown+=1);
        Invoke("DoTaunt", attackCoolDown / 2);
        doingDamage = true;
    }
    public void DoTaunt()
    {
        Taunt();
        balPosition.GetComponent<MeshRenderer>().enabled = false;
        Invoke("GrabShield", 0.6f);
        balPosition.transform.localScale=new Vector3 (0.1f,0.1f,0.1f);
    }
    public void Resset()
    {
        shield.SetActive(false);
        ResetAnim();
        isAtacking = false;
        doingDamage = false;
    }
    public void Taunt()
    {
        ResetAnim();
        if (playerIsClose == true)
        {
            anim.SetBool("IsTaunting", true);
        }
    }
        public void Atack()
    {
        ResetAnim();
        anim.SetBool("IsAttacking", true);
         Invoke("FireBall", 2);
        shield.SetActive(false);
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
        anim.SetBool("IsAttacking", false);
        anim.SetBool("IsTaunting", false);
    }
    public void FireBall()
    {
        if (playerIsClose == true)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 toOther = player.transform.position - transform.position;
            if (Vector3.Dot(forward, toOther) > 0)
            {
                if (!death)
                {
                    Instantiate(magicBall, balPosition.transform.position, Quaternion.identity);
                }
            }
        }
        balPosition.GetComponent<MeshRenderer>().enabled = false;
    }
    public void Bigger()
    {
        if (balPosition.transform.localScale.x > 0.2f)
        {
            balPosition.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }
        if (balPosition.transform.localScale.x <0.2f)
        {
            balPosition.transform.localScale += new Vector3(0.25f, 0.25f, 0.25f) * Time.deltaTime;
        Invoke("Bigger",0.1f);
        }
    }
    public void GrabShield()
    {
        if (playerIsClose)
        {
            if (!death)
            {
                shield.SetActive(true);
            }
        }
    }
    public void WhatItemWeGonGet()
    {
        int number = Random.Range(1, 16);
        if (number <= 4)
        {
        }
        if (number <= 8 & number > 4)
        {
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
            if (PlayerPrefs.GetInt("goldenpistol", 0) == 1)
            {
                Instantiate(itemHolder.GetComponent<ItemHolder>().guns[3], gameObject.transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(itemHolder.GetComponent<ItemHolder>().guns[2], gameObject.transform.position, Quaternion.identity);
            }
        }
        if (number <= 8 & number > 4)
        {
            if (PlayerPrefs.GetInt("goldenlauncher", 0) == 1)
            {
                Instantiate(itemHolder.GetComponent<ItemHolder>().guns[4], gameObject.transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(itemHolder.GetComponent<ItemHolder>().guns[0], gameObject.transform.position, Quaternion.identity);
            }
        }
        if (number <= 12 & number > 8)
        {
            if (PlayerPrefs.GetInt("goldenrifle", 0) == 1)
            {
                Instantiate(itemHolder.GetComponent<ItemHolder>().guns[5], gameObject.transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(itemHolder.GetComponent<ItemHolder>().guns[1], gameObject.transform.position, Quaternion.identity);
            }
        }
    }
    public void ItemDrop()
    {
        int number = Random.Range(1, 47);
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
        //unlockable items
        if (number <= 40 & number > 38)
        {
            if (PlayerPrefs.GetInt("enemy" + 0, 0) >= 100)
            {
                Instantiate(itemHolder.GetComponent<ItemHolder>().rareItems[7], gameObject.transform.position, Quaternion.identity);
            }
            else
            {
                ItemDrop();
            }

        }
        if (number <= 42 & number > 40)
        {
            if (PlayerPrefs.GetInt("timesdied", 0) >= 5)
            {
                Instantiate(itemHolder.GetComponent<ItemHolder>().rareItems[8], gameObject.transform.position, Quaternion.identity);
            }
            else
            {
                ItemDrop();
            }
        }
        if (number <= 44 & number > 42)
        {
            if (PlayerPrefs.GetInt("enemy" + 6, 0) >= 1)
            {
                Instantiate(itemHolder.GetComponent<ItemHolder>().rareItems[9], gameObject.transform.position, Quaternion.identity);
            }
            else
            {
                ItemDrop();
            }
        }
        if (number <= 46 & number > 44)
        {
            if (PlayerPrefs.GetInt("enemy" + 5, 0) >= 5)
            {
                Instantiate(itemHolder.GetComponent<ItemHolder>().rareItems[10], gameObject.transform.position, Quaternion.identity);
            }
            else
            {
                ItemDrop();
            }
        }
    }
}   