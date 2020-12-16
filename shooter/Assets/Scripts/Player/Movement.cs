using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed, sprintSpeed, gravity, jumpForce, crouchHeight;

    //privates
    private CharacterController controller;
    private Vector3 moveDir;

    private float rotX, speed, groundedCooldown = 0.1f, downForce, bodyHeight, baseSprintSpeed, baseMovewmentSpeed;
    private int jumpcount;

    private ItemList list;

    private MainMenu menu;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        bodyHeight = GetComponent<CharacterController>().height;
        list = FindObjectOfType<ItemList>();
        JumpCheck();
        baseMovewmentSpeed = movementSpeed;
        baseSprintSpeed = sprintSpeed;
        menu = FindObjectOfType<MainMenu>();

        FindObjectOfType<PlayerHealth>().CalculateStats();
        //+maxhealth
        //execute
        //lifesteal
        //glasscannon
        FindObjectOfType<PlayerHealth>().health = FindObjectOfType<PlayerHealth>().maxHealth;

        FindObjectOfType<Index>().AddItem();
    }

    private void Update()
    {
        //sprint
        if (Input.GetButton("Sprint"))
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = movementSpeed;
        }

        //crouch
        //if (Input.GetButton("Crouch"))
        //{
        //    GetComponent<CharacterController>().height = crouchHeight;
        //}
        //else
        //{
        //    GetComponent<CharacterController>().height = bodyHeight;
        //}

        //gravity
        if (controller.isGrounded)
        {
            if (Time.time == groundedCooldown + Time.time)
            {
                downForce = -0.01f;
            }
            if (Input.GetButtonDown("Jump"))
            {
                if (jumpcount >= 0)
                {
                    downForce = jumpForce;
                }
            }

            JumpCheck();
        }
        else
        {
            downForce -= gravity * Time.deltaTime;
            //jump
            if (Input.GetButtonDown("Jump"))
            {
                if (jumpcount > 0)
                {
                    jumpcount--;
                    downForce = jumpForce;
                }
            }
        }


        //movement
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        moveDir = transform.TransformDirection(moveDir);
        controller.Move(moveDir.normalized * speed * Time.deltaTime);
        controller.Move(new Vector3(0, downForce, 0) * speed * Time.deltaTime);

        if (!menu.anyIsOn)
        {
            //rotation
            rotX += Input.GetAxis("Mouse X") * FindObjectOfType<CameraController>().rotSpeed;
            transform.rotation = Quaternion.Euler(0, rotX, 0f);
        }
        //test
        if (Input.GetButtonDown("Fire3"))
        {
            FindObjectOfType<Trigger>().CalculateStats();
            //damage
            //attackspeed
            //doubleshot
            //explosive
            //slow bullets

            FindObjectOfType<Movement>().CalculateStats();
            //movementspeed

            FindObjectOfType<PlayerHealth>().CalculateStats();
            //+maxhealth
            //execute
            //lifesteal
            //glasscannon

            FindObjectOfType<Index>().AddItem();
        }
    }
    private void JumpCheck()
    {
        jumpcount = (int)list.itemQuantity[11];
    }
    public void CalculateStats()
    {
        sprintSpeed = baseSprintSpeed * (1 + (0.1f * list.itemQuantity[3]));
        movementSpeed = baseMovewmentSpeed * (1 + (0.1f * list.itemQuantity[3]));
    }
}
