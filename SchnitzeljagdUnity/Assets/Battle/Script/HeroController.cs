using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour {

    //Attributes
    public GameObject Opponent { get; set; }

    private Rigidbody Rigidbody { get; set; }
    private Joystick Joystick { get; set; }


    public Vector3 SpawnPosition { get; set; }
    public float MovementSpeed { get; set; } = 0.6f;
    public float RotationSpeed { get; set; } = 100f;


    // Start is called before the first frame update
    public void Start() {
        Rigidbody = GetComponent<Rigidbody>();
        Joystick = FindObjectOfType<FixedJoystick>();
    }

    // Update is called once per frame
    public void Update() {
        Movement();
    }

    private void Movement() {
        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");

        float horizontal = Joystick.Horizontal;
        float vertical = Joystick.Vertical;

        //Calculate movementVector from Input
        Vector3 movementVector = new Vector3(horizontal, 0, vertical).normalized;
        movementVector = movementVector * Time.deltaTime * MovementSpeed;
        Rigidbody.MovePosition(transform.position + movementVector);
    }
}
