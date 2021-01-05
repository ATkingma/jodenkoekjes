using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Boss : MonoBehaviour
{
    //publics
    public Animator anim;
    public GameObject icePegel1, icePegel2, portal,raycast;
    public bool PlayerInTrigger, bossisdeath;
    public float damage1, damage2, damage3;
    //privates
    private bool playerIsDeath, playerIsClose, isAtacking, Dontlook, gettingPlayerPos, attack1IsActive, attack2IsActive, attack4IsActive, noParticle, didto0,aoe,AttackDoingDamage;
    private GameObject player, itemHolder,playerPosition;
    private GameObject attack1_1Pos, attack1_2Pos, attack1_3Pos, attack1_4Pos, attack2Pos, attack3Pos, attack4_1Pos, attack4_2Pos, attack4_3Pos;
    private GameObject[] itemSpawnPoints;
    private float speed;
    private ParticleSystem particle;
    private Vector3 playerPos;
    private int soMutch,index;
    RaycastHit hit;

    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerPosition = GameObject.FindGameObjectWithTag("LookAPlayer");
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
        soMutch = 5;
        itemHolder = GameObject.FindGameObjectWithTag("GameManager");
        itemSpawnPoints= GameObject.FindGameObjectsWithTag("ItemDropPoint");

        //boss damage based on min
        float temp = PlayerPrefs.GetFloat("minuut", 0);
        damage1 *= 0.1f * temp;
        damage2 *= 0.1f * temp;
        damage3 *= 0.1f * temp;
    }
    void Update()
    {
        if (playerIsDeath == false)
        {
            raycast.transform.LookAt(player.transform.position);
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
                    RaycastHit hit;
                    Debug.DrawRay(raycast.transform.position, raycast.transform.forward, Color.green, 10000000000000000000000000000000000000f);
                    if (Physics.Raycast(raycast.transform.position, raycast.transform.forward,  out hit, 10000000000000000000000000000000000000f))
                    {
                        if (hit.transform.tag == "Player")
                        {
                            if (!AttackDoingDamage)
                            {
                                player.GetComponent<PlayerHealth>().ReceiveDamage(damage2, 0);
                                AttackDoingDamage = true;
                                print("doetie");
                            }
                        }
                    }
                }
                if (attack4IsActive == true)
                {
                    attack4_1Pos.GetComponent<LineRenderer>().SetPosition(0, attack4_1Pos.transform.position);
                    attack4_2Pos.GetComponent<LineRenderer>().SetPosition(0, attack4_2Pos.transform.position);
                    attack4_3Pos.GetComponent<LineRenderer>().SetPosition(0, attack4_3Pos.transform.position);
                    RaycastHit hit;
                    Debug.DrawRay(raycast.transform.position, raycast.transform.forward, Color.green, 10000000000000000000000000000000000000f);
                    if (Physics.Raycast(raycast.transform.position, raycast.transform.forward, out hit, 10000000000000000000000000000000000000f))
                    {
                        if (hit.transform.tag == "Player")
                        {
                            if (!AttackDoingDamage)
                            {
                                player.GetComponent<PlayerHealth>().ReceiveDamage(damage2, 0);
                                AttackDoingDamage = true;
                                print("hier ook");
                            }                            
                        }
                    }
                }
                if (attack2IsActive == true)
                {
                    Invoke("ResetAttack2", 0.5f);
                    attack2Pos.GetComponent<LineRenderer>().SetPosition(0, attack2Pos.transform.position);
                    RaycastHit hit;
                    Debug.DrawRay(raycast.transform.position, raycast.transform.forward, Color.green, 10000000000000000000000000000000000000f);
                    if (Physics.Raycast(raycast.transform.position, raycast.transform.forward, out hit, 10000000000000000000000000000000000000f))
                    {
                        if (hit.transform.tag == "Player")
                        {
                            if (!AttackDoingDamage)
                            {
                                player.GetComponent<PlayerHealth>().ReceiveDamage(damage2, 0);
                                AttackDoingDamage = true;
                                print("ookl hier");
                            }
                        }
                    }
                }
                if (Dontlook == true)
                {
                    if (gettingPlayerPos == false)
                    {
                        playerPos = playerPosition.transform.position;
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
                                if (!aoe)
                                {
                                gameObject.transform.LookAt(playerPos);
                                }
                            }
                            if (Dontlook == false)
                            {
                                if (!aoe)
                                {
                                gameObject.transform.LookAt(player.transform);
                                }
                            }
                        }
                        else
                        {
                            if (Dontlook == true)
                            {
                                if (!aoe)
                                {
                                gameObject.transform.LookAt(playerPos);
                                }
                            }
                            if (Dontlook == false)
                            {
                                if (!aoe)
                                {
                                gameObject.transform.LookAt(player.transform);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    public void RandomAttack()
    {
        float RanomAttack = Random.Range(1, 7);
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
        aoe = true;
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
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
            if (!bossisdeath)
            {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            particle.Play(true);
            }
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
        particle.Play(false);
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
        aoe = false;
        AttackDoingDamage = false;
    }
    public void SpawnAttack2()
    {
        Instantiate(icePegel1, attack2Pos.transform.position, Quaternion.identity);
        Instantiate(icePegel1, attack2Pos.transform.position, Quaternion.identity);
        Instantiate(icePegel2, attack2Pos.transform.position, Quaternion.identity);
    }
    public void GetThat()//deze
    {
        attack1IsActive = true;
        attack1_1Pos.SetActive(true);
        attack1_2Pos.SetActive(true);
        attack1_3Pos.SetActive(true);
        attack1_4Pos.SetActive(true);
        attack1_1Pos.GetComponent<LineRenderer>().SetPosition(1, playerPosition.transform.position);
        attack1_2Pos.GetComponent<LineRenderer>().SetPosition(1, playerPosition.transform.position);
        attack1_3Pos.GetComponent<LineRenderer>().SetPosition(1, playerPosition.transform.position);
        attack1_4Pos.GetComponent<LineRenderer>().SetPosition(1, playerPosition.transform.position);
        RaycastHit hit;
        if (Physics.Linecast(transform.position + new Vector3(0, 0.5f, 0), transform.forward, out hit))
        {
            //if (hit.transform.tag == "Player")
            //{
            //    player.GetComponent<PlayerHealth>().ReceiveDamage(damage3, 0);
            //    print("hget");
            //}
        }
    }
    public void QuickLighting()//deze
    {
        attack2IsActive = true;
        attack2Pos.SetActive(true);
        attack2Pos.GetComponent<LineRenderer>().SetPosition(0, attack2Pos.transform.position);
        attack2Pos.GetComponent<LineRenderer>().SetPosition(1, playerPosition.transform.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), transform.forward, out hit))
        {
            //if (hit.transform.tag == "Player")
            //{
            //    player.GetComponent<PlayerHealth>().ReceiveDamage(damage1, 0);
            //    print("quick");            
            //}
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {        
        }

        }
    public void ResetAttack2()
    {
        attack2IsActive = false;
        attack2Pos.SetActive(false);
    }
    public void Attack4Line()//deze
    {
        attack4IsActive = true;
        attack4_1Pos.SetActive(true);
        attack4_2Pos.SetActive(true);
        attack4_3Pos.SetActive(true);
        attack4_1Pos.GetComponent<LineRenderer>().SetPosition(1, playerPosition.transform.position);
        attack4_2Pos.GetComponent<LineRenderer>().SetPosition(1, playerPosition.transform.position);
        attack4_3Pos.GetComponent<LineRenderer>().SetPosition(1, playerPosition.transform.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), transform.forward, out hit))
        {
            //if (hit.transform.tag == "Player")
            //{
            //    player.GetComponent<PlayerHealth>().ReceiveDamage(damage2, 0);
            //    print("hit4");
            //}
        }
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
        FindObjectOfType<Saves>().AddKill(5); //boss
        FindObjectOfType<Saves>().BossesKilled();
        Reset();
        bossisdeath = true;
        Invoke("Disapear", 4);
        anim.SetBool("BosDeath", true);
        portal.GetComponent<GoUp>().canGoUp = true;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        DoDrop();
    }
    public void DoDrop()
    {
        if (soMutch >= 0)
        {
            ItemDrop();
            Min();
            Plus();
            DoDrop();
        }
    }
public void Min()
    {
        soMutch -= 1;
    }
    public void Plus()
    {
        index++;
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
    public void ItemDrop()
    {
        int number = Random.Range(24, 47);
        if (number <= 8)
        {
            Instantiate(itemHolder.GetComponent<ItemHolder>().comonItems[0], itemSpawnPoints[index].transform.position, Quaternion.identity);
        }
        if (number <= 16 & number > 8)
        {
            Instantiate(itemHolder.GetComponent<ItemHolder>().comonItems[1], itemSpawnPoints[index].transform.position, Quaternion.identity);
        }
        if (number <= 24 & number > 16)
        {
            Instantiate(itemHolder.GetComponent<ItemHolder>().comonItems[2], itemSpawnPoints[index].transform.position, Quaternion.identity);
        }
        if (number <= 26 & number > 24)
        {
            Instantiate(itemHolder.GetComponent<ItemHolder>().rareItems[0], itemSpawnPoints[index].transform.position, Quaternion.identity);
        }
        if (number <= 28 & number > 26)
        {
            Instantiate(itemHolder.GetComponent<ItemHolder>().rareItems[1], itemSpawnPoints[index].transform.position, Quaternion.identity);
        }
        if (number <= 30 & number > 28)
        {
            Instantiate(itemHolder.GetComponent<ItemHolder>().rareItems[2], itemSpawnPoints[index].transform.position, Quaternion.identity);
        }
        if (number <= 32 & number > 30)
        {
            Instantiate(itemHolder.GetComponent<ItemHolder>().rareItems[3], itemSpawnPoints[index].transform.position, Quaternion.identity);
        }
        if (number <= 34 & number > 32)
        {
            Instantiate(itemHolder.GetComponent<ItemHolder>().rareItems[4], itemSpawnPoints[index].transform.position, Quaternion.identity);
        }
        if (number <= 36 & number > 34)
        {
            Instantiate(itemHolder.GetComponent<ItemHolder>().rareItems[5], itemSpawnPoints[index].transform.position, Quaternion.identity);
        }
        if (number <= 38 & number > 36)
        {
            Instantiate(itemHolder.GetComponent<ItemHolder>().rareItems[6], itemSpawnPoints[index].transform.position, Quaternion.identity);
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