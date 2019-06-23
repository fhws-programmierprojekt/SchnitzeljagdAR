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
        animator.SetBool("isPulling", true);
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

        //horizontal = Input.GetAxis("Horizontal");
        //vertical = Input.GetAxis("Vertical");

        return new Vector3(horizontal, 0, vertical).normalized;
    }

    protected override void Movement() {
        Vector3 directionVector = GetDirectonVector();

        if(directionVector.x != 0 || directionVector.z != 0 ) {
            AnimationMovementDirection(directionVector);
            Vector3 movementVector = GetDirectonVector() * Time.deltaTime * movementSpeed;
            body.MovePosition(transform.position + movementVector);
        } else {
            SetIsWalkingFalse();
        }
    }

    private void AnimationMovementDirection(Vector3 directionVector) {
        float angle = Vector3.SignedAngle(directionVector, transform.forward, Vector3.up);

        SetIsWalkingFalse();
        if(angle > 135 || angle < -135) {
            animator.SetBool("isSwordWalkingBack", true);
        } else if(angle >= 45 && angle <= 135) {
            animator.SetBool("isSwordWalkingLeft", true);
        } else if(angle > -45 && angle < 45) {
            animator.SetBool("isSwordWalking", true);
        }
        else {
            animator.SetBool("isSwordWalkingRight", true);
        }
    }
    private void SetIsWalkingFalse() {
        animator.SetBool("isSwordWalking", false);
        animator.SetBool("isSwordWalkingBack", false);
        animator.SetBool("isSwordWalkingLeft", false);
        animator.SetBool("isSwordWalkingRight", false);
    }

    public void Evade() {
        body.velocity = GetDirectonVector() * 24;

        //transform.position += GetDirectonVector() * evadeDistance;
        //body.AddForce(GetDirectonVector() * evadeDistance, ForceMode.Impulse);
    }
}
