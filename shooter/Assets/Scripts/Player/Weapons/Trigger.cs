﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Transform weaponHold, meleeHold, weaponDump;
    public LayerMask canShoot, guns;
    public bool menuIsActive;
    public List<GameObject> gunlist, meleeList;
    public int gunNumber, meleeNumber;
    public AudioSource weaponPickup;
    public GameObject pressF;

    //privates
    private float nextAttack, attackCooldown, attacksPerSec, calculatedDamage, slowBulletAttackSpeed, meleeDamage, attacksPerSecMelee, attackCooldownMelee;
    private Transform currentWeapon, currentMelee;
    private WeaponReference weapon;
    private MeleeReference melee;
    private RaycastHit hit, hitInfo;
    private Vector3 aimAt;
    private ItemList itemList;
    private bool holdingGun = true;

    private void Start()
    {
        if (PlayerPrefs.GetInt("goldenpistol", 0) == 1)
        {
            if(gunNumber == 0)
            {
                gunNumber = 3;
            }
        }
        if (PlayerPrefs.GetInt("goldenlauncher", 0) == 1)
        {
            if (gunNumber == 1)
            {
                gunNumber = 4;
            }
        }
        if (PlayerPrefs.GetInt("goldenrifle", 0) == 1)
        {
            if (gunNumber == 2)
            {
                gunNumber = 5;
            }
        }
        currentWeapon = Instantiate(gunlist[gunNumber].transform, weaponHold.position, weaponHold.rotation, transform);
        weapon = currentWeapon.GetComponent<WeaponReference>();
        weapon.isUsed = true;
        currentMelee = Instantiate(meleeList[meleeNumber].transform, meleeHold.position, weaponHold.rotation, transform);
        melee = currentMelee.GetComponent<MeleeReference>();
        currentMelee.gameObject.SetActive(false);
        itemList = FindObjectOfType<ItemList>();

        CalculateStats();
    }
    private void Update()
    {
        if (!menuIsActive)
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 1000, canShoot))
            {
                aimAt = hit.point;
                if (Vector3.Distance(transform.position, aimAt) > 2)
                {
                    currentWeapon.LookAt(aimAt, Vector3.up);
                }
            }
            //gunpickup
            if (Physics.Raycast(transform.position, transform.forward, out hitInfo, 1000, guns))
            {
                if (hitInfo.transform.tag == "Gun")
                {
                    if (Input.GetButtonDown("Pickup"))
                    {
                        WeaponSwap(hitInfo.transform);
                    }
                    pressF.SetActive(true);
                } 
            }
            else
            {
                pressF.SetActive(false);
            }
            if (Input.GetButton("Fire1"))
            {
                if (Time.time >= nextAttack)
                {
                    if(holdingGun)
                    {
                        nextAttack = attackCooldown + Time.time;
                        weapon.Fire(calculatedDamage);
                    }
                    else
                    {
                        nextAttack = attackCooldownMelee + Time.time;
                        melee.Fire1(meleeDamage);
                    }
                }
            }
            //melee swap

            //if (Input.GetButtonDown("2"))
            //{
            //    holdingGun = false;
            //    SwapToMelee();
            //    CalculateStats();
            //}
            //if (Input.GetButtonDown("1"))
            //{
            //    holdingGun = true;
            //    SwapToGun();
            //    CalculateStats();
            //}
        }
    }
    private void SwapToMelee()
    {
        MeshRenderer[] ooga = weapon.GetComponentsInChildren<MeshRenderer>();
        foreach(MeshRenderer rend in ooga)
        {
            rend.enabled = holdingGun;
        }
        //weapon.gameObject.SetActive(holdingGun);
        melee.gameObject.SetActive(!holdingGun);
    }
    private void SwapToGun()
    {
        MeshRenderer[] ooga = weapon.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer rend in ooga)
        {
            rend.enabled = holdingGun;
        }
        //weapon.gameObject.SetActive(holdingGun);
        melee.gameObject.SetActive(!holdingGun);
    }
    private void WeaponSwap(Transform newWeapon)
    {
        weaponPickup.Play();
        //dump last weapon
        weapon.isUsed = false;
        currentWeapon.parent = weaponDump;
        currentWeapon.position = newWeapon.position;
        currentWeapon.rotation = newWeapon.rotation;

        //swap
        currentWeapon = newWeapon;
        currentWeapon.parent = transform;
        currentWeapon.position = weaponHold.position;
        currentWeapon.rotation = weaponHold.rotation;
        weapon = currentWeapon.GetComponent<WeaponReference>();
        gunNumber = weapon.gunNumber;
        weapon.isUsed = true;
        int ooga = 14;
        if(gunNumber == 0)
        {
            ooga = 14;
        }
        if (gunNumber == 1)
        {
            ooga = 15;
        }
        if (gunNumber == 2)
        {
            ooga = 16;
        }
        if (gunNumber == 3)
        {
            ooga = 14;
        }
        if (gunNumber == 4)
        {
            ooga = 15;
        }
        if (gunNumber == 5)
        {
            ooga = 16;
        }
        itemList.PrintItemInChat(ooga);

        CalculateStats();
    }
    public void CalculateStats()
    {
        //change damage and attackspeed
        calculatedDamage = weapon.baseDamage * (1 + (0.1f * itemList.itemQuantity[0]));

        attacksPerSec = weapon.baseAttackSpeed * (1 + (0.1f * itemList.itemQuantity[1]));
        attackCooldown = attacksPerSec / Mathf.Pow(attacksPerSec, 2);

        //melee
        //meleeDamage = melee.baseDamage * (1 + (0.1f * itemList.itemQuantity[0]));

        //attacksPerSecMelee = melee.baseAttackSpeed * (1 + (0.1f * itemList.itemQuantity[1]));
        //attackCooldownMelee = attacksPerSecMelee / Mathf.Pow(attacksPerSecMelee, 2);

        //glasscannon
        if (itemList.itemQuantity[5] > 0)
        {
            calculatedDamage *= itemList.itemQuantity[5] + itemList.itemQuantity[5];
        }
        //explosives
        if(itemList.itemQuantity[6] > 0)
        {
            weapon.explosiveChance = itemList.itemQuantity[6];
        }
        if(itemList.itemQuantity[9] > 0)
        {
            weapon.Slowbullets();
            attacksPerSec = weapon.baseAttackSpeed * (1 + (0.1f * itemList.itemQuantity[1]));
            slowBulletAttackSpeed = 1.5f * Mathf.Pow(attacksPerSec, itemList.itemQuantity[9]);
            attackCooldown = slowBulletAttackSpeed / Mathf.Pow(slowBulletAttackSpeed, 2);
        }
        //give attackSpeedCooldown to weapon
        weapon.attackSpeed = attackCooldown;
    }
    public void GetSaves()
    {
        gunNumber = PlayerPrefs.GetInt("CurrentGun", gunNumber);
    }
    public void Save()
    {
        PlayerPrefs.SetInt("CurrentGun", gunNumber);
    }
    public void DeleteSaves()
    {
        PlayerPrefs.SetInt("CurrentGun", 0);
    }
}
