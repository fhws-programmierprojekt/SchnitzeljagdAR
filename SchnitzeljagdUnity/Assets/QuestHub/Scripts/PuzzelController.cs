using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzelController : MonoBehaviour
{
    public static int counter;         //Counter to start end dialog if the player sloves the puzzel
    public GameObject puzzelPlace;     //To turn off the place for better animation
    public GameObject finalTarget;     //Image of the final target
   

    private void Start()
    {
        finalTarget.SetActive(false);
    }

    void Update()
    {
        if(counter == 12 )
        {
            puzzelPlace.SetActive(false);
            DialogSystem.dialogSystem.startDialog(1);
        }
    }
}
