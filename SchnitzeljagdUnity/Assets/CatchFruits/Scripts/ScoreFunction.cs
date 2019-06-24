using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreFunction : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    public int score = 0;
    private PointsGainController points;

    private void Awake()
    {
        points = GameObject.Find("Points").GetComponent<PointsGainController>();
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        scoreText.text = "Punkte 0/250";
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Poisen")
        {
            points.playPointAnimation(-25);
            score = score - 25;
            scoreText.text = "Punkte: " + score.ToString() + "/250";
            Destroy(other.gameObject);
        }
        if(other.tag == "Wine")
        {
            points.playPointAnimation(25);
            score = score + 25;
            scoreText.text = "Punkte: " + score.ToString() + "/250"; 
            Destroy(other.gameObject);
        }
        if (other.tag == "Ham")
        {
            points.playPointAnimation(20);
            score = score + 20;
            scoreText.text = "Punkte: " + score.ToString() + "/250";
            Destroy(other.gameObject);
        }
        if (other.tag == "Chees")
        {
            points.playPointAnimation(15);
            score = score + 15;
            scoreText.text = "Punkte: " + score.ToString() + "/250";
            Destroy(other.gameObject);
        }
        if (other.tag == "Bread")
        {
            points.playPointAnimation(10);
            score = score + 10;
            scoreText.text = "Punkte: " + score.ToString() + "/250";
            Destroy(other.gameObject);
        }
        if (other.tag == "Fish")
        {
            points.playPointAnimation(5);
            score = score + 5;
            scoreText.text = "Punkte: " + score.ToString() + "/250";
            Destroy(other.gameObject);
        }
    }

}
