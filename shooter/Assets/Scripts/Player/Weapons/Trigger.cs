using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Transform weaponHold;
    public LayerMask canShoot;

    //privates
    private float nextAttack, attackCooldown;
    private Transform currentWeapon;
    private WeaponReference weapon;
    private RaycastHit hit;
    private Vector3 aimAt;

    private void Start()
    {
        currentWeapon = GetComponentInChildren<WeaponReference>().transform;
        weapon = currentWeapon.GetComponent<WeaponReference>();
        currentWeapon.position = weaponHold.position;
    }
    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, canShoot))
        {
            aimAt = hit.point;
            if (Vector3.Distance(transform.position, aimAt) > 2)
            {
                currentWeapon.LookAt(aimAt, Vector3.up);
            }
        }
        if (Input.GetButton("Fire1"))
        {
            if(Time.time >= nextAttack)
            {
                weapon.Fire(transform);
                nextAttack = attackCooldown + Time.time;
            }
        }
    }

    private void WeaponSwap(Transform newWeapon)
    {
        weapon.isUsed = false;
        currentWeapon.parent = FindObjectOfType<Transform>(tag == "WeaponDump");
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
