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
    public void playPointAnimation()
    {
        scoreText.text = "+ " + QuestHubController.questHubController.QuestPoints(QuestHubController.questHubController.currentQuest) + " Punkte";
        Animator anim = gameObject.GetComponent<Animator>();
        anim.Play("PointsGainAnimation");
   
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }
}
