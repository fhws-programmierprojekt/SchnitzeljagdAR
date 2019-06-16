using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFunction : MonoBehaviour
{
	
	// Eine Nummer zwischen 1 und 16 generieren, damit ein zufälliges Feld verschwindet
	/*
	int rnd = Random.Range(0,15);
	*/


	/*
	public int RandomNumber()  
{  
	int min = 0;
	int max = 15;
    Random random = new Random();  
    return random.Next(min, max);  
}  */
	

    //Array Initilizierung
	public GameObject[] felder;


	

	//Funktion das Feld verschwinden zu lassen
	public void hideField() {

		felder[6].SetActive(false);
	/*
		if (felder[x] = true) {
		felder[x].SetActive(false);
		} else {
			felder[x].SetActive(true);
		}
	*/
	}



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    /*
	int rnd = Random.Range(0,15);
	
	Wait(2);

	felder[rnd].SetActive(false);

	Wait(2);
	
	felder[rnd].SetActive(true);

	Wait(8);

	*/
    }

	IEnumerator Wait(int seconds){
		yield return new WaitForSeconds(seconds);
	}
}
