using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : WeaponReference
{
    public override void Fire(float dir)
    {
        if (ammo > 0)
        {
            if (Random.Range(1, 10) <= explosiveChance)
            {
                isExplosive = true;
                basicBullet.GetComponent<BulletBehaviour>().explode = isExplosive;
            }
            else
            {
                isExplosive = false;
                basicBullet.GetComponent<BulletBehaviour>().explode = isExplosive;
            }
            Rigidbody clone = Instantiate(basicBullet, bulletOri.position, transform.rotation);
            clone.velocity = clone.transform.forward * bulletSpeed;
            clone.GetComponent<BulletBehaviour>().damage = dir;
            DoFuntions(dir);
            ammo--;
        }
        else
        {
            if (!isReloading)
            {
                isReloading = true;
                Invoke("ReloadSpeed", ammoRecharge);
            }
        }
    }
    public override void Fire2(float dir)
    {
        Rigidbody clone = Instantiate(basicBullet, bulletOri.position, transform.rotation);
        clone.velocity = clone.transform.forward * bulletSpeed;
        clone.GetComponent<BulletBehaviour>().damage = dir;
    }
}
