using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillainController : MonoBehaviour {

    //Attributes
    public GameObject opponent;

    protected Vector3 spawnPosition;
    protected Rigidbody body;
    protected Animator animator;

    public float movementSpeed;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start() {
        spawnPosition = transform.position;
        body = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        Movement();
        Rotation(opponent);
    }

    protected virtual void Movement() {

        //Calculate the distance between this and opponent
        float distance = Vector3.Distance(transform.position, opponent.transform.position);

        if(distance > 3 && !animator.GetBool("isAttackSpin")) {
            animator.SetBool("isSwordWalking", true);
            Vector3 movementVector = (opponent.transform.position - transform.position).normalized;
            movementVector = movementVector * Time.deltaTime * movementSpeed;
            body.MovePosition(transform.position + movementVector);
        } else {
            animator.SetBool("isSwordWalking", false);
        }
    }
    protected void Rotation(GameObject target) {

        //Calculate directionVector from origin to target
        Vector3 directionVector = (target.transform.position - transform.position).normalized;
        Quaternion directionQuaternion = Quaternion.LookRotation(new Vector3(directionVector.x, 0, directionVector.z));
        Quaternion rotationQuaternion = Quaternion.Slerp(transform.rotation, directionQuaternion, Time.deltaTime * rotationSpeed);
        body.MoveRotation(rotationQuaternion);
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.transform.gameObject.name == "DeathFloor") {
            Invoke("Respawn", 5);
        }
    }
    private void Respawn() {
        transform.position = spawnPosition;
    }
}
