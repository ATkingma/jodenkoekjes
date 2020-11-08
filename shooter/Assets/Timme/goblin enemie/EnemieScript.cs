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
    private bool doingDamage, isAtacking, PlayerInTrigger;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
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
        if (dist >= 6.4f)
        {
            ResetAnim();
            UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            agent.destination = player.transform.position;
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
        print("Attacking");
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
        print("Resset");
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
}
///moet niet maar bug dat die defende er uit hallen
///

    ///moet wel de walking animatie apart aan laten gaan en dan een empty ofz er tussen zetten omdat die nu loopt onder de animaties door