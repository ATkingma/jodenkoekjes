using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : WeaponReference
{
    public override void Fire(Transform dir)
    {
        Rigidbody clone = Instantiate(basicBullet, bulletOri.position, transform.rotation);
        clone.velocity = clone.transform.forward;
    }
}
