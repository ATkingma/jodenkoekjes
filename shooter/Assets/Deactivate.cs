using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Deactivate : MonoBehaviour
{
    private NavMeshAgent agent;
    private CharacterController controller;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        gameObject.GetComponent<EnemieScript>().enabled = false;
        gameObject.GetComponent<EnemyHealth>().enabled = false;
        gameObject.GetComponent<Animator>().enabled = false;
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
    }
    private void Update()
    {
        if (controller.isGrounded)
        {
            DoAchtive();
        }
    }
    public void DoAchtive()
    {
        gameObject.GetComponent<EnemieScript>().enabled = true;
        gameObject.GetComponent<EnemyHealth>().enabled = true;
        gameObject.GetComponent<Animator>().enabled = true;
        agent.enabled = true;
    }
}