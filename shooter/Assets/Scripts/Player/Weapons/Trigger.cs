﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Transform weaponHold, weaponDump;
    public LayerMask canShoot, guns;

    //privates
    private float nextAttack, attackCooldown, attacksPerSec, calculatedDamage;
    private Transform currentWeapon;
    private WeaponReference weapon;
    private RaycastHit hit, hitInfo;
    private Vector3 aimAt;
    private ItemList itemList;

    private void Start()
    {
        currentWeapon = GetComponentInChildren<WeaponReference>().transform;
        weapon = currentWeapon.GetComponent<WeaponReference>();
        itemList = FindObjectOfType<ItemList>();
        currentWeapon.position = weaponHold.position;

        CalculateStats();
    }
    private void Update()
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
        if(Physics.Raycast(transform.position, transform.forward, out hitInfo, 1000, guns))
        {
            if (Input.GetButtonDown("Fire2"))
            {
                if (hitInfo.transform.tag == "Gun")
                {
                    WeaponSwap(hitInfo.transform);
                }
            }
        }
        if (Input.GetButton("Fire1"))
        {
            if(Time.time >= nextAttack)
            {
                nextAttack = attackCooldown + Time.time;
                weapon.Fire(calculatedDamage);
            }
        }
    }

    private void WeaponSwap(Transform newWeapon)
    {
        //dump last weapon
        weapon.isUsed = false;
        currentWeapon.parent = weaponDump;
        currentWeapon.position = newWeapon.position;
        currentWeapon.rotation = newWeapon.rotation;

        //swap
        currentWeapon = newWeapon;
        currentWeapon.parent = transform;
        currentWeapon.position = weaponHold.position;
        weapon = currentWeapon.GetComponent<WeaponReference>();
        weapon.isUsed = true;

        CalculateStats();
    }
    public void CalculateStats()
    {
        //change damage and attackspeed
        calculatedDamage = weapon.baseDamage * (1 + (0.1f * itemList.itemQuantity[0]));

        attacksPerSec = weapon.baseAttackSpeed * (1 + (0.1f * itemList.itemQuantity[1]));
        attackCooldown = attacksPerSec / Mathf.Pow(attacksPerSec, 2);
        weapon.attackSpeed = attackCooldown;

        if(itemList.itemQuantity[10] >= 0)
        {
            weapon.doubleShotActive = true;
        }
    }
}
