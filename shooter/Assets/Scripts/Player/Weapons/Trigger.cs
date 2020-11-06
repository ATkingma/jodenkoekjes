using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Transform weaponHold, weaponDump;
    public LayerMask canShoot, guns;

    //privates
    private float nextAttack, attackCooldown;
    private Transform currentWeapon;
    private WeaponReference weapon;
    private RaycastHit hit, hitInfo;
    private Vector3 aimAt;

    private void Start()
    {
        currentWeapon = GetComponentInChildren<WeaponReference>().transform;
        weapon = currentWeapon.GetComponent<WeaponReference>();
        currentWeapon.position = weaponHold.position;
        attackCooldown = weapon.baseAttackSpeed / (weapon.baseAttackSpeed * weapon.baseAttackSpeed);
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
                weapon.Fire(transform);
            }
        }
    }

    private void WeaponSwap(Transform newWeapon)
    {
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
        attackCooldown = weapon.baseAttackSpeed / (weapon.baseAttackSpeed * weapon.baseAttackSpeed);
    }
}
