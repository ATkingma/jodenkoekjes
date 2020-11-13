using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReference : MonoBehaviour
{
    public float baseAttackSpeed, baseDamage, baseBulletSpeed, attackSpeed, explosiveChance, bulletSpeedMulti;
    public Transform bulletOri;
    public Rigidbody basicBullet;
    public bool isUsed;
    public LayerMask canShoot;

    //protected
    protected RaycastHit hit;
    protected ItemList list;
    protected bool isExplosive;
    protected float bulletSpeed;

    private void Start()
    {
        list = FindObjectOfType<ItemList>();
        bulletSpeed = baseBulletSpeed;
    }
    public virtual void Fire(float dir) { }
    public virtual void Fire2(float dir) { }
    public void DoFuntions(float dir)
    {
        StartCoroutine(DoubleShot(dir));
    }
    public IEnumerator DoubleShot(float dir)
    {
        yield return new WaitForSeconds(0.1f * attackSpeed);
        float doubleChance = Random.Range(1, 5);
        if(doubleChance == list.itemQuantity[10])
        {
            Fire2(dir);
        }
    }

    public void Slowbullets()
    {
        bulletSpeed = baseBulletSpeed / Mathf.Pow(2, list.itemQuantity[15]);
    }
}
