using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Poisen" || other.tag == "Wine" || other.tag == "Ham" || other.tag == "Chees" || other.tag == "Bread" || other.tag == "Fish")
        {
            Destroy(other.gameObject);
        }
    }
}
