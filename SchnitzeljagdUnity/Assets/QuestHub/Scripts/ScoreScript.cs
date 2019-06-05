using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public ScoreScript scoreSetter;

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
        scoreText.text = "Punkte " + scoreAmount;
    }
}
