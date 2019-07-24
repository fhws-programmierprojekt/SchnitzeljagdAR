using UnityEngine;

public class ExitController : MonoBehaviour
{
    //Invisble wall so player can move into the exit floor but cant get in again 
    public GameObject Fourthwall;

    void Start()
    {
        //The collider gets disabled so the player can move into the exit floor
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
