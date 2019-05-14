using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitController : MonoBehaviour
{
    public GameObject Fourthwall;

    void Start()
    {
        Fourthwall.SetActive(false);
    }
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
