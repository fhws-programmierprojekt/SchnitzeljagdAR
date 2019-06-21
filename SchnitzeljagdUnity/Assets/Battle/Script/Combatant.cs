using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combatant {

    //attributes

    public GameObject Body { get; set; }
    public Rigidbody Rigidbody { get; set; }
    public Vector3 SpawnPosition { get; set; }
    public float MovementSpeed { get; set; }
    public float RotationSpeed { get; set; } = 100;

    public Combatant Opponent { get; set; }

    //constructors
    public Combatant(GameObject body, Vector3 spawnPosition, float movementSpeed) {
        Body = body;
        SpawnPosition = spawnPosition;
        MovementSpeed = movementSpeed;

        Body.transform.position = SpawnPosition;
        Rigidbody = Body.GetComponent<Rigidbody>();
    }

    //Update is called once per frame
    public void Update() {
        Movement();
        Rotation(Body, Opponent.Body);
        Fallen(Body, 10);
    }

    //methods
    protected virtual void Movement() {

        if(Vector3.Distance(Body.transform.position, Opponent.Body.transform.position) > 1.2f) {
            Vector3 movementVector = (Opponent.Body.transform.position - Body.transform.position).normalized;
            movementVector = movementVector * Time.deltaTime * MovementSpeed;
            Rigidbody.MovePosition(Body.transform.position + movementVector);
        }
    }
    private void Rotation(GameObject origin, GameObject target) {

        //Calculate directionVector from origin to target
        Vector3 directionVector = (target.transform.position - origin.transform.position).normalized;
        Quaternion directionQuaternion = Quaternion.LookRotation(new Vector3(directionVector.x, 0, directionVector.z));
        Quaternion rotationQuaternion = Quaternion.Slerp(origin.transform.rotation, directionQuaternion, Time.deltaTime * RotationSpeed);
        Rigidbody.MoveRotation(rotationQuaternion);
    }
    private void Fallen(GameObject origin, float height) {
        if(origin.transform.position.y < height) {
            origin.transform.position = SpawnPosition;
        }
    }

















    private void SetRigidbody(GameObject gameObject) {
        gameObject.AddComponent<Rigidbody>();

        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.mass = 1;
        rigidbody.drag = 0;
        rigidbody.angularDrag = 0.05f;
        rigidbody.useGravity = true;
        rigidbody.isKinematic = false;
        rigidbody.interpolation = RigidbodyInterpolation.None;
        rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
    }
}
