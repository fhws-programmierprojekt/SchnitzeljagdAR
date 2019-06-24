using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreFunction : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int score = 0;
    private PointsGainController points;

    private void Awake()
    {
        points = GameObject.Find("Points").GetComponent<PointsGainController>();
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        scoreText.text = "0";
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Poisen")
        {
            Destroy(other.gameObject);
        }
        if(other.tag == "Food")
        {
            points.playPointAnimation(25);
            score = score + 25;
            scoreText.text = score.ToString(); 
            Destroy(other.gameObject);
        }
    }

}
