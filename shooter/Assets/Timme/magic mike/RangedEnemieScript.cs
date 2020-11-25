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
    //privates
    private bool playerIsClose, PlayerInTrigger, doingDamage, isAtacking,death, doingDead;
    private GameObject player;
    private float speed;
    RaycastHit hit;
    void Start()
    {       
        player = GameObject.FindGameObjectWithTag("Player");
        speed = GetComponent<NavMeshAgent>().speed;
        balPosition.GetComponent<MeshRenderer>().enabled = false;
        shield.SetActive(false);
    }
    void Update()
    {
        if (GetComponent<EnemyHealth>().maxHealth <= 0)
        {
            death = true;
            if (!doingDead)
            {
                Death();

            }
        }
        if (!death)
        {
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
            balPosition.GetComponent<MeshRenderer>().enabled = true;
            Bigger();
        }
        print("Attacking");
        isAtacking = true;
    }
    public void DoDamage()
    {
        Invoke("Resset", attackCoolDown+=1);
        Invoke("DoTaunt", attackCoolDown / 2);
        print("DoDammage");
        doingDamage = true;
    }
    public void DoTaunt()
    {
        Taunt();
        print("dotaunt");
        balPosition.GetComponent<MeshRenderer>().enabled = false;
        Invoke("GrabShield", 0.6f);
        balPosition.transform.localScale=new Vector3 (0.1f,0.1f,0.1f);
    }
    public void Resset()
    {
        shield.SetActive(false);
        ResetAnim();
        isAtacking = false;
        print("Resset");
        doingDamage = false;
    }
    public void Taunt()
    {
        ResetAnim();
        if (playerIsClose == true)
        {
            anim.SetBool("IsTaunting", true);
        }
        print("taunt");
    }
    public void Atack()
    {
        ResetAnim();
        anim.SetBool("IsAttacking", true);
         Invoke("FireBall", 2);
        print("atack");
        shield.SetActive(false);
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
    public void FireBall()
    {
        if (playerIsClose == true)
        {

        Instantiate(magicBall, balPosition.transform.position, Quaternion.identity);
        }
        print("vuurbal");
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
        shield.SetActive(true);
        }
    }
}   