using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    //Vars used for the score text in the questhub
    public static int scoreAmount;
    private TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreAmount = 0;
    }

    // Update is called once per frame

    void Update()
    {
        //Sets score corresponding to the amount at the moment
        scoreText.text = "Punkte " + scoreAmount;
    }
}
