using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Deactivate : MonoBehaviour
{
    public AudioSource yeetsound;
    private float speed;
    private NavMeshAgent agent;
    private CharacterController controller;
    private GameObject player;
    private Rigidbody rb;
    private float x, y, z;
    private GameObject ground;
    private bool floowwn;

    void Start()
    {
        Invoke("Fly", 0.7f);
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
        rb.velocity = transform.up *4;
        yeetsound.Play();
        ground = GameObject.FindGameObjectWithTag("ground");
        Invoke("LookGround", 4);
    }
    private void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(x, y, z));
        x = +0.0001f;
        y = +0.0001f;
        z = +0.0001f;
    }
    public void Fly()
    {
        DoAchtive();
        print("jiea");
    }
    public void DoAchtive()
    {
        agent.enabled = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        gameObject.GetComponent<EnemieScript>().enabled = true;
        gameObject.GetComponent<EnemyHealth>().enabled = true;
        gameObject.GetComponent<Animator>().enabled = true;
        controller.enabled = false;
    }
    public void LookGround()
    {
        transform.LookAt(ground.transform);
    }
}