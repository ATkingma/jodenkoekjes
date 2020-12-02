using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Boss : MonoBehaviour
{
    //publics
    public Animator anim;
    public GameObject icePegel1, icePegel2,portal;
    public bool PlayerInTrigger;
    //privates
    private bool playerIsDeath,bossisdeath, playerIsClose, isAtacking, Dontlook, gettingPlayerPos, attack1IsActive, attack2IsActive, attack4IsActive,noParticle, didto0;
    private GameObject player;
    private GameObject attack1_1Pos, attack1_2Pos, attack1_3Pos, attack1_4Pos, attack2Pos, attack3Pos, attack4_1Pos, attack4_2Pos, attack4_3Pos;
    private Vector3[] attack1RenderLine;
    private float speed;
    private ParticleSystem particle;
    private Vector3 playerPos;
    RaycastHit hit;
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        player = GameObject.FindGameObjectWithTag("Player");
        speed = GetComponent<NavMeshAgent>().speed;
        attack1_1Pos = GameObject.FindGameObjectWithTag("Attack1_1Pos");
        attack1_2Pos = GameObject.FindGameObjectWithTag("Attack1_2Pos");
        attack1_3Pos = GameObject.FindGameObjectWithTag("Attack1_3Pos");
        attack1_4Pos = GameObject.FindGameObjectWithTag("Attack1_4Pos");
        attack2Pos = GameObject.FindGameObjectWithTag("Attack2Pos");
        attack3Pos = GameObject.FindGameObjectWithTag("Attack3Pos");
        attack4_1Pos = GameObject.FindGameObjectWithTag("Attack4_1Pos");
        attack4_2Pos = GameObject.FindGameObjectWithTag("Attack4_2Pos");
        attack4_3Pos = GameObject.FindGameObjectWithTag("Attack4_3Pos");
    }
    void Update()
    {
        if (playerIsDeath == false)
        {
            if (bossisdeath == false)
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
                    DeathFunction();
                }
                if (attack1IsActive == true)
                {
                    attack1_1Pos.GetComponent<LineRenderer>().SetPosition(0, attack1_1Pos.transform.position);
                    attack1_2Pos.GetComponent<LineRenderer>().SetPosition(0, attack1_2Pos.transform.position);
                    attack1_3Pos.GetComponent<LineRenderer>().SetPosition(0, attack1_3Pos.transform.position);
                    attack1_4Pos.GetComponent<LineRenderer>().SetPosition(0, attack1_4Pos.transform.position);
                }
                if (attack4IsActive == true)
                {
                    attack4_1Pos.GetComponent<LineRenderer>().SetPosition(0, attack4_1Pos.transform.position);
                    attack4_2Pos.GetComponent<LineRenderer>().SetPosition(0, attack4_2Pos.transform.position);
                    attack4_3Pos.GetComponent<LineRenderer>().SetPosition(0, attack4_3Pos.transform.position);
                }
                if (attack2IsActive == true)
                {
                    Invoke("ResetAttack2", 0.5f);
                    attack2Pos.GetComponent<LineRenderer>().SetPosition(0, attack2Pos.transform.position);
                }
                if (Dontlook == true)
                {
                    if (gettingPlayerPos == false)
                    {
                        playerPos = player.transform.position;
                        gettingPlayerPos = true;
                    }
                }
                float dist = Vector3.Distance(player.transform.position, transform.position);
                if (dist <= 40)
                {
                    playerIsClose = true;
                    GetComponent<NavMeshAgent>().speed = 0;
                }
                if (dist >= 44)
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
                            RandomAttack();
                        }
                    }
                }
                if (playerIsClose == false)
                {
                    UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
                    agent.destination = player.transform.position;
                    Walking();
                }
                if (dist <= 40)
                {                 
                    if (PlayerInTrigger == false)
                    {

                        if (Physics.Raycast(transform.position + new Vector3(0, 4, 0), transform.forward, out hit, 40))
                        {
                            if (Dontlook == true)
                            {
                                gameObject.transform.LookAt(playerPos);
                            }
                            if (Dontlook == false)
                            {
                                gameObject.transform.LookAt(player.transform);
                            }
                        }
                        else
                        {
                            if (Dontlook == true)
                            {
                                gameObject.transform.LookAt(playerPos);
                            }
                            if (Dontlook == false)
                            {
                                gameObject.transform.LookAt(player.transform);
                            }
                        }
                    }
                }
            }
        }
    }
    public void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Player")
        {
        }
    }
        public void RandomAttack()
         {
        float RanomAttack = Random.Range(1,10);
        if (RanomAttack == 1)
        {
            Dontlook = true;
            Attacking1();
        }
        if (RanomAttack == 2)
        {
            Attacking2();
        }
        if (RanomAttack == 3)
        {
            Attacking3();
        }
        if (RanomAttack == 4)
        {
            Dontlook = true;
            Attacking4();
        }
        if (RanomAttack == 5)
        {
            Dontlook = true;
            AOE();
        }
        if (RanomAttack == 6)
        {
            Idle();
        }
        if (RanomAttack == 7)
        {
            Idle();
        }
        if (RanomAttack == 8)
        {
            Idle();
        }
        if (RanomAttack == 9)
        {
            Idle();
        }
        if (RanomAttack == 10)
        {
            Idle();
        }
        isAtacking = true;
         }
    public void Attacking1()
    {
        ResetAnim();
        anim.SetBool("Attack1", true);
        Invoke("Reset", 4);
        Invoke("GetThat", 1.2f);

    }
    public void Attacking2()
    {
        ResetAnim();
        anim.SetBool("Attack2", true);
        Invoke("Reset", 3);
        Invoke("SpawnAttack2", 0.9f);
    }
    public void Attacking3()
    {        
        ResetAnim();
        anim.SetBool("Attack3", true);
        Invoke("QuickLighting", 0.9f);
        Invoke("Reset", 3);
    }
    public void Attacking4()
    {        
        ResetAnim();
        anim.SetBool("Attack4", true);
        Invoke("Reset", 4);
        Invoke("Attack4Line", 1);
    }
    public void AOE()
    {
        noParticle = false;
        Invoke("ParticleSetActive", 3f);
        ResetAnim();
        anim.SetBool("Aoe", true);
        Invoke("Reset", 4.6f);
    }
    public void ParticleSetActive()
    {
        if (noParticle == false)
        {
        particle.Play(true);           
        }
    }
    public void Idle()
    {
        ResetAnim();
        anim.SetBool("Idle", true);
        Invoke("Reset", 4);
    }
    public void Walking()
    {
        ResetAnim();
        anim.SetBool("Walking", true);
    }
    public void ResetAnim()
    {
        anim.SetBool("Walking", false);
        anim.SetBool("Attack1", false);
        anim.SetBool("Attack2", false);
        anim.SetBool("Attack3", false);
        anim.SetBool("Attack4", false);
        anim.SetBool("Aoe", false);
        anim.SetBool("Idle", false);
    }
    public void Reset()
    {
        ResetAnim();
        noParticle = true;
        isAtacking = false;
        Dontlook = false;
        gettingPlayerPos = false;
        attack1_1Pos.SetActive(false);
        attack1_2Pos.SetActive(false);
        attack1_3Pos.SetActive(false);
        attack1_4Pos.SetActive(false);
        attack1IsActive = false;
        attack2IsActive = false;
        attack4IsActive = false;
        attack2Pos.SetActive(false);
        particle.Play(false);
        particle.Clear(true);
        particle.Stop(true);
        attack4_1Pos.SetActive(false);
        attack4_2Pos.SetActive(false);
        attack4_3Pos.SetActive(false);
    }
    public void SpawnAttack2()
    {
        Instantiate(icePegel1, attack2Pos.transform.position, Quaternion.identity);
        Instantiate(icePegel1, attack2Pos.transform.position, Quaternion.identity);
        Instantiate(icePegel2, attack2Pos.transform.position, Quaternion.identity);
    }
    public void GetThat()
    {
        attack1IsActive = true;
        attack1_1Pos.SetActive(true);
        attack1_2Pos.SetActive(true);
        attack1_3Pos.SetActive(true);
        attack1_4Pos.SetActive(true);
        attack1_1Pos.GetComponent<LineRenderer>().SetPosition(1, player.transform.position);
        attack1_2Pos.GetComponent<LineRenderer>().SetPosition(1, player.transform.position);
        attack1_3Pos.GetComponent<LineRenderer>().SetPosition(1, player.transform.position);
        attack1_4Pos.GetComponent<LineRenderer>().SetPosition(1, player.transform.position);
    }
    public void QuickLighting()
    {
        attack2IsActive = true;
        attack2Pos.SetActive(true);
        attack2Pos.GetComponent<LineRenderer>().SetPosition(0, attack2Pos.transform.position);
        attack2Pos.GetComponent<LineRenderer>().SetPosition(1, player.transform.position);
    }
    public void ResetAttack2()
    {
        attack2IsActive = false;
        attack2Pos.SetActive(false);
    }
    public void Attack4Line()
    {
            attack4IsActive = true;
            attack4_1Pos.SetActive(true);
            attack4_2Pos.SetActive(true);
            attack4_3Pos.SetActive(true);
            attack4_1Pos.GetComponent<LineRenderer>().SetPosition(1, player.transform.position);
            attack4_2Pos.GetComponent<LineRenderer>().SetPosition(1, player.transform.position);
            attack4_3Pos.GetComponent<LineRenderer>().SetPosition(1, player.transform.position);
              Invoke("DoAttack4LineOff", 0.6f);
    }
    public void DoAttack4LineOff()
    {
        attack4_1Pos.SetActive(false);
        attack4_2Pos.SetActive(false);
        attack4_3Pos.SetActive(false);
    }
    public void DeathFunction()
    {
        bossisdeath = true;
        Invoke("Disapear",4);
        anim.SetBool("BosDeath", true);
        portal.GetComponent<GoUp>().canGoUp = true;
    }
    public void Disapear()
    {
        Destroy(gameObject);
    }
    public void Taunt()
    {
        playerIsDeath = true;
        anim.SetBool("PlayerIsDead", true);
    }
}