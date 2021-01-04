using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Deactivate : MonoBehaviour
{
    private float speed;
    private NavMeshAgent agent;
    private CharacterController controller;
    private GameObject player;
    private Rigidbody rb;
    private float x, y, z;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        gameObject.GetComponent<EnemieScript>().enabled = false;
        gameObject.GetComponent<EnemyHealth>().enabled = false;
        gameObject.GetComponent<Animator>().enabled = false;
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(player.transform);
        rb = GetComponent<Rigidbody>();
        speed = 25;    
        rb.velocity = transform.forward * speed;
    }
    private void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(x, y, z));
        x = +0.0001f;
        y = +0.0001f;
        z = +0.0001f;
    }
    public void OnTriggerEnter(Collider gameobject)
    {
        if (gameobject.gameObject.tag == "Ground")
        {
        
            DoAchtive();
        }
            
    }
    public void DoAchtive()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        gameObject.GetComponent<EnemieScript>().enabled = true;
        gameObject.GetComponent<EnemyHealth>().enabled = true;
        gameObject.GetComponent<Animator>().enabled = true;
        agent.enabled = true;
        controller.enabled = false;
    }
}