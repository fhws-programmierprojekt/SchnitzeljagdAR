using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{


    public float moveSpeed = 2;
    public float rotationRate = 360;
    public float gravity = 8;

    Vector3 moveDir = Vector3.zero;
    float rot = 0f;

    Rigidbody rBody;
    CharacterController controller;
    Animator anim;
    Joystick joystick;



    // Start is called before the first frame update   

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
        //Movement Functions
        float moveAxis = 0f;
        float turnAxis = 0f ;
        
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

        if(moveAxis != 0)
        {
            moveDir.y -= gravity * Time.deltaTime;
            controller.Move(moveDir * Time.deltaTime);
        }





        //Animation Functios
        if (Input.GetKeyDown("1"))
        {
            anim.Play("StandingGreeting");
        }
        if (Input.GetKeyDown("2"))
        {
            anim.Play("Talking");
        }
        if (Input.GetKeyDown("3"))
        {
            anim.Play("Talking02");
        }
        if (Input.GetKeyDown("4"))
        {
            anim.Play("Talking03");
        }
        if (Input.GetKeyDown("5"))
        {
            anim.Play("Talking04");
        }
        if (Input.GetKeyDown("6"))
        {
            anim.Play("Talking05");
        }
        if (Input.GetKeyDown("7"))
        {
            anim.Play("Pointing");
        }
        if (Input.GetKeyDown("8"))
        {
            anim.Play("Defeated");
        }
        if (Input.GetKeyDown("9"))
        {
            anim.Play("LookingAround");
        }
        if (Input.GetKeyDown("0"))
        {
            anim.Play("ChickenDance");
        }
    }

}
