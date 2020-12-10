using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponReference : MonoBehaviour
{
    public float baseAttackSpeed, baseDamage, baseBulletSpeed, attackSpeed, explosiveChance, bulletSpeedMulti;
    public int maxAmmo, ammoRecharge;
    public Transform bulletOri, muzzleFlash;
    public Rigidbody basicBullet;
    public bool isUsed;
    public LayerMask canShoot;
    public GameObject gem;
    public int gunNumber;
    //recoil
    public Vector3 recoilUp;
    public float spread;

    //protected
    protected RaycastHit hit;
    protected ItemList list;
    protected bool isExplosive, isReloading;
    protected float bulletSpeed, ammo;
    protected MeshRenderer mat;
    protected TextMeshProUGUI ammoItem;

    private void Awake()
    {
        list = FindObjectOfType<ItemList>();
        bulletSpeed = baseBulletSpeed;
        ammo = maxAmmo;
        mat = gem.GetComponent<MeshRenderer>();
    }
    private void Start()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("AmmoItem");
        ammoItem = temp.GetComponent<TextMeshProUGUI>();
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

    public void RecoilUp()
    {
        transform.localEulerAngles += recoilUp;
        Invoke("RecoilDown", 0.1f);
    }
    public void RecoilDown()
    {
        transform.localEulerAngles -= recoilUp / 2;
    }
}
