using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBeamScript : MonoBehaviour
{
    //public
    public float speed,coolDown;
    //private
    private GameObject player;
    private bool canGoForward;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameObject.transform.LookAt(player.transform);
        Invoke("SetTrue", coolDown);
    }
    public void SetTrue()
    {
        canGoForward = true;
    }
    void Update()
    {
        if (canGoForward == true)
        {
        transform.Translate(Vector3.forward * speed);
        }
    }

    public void OnTriggerEnter(Collider gameobject)
    {
        if (gameobject.gameObject.tag == "Player")
        {
          
        }
    }
}