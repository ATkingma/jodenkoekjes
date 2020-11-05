using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed, sprintSpeed, gravity, jumpForce, crouchHeight;

    //privates
    private CharacterController controller;
    private Vector3 moveDir;

    private float rotX, speed, groundedCooldown = 0.1f, downForce, bodyHeight;
    private bool mayJump;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        bodyHeight = GetComponent<CharacterController>().height;
    }

    private void Update()
    {
        //jump
        if (Input.GetButtonDown("Jump"))
        {
            if (mayJump)
            {
                mayJump = false;
                downForce = jumpForce;
            }
        }

        //sprint
        if (Input.GetButton("Sprint"))
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = movementSpeed;
        }

        //sprint
        if (Input.GetButton("Crouch"))
        {
            GetComponent<CharacterController>().height = crouchHeight;
        }
        else
        {
            GetComponent<CharacterController>().height = bodyHeight;
        }

        //gravity
        if (controller.isGrounded)
        {
            mayJump = true;
            if (Time.time == groundedCooldown + Time.time)
            {
                downForce = -0.01f;
                groundedCooldown = 0.1f;
            }
            else
            {
                groundedCooldown = 0;
            }
        }
        else
        {
            downForce -= gravity * Time.deltaTime;
        }

        //movement
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), downForce, Input.GetAxisRaw("Vertical"));
        moveDir = transform.TransformDirection(moveDir);
        controller.Move(moveDir.normalized * movementSpeed * Time.deltaTime);

        //rotation
        rotX += Input.GetAxis("Mouse X") * FindObjectOfType<CameraController>().rotSpeed;
        transform.rotation = Quaternion.Euler(0, rotX, 0f);
    }
}
