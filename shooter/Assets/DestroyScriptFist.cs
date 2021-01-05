using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScriptFist : MonoBehaviour
{
    public Animator anim;
    public GameObject papa;
    private float rotation;
    public float damage;
    void Start()
    {
        Invoke("AnimDestroy", 2.5f);
        Invoke("Destroy", 3);
        rotation = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(new Vector3(270, rotation, 0));
    }
    public void AnimDestroy()
    {
        anim.SetBool("Destroy", true);
    }
    public void Destroy()
    {
        Destroy(gameObject);
        Destroy(papa);
    }
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerHealth>().ReceiveDamage(damage, 0);
    }
}
