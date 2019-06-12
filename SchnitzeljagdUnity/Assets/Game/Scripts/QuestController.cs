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
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int questID = QuestHubController.questHubController.currentQuest;
        int questListLenght = QuestHubController.questHubController.questList.Count;

        //check if it is a quest
        if (currentScene == questID)
        {
            //Quest01
            if (questID == 1)
            {
                DialogSystem.dialogSystem.startDialog(1);
                searchingImageStatus(false);
            }
            //Quest02-12
            else
            {
                for (int i = 2; i < questListLenght; i++)
                {
                    if (questID == i)
                    {
                        if (QuestHubController.questHubController.QuestTargetAllreadyFound() == false)
                        {
                            DialogSystem.dialogSystem.startDialog(QuestHubController.questHubController.questList[i - 1].firstDialogID);
                        }
                        else if (QuestHubController.questHubController.QuestTargetAllreadyFound() && QuestHubController.questHubController.QuestMinigameAllreadyDone() == false)
                        {
                            DialogSystem.dialogSystem.startDialog(QuestHubController.questHubController.questList[i - 1].dialogAfterQuizID);
                            QuestHubController.questHubController.questList[1].imageProgress = Quests.ImagetargetProgress.NOT_FOUND;
                        }
                        else if (QuestHubController.questHubController.QuestTargetAllreadyFound() && QuestHubController.questHubController.QuestMinigameAllreadyDone())
                        {
                            DialogSystem.dialogSystem.startDialog(QuestHubController.questHubController.questList[i - 1].dialogAfterMinigameID);
                            QuestHubController.questHubController.questList[1].imageProgress = Quests.ImagetargetProgress.NOT_FOUND;
                        }
                    }
                }
            }
        }
    }

    //LOAD

    public void loadQuestHub()
    {
        QuestHubController.questHubController.loadQuestHub();
    }

    public void loadQuiz()
    {
        SceneManager.LoadScene(19);
    }

    public void loadChestGame()
    {
        SceneManager.LoadScene(13);
    }

    public void loadMazeRun()
    {
        SceneManager.LoadScene(14);
    }

    public void loadCurrentquest()
    {
        SceneManager.LoadScene(QuestHubController.questHubController.currentQuest);
    }

    public void loadLastFight()
    {
        SceneManager.LoadScene(18);

    }

    public void loadEatingGame()
    {
        SceneManager.LoadScene(15);
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

    public void mimigameDone()
    {
        QuestHubController.questHubController.minigameDone(QuestHubController.questHubController.currentQuest);
    }
  
}
