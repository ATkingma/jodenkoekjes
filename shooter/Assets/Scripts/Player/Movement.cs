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
    private bool mayJump, mayJumpCheck;

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
        //jump
        if (Input.GetButtonDown("Jump"))
        {
            if (mayJump)
            {
                mayJump = false;
                downForce = jumpForce;
                Invoke("JumpCheck", 0.1f);
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
            if(mayJumpCheck)
            {
                mayJumpCheck = false;
                mayJump = true;
            }
            if (Time.time == groundedCooldown + Time.time)
            {
                downForce = -0.01f;
            }
        }
        else
        {
            downForce -= gravity * Time.deltaTime;
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
        mayJumpCheck = true;
    }
    public void CalculateStats()
    {
        sprintSpeed = baseSprintSpeed * (1 + (0.1f * list.itemQuantity[3]));
        movementSpeed = baseMovewmentSpeed * (1 + (0.1f * list.itemQuantity[3]));
    }
}
