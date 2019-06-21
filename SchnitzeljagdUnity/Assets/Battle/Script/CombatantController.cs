using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatantController : Combatant {

    private Joystick Joystick { get; set; }

    //Constructors
    public CombatantController(GameObject body, Vector3 spawnPosition, float movementSpeed) : base(body, spawnPosition, movementSpeed) {
        Joystick = Object.FindObjectOfType<FixedJoystick>();
    }

    protected override void Movement() {

        float horizontal = Joystick.Horizontal;
        float vertical = Joystick.Vertical;

        //Calculate movementVector from Input
        Vector3 movementVector = new Vector3(horizontal, 0, vertical).normalized;
        movementVector = movementVector * Time.deltaTime * MovementSpeed;
        Rigidbody.MovePosition(Body.transform.position + movementVector);
    }

}
