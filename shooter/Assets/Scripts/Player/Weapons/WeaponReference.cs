using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReference : MonoBehaviour
{
    public float baseAttackSpeed, baseDamage, baseBulletSpeed, attackSpeed, explosiveChance, bulletSpeedMulti;
    public int maxAmmo, ammoRecharge;
    public Transform bulletOri, muzzleFlash;
    public Rigidbody basicBullet;
    public bool isUsed;
    public LayerMask canShoot;
    public GameObject gem;

    //protected
    protected RaycastHit hit;
    protected ItemList list;
    protected bool isExplosive, isReloading;
    protected float bulletSpeed, reloadDone;
    protected int ammo;
    protected MeshRenderer mat;

    private void Start()
    {
        list = FindObjectOfType<ItemList>();
        bulletSpeed = baseBulletSpeed;
        ammo = maxAmmo;
        reloadDone = Time.time + ammoRecharge;
        mat = gem.GetComponent<MeshRenderer>();
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
    public void ReloadSpeed()
    {
        ammo = maxAmmo;
        isReloading = false;
    }

    public void Slowbullets()
    {
        bulletSpeed = baseBulletSpeed / Mathf.Pow(2, list.itemQuantity[15]);
    }
}
