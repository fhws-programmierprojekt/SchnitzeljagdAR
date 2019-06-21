using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawnScript : MonoBehaviour
{
	[SerializeField]
	private GameObject[] food;

	private BoxCollider col;

	float x1, x2, x3, x4;

	void Awake () {
	
		col = GetComponent<BoxCollider> ();

		x1 = transform.position.x - col.bounds.size.x / 2f;
		x2 = transform.position.x + col.bounds.size.x / 2f;
		x3 = transform.position.z - col.bounds.size.x / 2f;
		x4 = transform.position.z + col.bounds.size.x / 2f;
		


	}

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (SpawnFood(1f));
    }

	IEnumerator SpawnFood(float time) {
		yield return new WaitForSecondsRealtime (time);

		Vector3 temp = transform.position;
		temp.x = Random.Range (x1, x2);
		temp.z = Random.Range (x3, x4);

		Instantiate (food[Random.Range(0, food.Length)], temp, Quaternion.identity);

		StartCoroutine (SpawnFood(Random.Range(1f, 2f)));


	}
}
