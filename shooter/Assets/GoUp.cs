using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GoUp : MonoBehaviour
{
    //public
    public bool canGoUp;
    //private

    // Update is called once per frame
    void Update()
    {
        if (canGoUp)
        {
        if (transform.position.y <= -0.07f)
        {
        transform.position += new Vector3(0, 1.4f, 0) * Time.deltaTime ;              
        }
        }
    }
}