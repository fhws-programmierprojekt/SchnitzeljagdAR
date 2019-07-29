using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyGeometry {

    #region Methods
    // Takes two Vectors and calculates their angle from -180 to 180.
    // Takes two Numbers and calculates the Range in which the privous angle should be
    // Calculation happens Clockwise angleStart to angleEnd
    public static bool IsWithinAngle(Vector3 from, Vector3 to, float angleStart, float angleEnd) {
        bool isWithinAngle = false;
        if( angleStart >= -180 && angleStart <= 180 && angleEnd >= -180 && angleEnd <= 180) {
            float signedangle = Vector3.SignedAngle(from, to, Vector3.up);

            if(angleStart < angleEnd) {
                if(signedangle >= angleStart && signedangle <= angleEnd) {
                    isWithinAngle = true;
                }
            }
            else if(angleStart > angleEnd) {
                if(signedangle >= angleStart || signedangle <= angleEnd) {
                    isWithinAngle = true;
                }
            }
            else if(angleStart == angleEnd) {
                if(signedangle == angleStart) {
                    isWithinAngle = true;
                }
            }
        }
        return isWithinAngle;
    }

    // Takes two Vectors and calculates the Direction Vector
    // Calculates the Direction Vector with a magnitute of 1
    public static Vector3 GetDirectionVector(Vector3 from, Vector3 to) {
        return (to - from).normalized;
    }

    // Takes two GameObjects and calculates the Rotation Movement
    public static Quaternion GetRotationQuaternion(GameObject origin, GameObject target, float rotationSpeed) {

        Vector3 directionVector = GetDirectionVector(origin.transform.position, target.transform.position);
        Quaternion directionQuaternion = Quaternion.LookRotation(new Vector3(directionVector.x, 0, directionVector.z));
        Quaternion rotationQuaternion = Quaternion.Slerp(origin.transform.rotation, directionQuaternion, Time.deltaTime * rotationSpeed);
        return rotationQuaternion;
    }

    // Takes the Vector from your Input and directionVector relative to the Game World
    public static Vector3 InputRelativeToCamera(Vector3 inputVector) {
            Vector3 cameraForward = Camera.main.transform.forward;
            cameraForward.y = 0f;
        if(cameraForward != Vector3.zero) {
            Quaternion cameraQuaternion = Quaternion.LookRotation(cameraForward);
            inputVector = cameraQuaternion * inputVector;
        }
        return inputVector.normalized;
    }
    #endregion
}
