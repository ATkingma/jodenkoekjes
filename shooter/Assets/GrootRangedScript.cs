using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GrootRangedScript : MonoBehaviour
{
    //publics
    public int tester;
    public float attackCoolDown, health;
    public Animator anim;
    public GameObject defenceSphere, attackline_1, attackline_2, idleLine_1, idleLine_2;
    //privates
    private bool playerIsClose, PlayerInTrigger, doingDamage, isAtacking, death, doingDead, settingLine,doingIdle;
    private GameObject player;
    private float speed;
    RaycastHit hit;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        speed = GetComponent<NavMeshAgent>().speed;
        defenceSphere.SetActive(false);
    }
    void Update()
    {
        if (health <= 0)
        {
            death = true;
            if (!doingDead)
            {
                Death();

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
                idleLine_1.GetComponent<LineRenderer>().SetPosition(1, idleLine_1.transform.position);
                idleLine_1.GetComponent<LineRenderer>().SetPosition(0, idleLine_2.transform.position);
            }
            float dist = Vector3.Distance(player.transform.position, transform.position);
            if (dist <= 20)
            {
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
                ResetAnim();
            }
            if (playerIsClose == true)
            {
                if (Physics.Raycast(transform.position, transform.forward, out hit, 20))
                {
                }
                else
                {
                    gameObject.transform.LookAt(player.transform);
                    print("koekoek");
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
        print("Attacking");
        isAtacking = true;
    }
    public void DoDamage()
    {
        Invoke("DoTaunt", attackCoolDown / 2);
        print("DoDammage");
        doingDamage = true;
    }
    public void DoTaunt()
    {
        Taunt();
        print("dotaunt");
    }
    public void Resset()
    {
        ResetAnim();
        isAtacking = false;
        print("Resset");
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
        print("taunt");
    }
    public void RandomTaunt()
    {
        //float RandomIdle = Random.Range(1, 3);
        float RandomIdle = tester;
        if (RandomIdle == 1)
        {
            anim.SetBool("IsTaunting", true);
            doingIdle = true;
        }
        if (RandomIdle == 2)
        {
            anim.SetBool("IsTaunting", true);
            doingIdle = true;
        }
        if (RandomIdle == 3)
        {
            Invoke("DefenceShieldOn",2);
            anim.SetBool("isDefending", true);
        }
    }
    public void Atack()
    {
        settingLine = true;
        attackline_1.GetComponent<LineRenderer>().SetPosition(1, player.transform.position);
        attackline_2.GetComponent<LineRenderer>().SetPosition(1, player.transform.position);
        attackline_1.SetActive(true);
        attackline_2.SetActive(true);
        ResetAnim();
        anim.SetBool("IsAttacking", true);
        print("atack");

    }
    public void Death()
    {
        anim.SetBool("Death", true);
        Invoke("IsDeath", 3);
    }
    public void IsDeath()
    {
        Destroy(gameObject);
        //andere shit
    }
    public void ResetAnim()
    {
        anim.SetBool("IsAttacking", false);
        anim.SetBool("IsTaunting", false);
        print("reset anim");
    }
    public void OnTriggerEnter(Collider gameobject)
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
    public void DefenceShieldOn()
    {
        defenceSphere.SetActive(true);
    }
}
///reset maken 
///beter tijden voor animaties enz
///beter leaves textures