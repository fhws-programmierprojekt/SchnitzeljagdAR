using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitController : MonoBehaviour
{
    //class used only for playing the exit event
    public GameObject Fourthwall;

    void Start()
    {
        Fourthwall.SetActive(false);
    }

    //Method to start the exit event if player has made it in to the exit room
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Lancelot")
        {
            Debug.Log("Du hast es aus dem Labyrinth geschafft!");
            GateController.exitCount++;

            Fourthwall.SetActive(true);

            Destroy(gameObject);
        }
    }
}
