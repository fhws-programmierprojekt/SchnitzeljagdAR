using UnityEngine;

public class RandomKeySpawner : MonoBehaviour
{
    public GameObject[]keySpawner;      //Array with every key object in the game
    

    // Start is called before the first frame update
    void Start()
    {
        SpawnRandomKey(Random.Range(0, 3));
    }

    //Method to randomly select which key is activ 

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
