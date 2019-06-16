using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsGainController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = "+ " + QuestHubController.questHubController.QuestPoints(QuestHubController.questHubController.currentQuest ) +" Punkte";
    }
    public void playPointAnimation(int points)
    {
        scoreText.text = "+ " + points + " Punkte";
        Animator anim = gameObject.GetComponent<Animator>();
        anim.Play("PointsGainAnimation");
   
    }
}
