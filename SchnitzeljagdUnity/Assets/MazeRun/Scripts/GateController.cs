using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public static int keyCount = 0;     //Var to check if player has the key
    public static int exitCount = 0;    //Var to check if player has allready enterd the exit event

    //Method to opend the gates and allowing the player to exit

    private void OnTriggerEnter(Collider collider)
    {

        if(collider.gameObject.name == "Lancelot" && keyCount > 0)
        {

            GameObject gateRight = GameObject.Find("GateRight");
            GameObject gateLeft = GameObject.Find("GateLeft");
            Animator animRight = gateRight.GetComponent<Animator>();
            Animator animLeft = gateLeft.GetComponent<Animator>();

            animLeft.SetBool("isOpeningLeft", true);
            animRight.SetBool("isOpeningRight", true);
            keyCount--;
        }
    }
}
