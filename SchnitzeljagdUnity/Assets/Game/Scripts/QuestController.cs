using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestController : MonoBehaviour
{
    public GameObject searchingImage;   //Gameobject for the starting text

    //Starting events for each quest
    void Start()
    {
        int questID = QuestHubController.questHubController.currentQuest;

        //Quest01
        if(questID == 1)
        {
            DialogSystem.dialogSystem.startDialog(1);
            searchingImageStatus(false);
        }
        //Quest02
        else if(questID == 2 && QuestHubController.questHubController.QuestTargetAllreadyFound() == false)
        {
            DialogSystem.dialogSystem.startDialog(1);
        }
        else if(questID == 2 && QuestHubController.questHubController.QuestTargetAllreadyFound())
        {
            DialogSystem.dialogSystem.startDialog(4);
        }
    }
    
    //LOAD

    public void loadQuestHub()
    {
        QuestHubController.questHubController.loadQuestHub();
    }

    public void loadQuiz()
    {
        SceneManager.LoadScene(4);
    }

    //ADD

    public void addPoints(int points)
    {
        QuestHubController.questHubController.addPoints(points);
    }

    //CHANGE

    public void searchingImageStatus(bool status)
    {
        searchingImage.SetActive(status);
    }

    public void imageTargertFound()
    {
        QuestHubController.questHubController.imageTargetFound(QuestHubController.questHubController.currentQuest);
    }
  
}
