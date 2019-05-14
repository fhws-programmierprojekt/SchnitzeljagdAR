using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomKeySpawner : MonoBehaviour
{
    public GameObject[]keySpawner;
    

    // Start is called before the first frame update
    void Start()
    {
        SpawnRandomKey(Random.Range(0, 3));
    }

    void SpawnRandomKey(int index)
    {
        for(int i = 0; i < keySpawner.Length; i++)
        {
            if(index != i)
            {
                Destroy(keySpawner[i]);
            }
        }
    }
}
