using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScriptFist : MonoBehaviour
{
    public Animator anim;
    public GameObject papa;
    void Start()
    {
        Invoke("AnimDestroy", 2.5f);
        Invoke("Destroy", 3);
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
}
