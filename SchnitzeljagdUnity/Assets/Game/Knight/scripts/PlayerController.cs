using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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
