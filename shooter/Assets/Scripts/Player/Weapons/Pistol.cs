using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pistol : WeaponReference
{
    public override void Fire(float dir)
    {
        if (ammo >= 1)
        {
            if (Random.Range(1, 11) <= explosiveChance)
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
            //spread
            var randomNumberX = Random.Range(-spread, spread);
            var randomNumberY = Random.Range(-spread, spread);
            var randomNumberZ = Random.Range(-spread, spread);
            clone.transform.Rotate(randomNumberZ, randomNumberY, randomNumberZ);

            //muzzleflash
            Invoke("MuzzOff", 0.1f);
            muzzNum = Random.Range(1, 3);
            if(muzzNum == 1)
            {
                muzzleFlash.gameObject.SetActive(true);
            }
            else
            {
                muzzleFlash2.gameObject.SetActive(true);
            }

            //clone.velocity = clone.transform.forward * bulletSpeed;
            //crits
            int crit = Random.Range(1, 100);
            if(crit <= list.itemQuantity[12])
            {
                dir *= 2;
            }
            //random damage
            dir = Random.Range(dir - (0.1f * dir), dir + (0.1f * dir));
            dir = Mathf.Round(dir);
            clone.GetComponent<BulletBehaviour>().speed = bulletSpeed;
            clone.GetComponent<BulletBehaviour>().damage = dir;
            clone.GetComponent<BulletBehaviour>().explosionCount = list.itemQuantity[6];
            clone.GetComponent<BulletBehaviour>().weaponUsed = gunNumber;
            clone.GetComponent<BulletBehaviour>().richocetAmount = (int)list.itemQuantity[13];
            RecoilUp();
            DoFuntions(dir);
            ammo--;
        }
    }
    public override void Fire2(float dir)
    {
        Rigidbody clone = Instantiate(basicBullet, bulletOri.position, transform.rotation);
        var randomNumberX = Random.Range(-spread, spread);
        var randomNumberY = Random.Range(-spread, spread);
        var randomNumberZ = Random.Range(-spread, spread);
        clone.transform.Rotate(randomNumberZ, randomNumberY, randomNumberZ);
        clone.GetComponent<BulletBehaviour>().speed = bulletSpeed;
        clone.GetComponent<BulletBehaviour>().damage = dir;
        clone.GetComponent<BulletBehaviour>().explosionCount = list.itemQuantity[6];
        clone.GetComponent<BulletBehaviour>().weaponUsed = gunNumber;
        clone.GetComponent<BulletBehaviour>().richocetAmount = (int)list.itemQuantity[13];
        RecoilUp();
    }

    public void Update()
    {
        if(isUsed)
        {
            GameObject temp = GameObject.FindGameObjectWithTag("AmmoItem");
            ammoItem = temp.GetComponent<TextMeshProUGUI>();
            if (ammo < maxAmmo)
            {
                ammo = Mathf.Clamp(ammo += Time.deltaTime * (0.5f * baseAttackSpeed), 0, maxAmmo);
            }
            ammoItem.text = Mathf.Floor(ammo) + " / " + maxAmmo.ToString();
            Color nNew = new Color(mat.material.color.r, mat.material.color.g, mat.material.color.b, ammo / (0.1f * maxAmmo));
            mat.material.SetColor("_BaseColor", nNew);
        }
    }
    public void MuzzOff()
    {
        if (muzzNum == 1)
        {
            muzzleFlash.gameObject.SetActive(false);
        }
        else
        {
            muzzleFlash2.gameObject.SetActive(false);
        }
    }
}
