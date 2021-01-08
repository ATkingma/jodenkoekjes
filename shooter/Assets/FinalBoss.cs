using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class FinalBoss : MonoBehaviour
{
    //publics
    public Animator anim;
    public bool PlayerInTrigger, bossisdeath;
    public float damage1, damage2, damage3;
    public GameObject fist,bal1,bal2,FireFist,inpactShowObject;
    public AudioSource dying, walking, taunt1Sound, taunt2Sound,shootSound,quickfistattack,aoeattack;
    //privates
    private bool playerIsDeath, playerIsClose, isAtacking, Dontlook, gettingPlayerPos, attack1IsActive, attack2IsActive, attack4IsActive, noParticle, didto0, aoe;
    private GameObject player, itemHolder;
    private GameObject[] itemSpawnPoints;
    private float speed;
    private Vector3 playerPos;
    private int soMutch, index;
    RaycastHit hit;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        speed = GetComponent<NavMeshAgent>().speed;
        soMutch = 12;
        itemHolder = GameObject.FindGameObjectWithTag("GameManager");
        itemSpawnPoints = GameObject.FindGameObjectsWithTag("ItemDropPoint");

        //boss damage based on min
        float temp = PlayerPrefs.GetFloat("minuut", 0);
        damage1 *= (1 + 0.1f) * (1 + temp);
        damage2 *= (1 + 0.1f) * (1 + temp);
        damage3 *= (1 + 0.1f) * (1 + temp);
        bal1.SetActive(false);
        bal2.SetActive(false);
    }
    void Update()
    {
        if (playerIsDeath == false)
        {
            if (bossisdeath == false)
            {
                walking.Play();
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
                    gameObject.transform.LookAt(player.transform);
                    //doet gay hier moet niet rotaten
                }
            }
        }
    }
    public void Taunt1()
    {
        ResetAnim();
        anim.SetBool("Taunt1", true);
    }
    public void Taunt2()
    {
        ResetAnim();
        anim.SetBool("Taunt2", true);
    }
    public void Attack1()
    {
        ResetAnim();
        anim.SetBool("Attack1", true);
        Invoke("Reset", 3.4f);
        shootSound.Play();
    }
    public void Attack2()
    {
        ResetAnim();
        anim.SetBool("Attack2", true);
        Invoke("Reset", 3.3f);
        aoeattack.Play();
    }
    public void Attack3()
    {
        ResetAnim();
        anim.SetBool("Attack3", true);
        Invoke("Reset", 3.4f);
        quickfistattack.Play();
    }
    public void Attack1SpawnFireBalls()
    {
        bal1.SetActive(true);
        bal2.SetActive(true);
    }
    public void Attack1ShootBalls()
    {
        bal1.SetActive(false);
        bal2.SetActive(false);
        GameObject projectile0 = Instantiate(FireFist, bal1.transform.position, Quaternion.identity);
        projectile0.GetComponent<IceBeamScript>().damage = damage1;
        GameObject projectile1 = Instantiate(FireFist, bal2.transform.position, Quaternion.identity);
        projectile1.GetComponent<IceBeamScript>().damage = damage1;
    }
    public void ShowInpactAttack2Aoe()
    {
        playerPos = player.transform.position;
        Instantiate(inpactShowObject, playerPos - new Vector3(0, 1, 0), Quaternion.identity);
        Instantiate(inpactShowObject, playerPos + new Vector3(6, 0, 6) - new Vector3(0, 1, 0), Quaternion.identity);
        Instantiate(inpactShowObject, playerPos + new Vector3(9, 0, 0) - new Vector3(0, 1, 7), Quaternion.identity);
        Instantiate(inpactShowObject, playerPos + new Vector3(0, 0, 0) - new Vector3(6, 1, 6), Quaternion.identity);
        Instantiate(inpactShowObject, playerPos + new Vector3(0, 0, 10) - new Vector3(10, 1, 0), Quaternion.identity);
    }
    public void DoAttackVisual2Aoe()
    {
        GameObject fist0 = Instantiate(fist, playerPos - (new Vector3(0, 1, 0) + new Vector3(0, 1.9f, 0)), Quaternion.identity);
        fist0.GetComponentInChildren<DestroyScriptFist>().damage = damage2;
        GameObject fist1 = Instantiate(fist, playerPos + new Vector3(6, 0, 6) - new Vector3(0, 1.9f, 0), Quaternion.identity);
        fist1.GetComponentInChildren<DestroyScriptFist>().damage = damage2;
        GameObject fist2 = Instantiate(fist, playerPos + new Vector3(9, 0, 0) - new Vector3(0, 1.9f, 7), Quaternion.identity);
        fist2.GetComponentInChildren<DestroyScriptFist>().damage = damage2;
        GameObject fist3 = Instantiate(fist, playerPos + new Vector3(0, 0, 0) - new Vector3(6, 1.9f, 6), Quaternion.identity);
        fist3.GetComponentInChildren<DestroyScriptFist>().damage = damage2;
        GameObject fist4 = Instantiate(fist, playerPos + new Vector3(0, 0, 10) - new Vector3(10, 1.9f, 0), Quaternion.identity);
        fist4.GetComponentInChildren<DestroyScriptFist>().damage = damage2;
    }
    public void ShowInpactAttack3()
    {
        playerPos = player.transform.position;
        Instantiate(inpactShowObject, player.transform.position - new Vector3(0, 1, 0), Quaternion.identity);
    }
    public void DoAttackVisual3()
    {
        GameObject fist0 = Instantiate(fist, playerPos - new Vector3(0, 2.9f, 0), Quaternion.identity) ;
        fist0.GetComponentInChildren<DestroyScriptFist>().damage = damage3;
    }
    public void RandomAttack()
    {
        float RandomAttack = Random.Range(1,9);
       // float RandomAttack = 6;
        if (RandomAttack == 1 | RandomAttack == 2 | RandomAttack == 3)
        {
            Attack1();
        }
        if (RandomAttack == 4 | RandomAttack == 5 | RandomAttack == 6)
        {
            Attack2();
        }
        if (RandomAttack == 7 | RandomAttack == 8 | RandomAttack == 9)
        {
            Attack3();
        }
        isAtacking = true;
    }
    public void RandomTaunt()
    {
        float RanomAttack = Random.Range(1, 2);
        if (RanomAttack == 1)
        {
            Taunt1();
            taunt1Sound.Play();
        }
        if (RanomAttack == 2)
        {
            Taunt2();
            taunt2Sound.Play();
        }
    }

    public void Walking()
    {
        ResetAnim();
        anim.SetBool("IsWalking", true);
    }
    public void ResetAnim()
    {
        anim.SetBool("IsWalking", false);
        anim.SetBool("Taunt1", false);
        anim.SetBool("Taunt2", false);
        anim.SetBool("Attack1", false);
        anim.SetBool("Attack2", false);
        anim.SetBool("Attack3", false);
    }
    public void Reset()
    {
        ResetAnim();
        isAtacking = false;
    }
    public void DeathFunction()
    {
        FindObjectOfType<Saves>().AddKill(6); //boss final
        FindObjectOfType<Saves>().BossesKilled();
        bossisdeath = true;
        dying.Play();
        Invoke("Disapear", 4);
        anim.SetBool("IsDeath", true);
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

///rotation fixen
//////goeie objects
///////damage op alles