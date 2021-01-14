using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour
{
    public GameObject lookAtObject;
    void Update()
    {
        gameObject.transform.LookAt(lookAtObject.transform);
    }
}
