using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReference : MonoBehaviour
{
    public float baseAttackSpeed, baseDamage, bulletSpeed;
    public Transform bulletOri;
    public Rigidbody basicBullet;
    public bool isUsed;
    public LayerMask canShoot;

    //protected
    protected float endDamage;
    protected RaycastHit hit;

    public virtual void Fire(Transform dir)
    {
    }
}
