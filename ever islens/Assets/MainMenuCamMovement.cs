using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamMovement : MonoBehaviour
{
    public GameObject[] checkPoints;
    private int index=0;
    // Update is called once per frame
    public void OnTriggerEnter(Collider gameobject)
    {
        if (gameobject.gameObject.tag == "MovementBlock")
        {
            index++;
        }
    }
    void Update()
    {
        if (index >= 24)
        {
            index = 0;
        }
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = checkPoints[index].transform.position;
    }
}
