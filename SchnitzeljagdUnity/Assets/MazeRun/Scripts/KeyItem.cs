using UnityEngine;

public class KeyItem : MonoBehaviour
{
    //Destroys the key gameobject and lets the door know that the player picked it up
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.name == "Lancelot")
        {
            Debug.Log("Du hast denn Schlüssel!" + collider.gameObject.name);
            GateController.keyCount += 2;
            
            Destroy(gameObject);
        }
    }
}
