﻿using UnityEngine;

public class CameraController : MonoBehaviour
{
    // camera controls
    private float rotX;
    private float rotY;

    // max rotation
    public float maxLookUp;
    public float maxLookDown;
    public float rotSpeed;

    // position
    public GameObject player;

    //private
    private IngameMenu menu;

    private void Start()
    {
        menu = FindObjectOfType<IngameMenu>();
    }
    void Update()
    {
        if (!menu.anyIsOn)
        {
            transform.position = player.transform.position;
            //rotation
            rotX += Input.GetAxis("Mouse X") * rotSpeed;
            rotY += Input.GetAxis("Mouse Y") * rotSpeed;

            rotY = Mathf.Clamp(rotY, -maxLookDown, maxLookUp);
            transform.rotation = Quaternion.Euler(-rotY, rotX, 0f);
        }
    }
}
