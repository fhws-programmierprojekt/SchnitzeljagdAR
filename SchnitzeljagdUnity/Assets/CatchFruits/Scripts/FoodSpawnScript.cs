using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawnScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] food;
    float x1, x2, z1, z2;
    private BoxCollider spawner;

    //Start is called before the first frame update
    void Awake()
    {
        //Sets gravity 
        Physics.gravity = new Vector3(0, -1.0F, 0);

        spawner = GetComponent<BoxCollider>();
        
        //Gets the coordinants of the spawning place
        x1 = transform.position.x - spawner.bounds.size.x / 2f;
        x2 = transform.position.x + spawner.bounds.size.x / 2f;
        z1 = transform.position.z - spawner.bounds.size.z / 2f;
        z2 = transform.position.z + spawner.bounds.size.z / 2f;
    }

    public void StartFoodSpwaning()
    {
        StartCoroutine(SpwanFood(3f));
    }

    IEnumerator SpwanFood(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        
        Vector3 temp = transform.position;
        temp.x = Random.Range(x1, x2);
        temp.z = Random.Range(z1, z2);

        Instantiate(food[Random.Range(0, food.Length)], temp, Quaternion.identity);

        StartCoroutine(SpwanFood(5F));
    }
}