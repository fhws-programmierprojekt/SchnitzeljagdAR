using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillainController : MonoBehaviour {

    //Attributes
    public GameObject opponent;
    protected Rigidbody body;

    public float movementSpeed;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        Movement();
        Rotation(opponent);
    }

    protected virtual void Movement() {

        //Calculate the distance between this and opponent
        float distance = Vector3.Distance(transform.position, opponent.transform.position);

        if(distance > 1.2f) {
            Vector3 movementVector = (opponent.transform.position - transform.position).normalized;
            movementVector = movementVector * Time.deltaTime * movementSpeed;
            body.MovePosition(transform.position + movementVector);
        }
    }
    protected void Rotation(GameObject target) {

        //Calculate directionVector from origin to target
        Vector3 directionVector = (target.transform.position - transform.position).normalized;
        Quaternion directionQuaternion = Quaternion.LookRotation(new Vector3(directionVector.x, 0, directionVector.z));
        Quaternion rotationQuaternion = Quaternion.Slerp(transform.rotation, directionQuaternion, Time.deltaTime * rotationSpeed);
        body.MoveRotation(rotationQuaternion);
    }

    //public void Fallen(GameObject origin, float height) {
    //    if(origin.transform.position.y < height) {
    //        origin.transform.position = SpawnPosition;
    //    }
    //}
}
