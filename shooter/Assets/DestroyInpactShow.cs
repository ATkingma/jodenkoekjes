using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DestroyInpactShow : MonoBehaviour
{
    void Start()
    {
        Invoke("Destroy", 1);
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}