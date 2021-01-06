using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DestroyInpactShow : MonoBehaviour
{
    public AudioSource InPackSound;
    void Start()
    {
        InPackSound.Play();
        Invoke("Destroy", 1);
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}