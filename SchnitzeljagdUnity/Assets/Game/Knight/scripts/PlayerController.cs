using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        //Movement Functions
        float x = CrossPlatformInputManager.GetAxis("Horizontal");
        float y = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, 0, y);

        rb.velocity = movement * 1f;

        if(x != 0 && y != 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(x, y) * Mathf.Rad2Deg, transform.eulerAngles.z);
        }
        if(x != 0 || y != 0)
        {
            anim.Play("Walking");
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
