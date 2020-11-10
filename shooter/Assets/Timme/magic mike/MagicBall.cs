using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
    //public
    public float speed;
    //private
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameObject.transform.LookAt(player.transform);
    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed);
    }
    public void OnTriggerEnter(Collider gameobject)
    {
        if (gameobject.gameObject.tag == "Player")
        {
            print("kanker dat deed pijn");
        }
    }
}