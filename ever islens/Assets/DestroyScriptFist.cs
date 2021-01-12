using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScriptFist : MonoBehaviour
{
    public Animator anim;
    public GameObject papa;
    public AudioSource fistGoingUpSound, fistGoingDownSound;
    private float rotation;
    public float damage;
    public bool afblijven = true;
    void Start()
    {
        fistGoingUpSound.Play();
        Invoke("AnimDestroy", 2.5f);
        Invoke("Destroy", 3);
        rotation = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(new Vector3(270, rotation, 0));
        Invoke("GeenDamageMeerDoen", 0.2f);
    }
    public void AnimDestroy()
    {
        fistGoingDownSound.Play();
        anim.SetBool("Destroy", true);
    }
    public void Destroy()
    {
        Destroy(gameObject);
        Destroy(papa);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (afblijven)
            {
                other.GetComponent<PlayerHealth>().ReceiveDamage(damage, 0);
                other.GetComponent<Movement>().downForce = 3;
            }
        }
    }
    public void GeenDamageMeerDoen()
    {
        afblijven = false;
    }
}
