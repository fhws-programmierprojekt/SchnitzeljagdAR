using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTimeOnlyEvent : MonoBehaviour
{
    public GameObject items;
    void Start()
    {
        items.SetActive(false);
    }

    
}
