using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : VillainController {

    public Joystick joystick;

    public float evadeDistance;
    public float evadeCooldown;
    private float currentEvadeCooldown;

    // Update is called once per frame
    void Update() {
        Movement();
        Rotation(opponent);

        if(Input.GetKeyDown(KeyCode.Space)) {
            Evade();
        }
    }

    private Vector3 GetDirectonVector() {
        //Take Input from Joystick
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        return new Vector3(horizontal, 0, vertical).normalized;
    }

    protected override void Movement() {
        Vector3 directionVector = GetDirectonVector();

        if(directionVector.x != 0 || directionVector.z != 0 ) {
            animator.SetBool("isSwordWalking", true);
            Vector3 movementVector = GetDirectonVector() * Time.deltaTime * movementSpeed;
            body.MovePosition(transform.position + movementVector);
        } else {
            animator.SetBool("isSwordWalking", false);
        }
    }

    public void Evade() {
        transform.position += GetDirectonVector() * evadeDistance;
        //body.AddForce(GetDirectonVector() * evadeDistance, ForceMode.Impulse);
    }
}
