﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Var for the movement 

    public float moveSpeed = 2;         //movementspeed      
    public float rotationRate = 360;    //rotationspeed
    public float gravity = 8;           //gravity 
    Vector3 moveDir = Vector3.zero;     //position
    float rot = 0f;                     //rotation

    //Componets used for movement, animation, controlling.
    Rigidbody rBody;    
    CharacterController controller;
    Animator anim;
    Joystick joystick;

    //Start is called before the first frame update   

    void Start()
    {
        //Functios to check for componets 
        if (GetComponent<CharacterController>())
        {
            controller = GetComponent<CharacterController>();
        }
        else
        {
            Debug.LogError("The character needs a charactercontroller");
        }
        if (GetComponent<Animator>())
        {
            anim = GetComponent<Animator>();
        }
        else
        {
            Debug.LogError("The character needs a animator");
        }
        if (GetComponent<Rigidbody>())
        {
            rBody = GetComponent<Rigidbody>();
        }
        else
        {
            Debug.LogError("The character needs a rigidbody");
        }
        joystick = FindObjectOfType<Joystick>();

    }

    void Update()
    {

        //Movement Functions only for the mazerun minigame
        if (SceneManager.GetActiveScene().buildIndex == 14 )
        {
            float moveAxis = 0f;
            float turnAxis = 0f;

            moveAxis = joystick.Vertical * 0.8f;
            turnAxis = joystick.Horizontal * 0.8f;


            if (controller.isGrounded)
            {
                if (moveAxis != 0)
                {
                    anim.SetBool("isWalking", true);
                    moveDir = new Vector3(0, 0, moveAxis);
                    moveDir *= moveSpeed;
                    moveDir = transform.TransformDirection(moveDir);
                }
                if (moveAxis == 0)
                {
                    anim.SetBool("isWalking", false);
                    moveDir = new Vector3(0, 0, 0);
                }
            }
            rot += turnAxis * rotationRate * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, rot, 0);

            if (moveAxis != 0)
            {
                moveDir.y -= gravity * Time.deltaTime;
                controller.Move(moveDir * Time.deltaTime);
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 18)
        {
            float moveAxis = 0f;
            float turnAxis = 0f;

            moveAxis = joystick.Vertical * 0.4f;
            turnAxis = joystick.Horizontal * 0.4f;


            if (controller.isGrounded)
            {
                if (moveAxis != 0)
                {
                    anim.SetBool("isSwordWalking", true);
                    moveDir = new Vector3(0, 0, moveAxis);
                    moveDir *= moveSpeed;
                    moveDir = transform.TransformDirection(moveDir);
                }
                if (moveAxis == 0)
                {
                    anim.SetBool("isSwordWalking", false);
                    moveDir = new Vector3(0, 0, 0);
                }
            }
            rot += turnAxis * rotationRate * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, rot, 0);

            if (moveAxis != 0)
            {
                moveDir.y -= gravity * Time.deltaTime;
                controller.Move(moveDir * Time.deltaTime);
            }
        }
    }
    
    //ANIMATION FUNCTION

    public void playAnimation(string animationName)
    {
        //Animation list: StandingGreeting, Talking, Talking02, Talking03, Talking04, Talking05, Pointing, Defeated, LookingAround, ChickenDance.
        anim.Play(animationName);
    }
    //CHARACTER FUNCTIONS

    public void setRolandActivDisactiv(bool status)
    {
        this.gameObject.SetActive(status);
    }
}