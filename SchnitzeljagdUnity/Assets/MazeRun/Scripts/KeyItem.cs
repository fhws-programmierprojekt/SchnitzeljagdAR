﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
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