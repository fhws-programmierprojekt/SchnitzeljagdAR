using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestHubController : MonoBehaviour
{
    public static QuestHubController questHubController;

    public List<Quests> questList = new List<Quests>();         //Quest list with all quests
    public int currentQuest;                                    //Current Quest List

    void Awake()
    {
        //Checks for wrong clones
        if (questHubController == null)
        {
            questHubController = this;
        }
        else if(questHubController != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        //Allowes the first quest at the beginning of the game
        currentQuest = 1;
        questList[0].progress = Quests.QuestProgress.AVAILABLE;
    }

    void Update()
    {
        //Sets the questprogress corresponding to the quest button;
        for (int i = 0; i < questList.Count; i++)
        {
            if(questList[i].progress == Quests.QuestProgress.NOT_AVAILABE)
            {
                questList[i].button.interactable = false;
            }
            else if(questList[i].progress == Quests.QuestProgress.AVAILABLE)
            {
                questList[i].button.interactable = true;
            }
        }
    }

    //QUESTING

    public void AvailbleQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID)
            {
                questList[i].progress = Quests.QuestProgress.AVAILABLE;
            }
        }
    }

    public void CompleteQuest(int questID)
    {
        for(int i = 0; i < questList.Count; i++)
        {
            if(questList[i].id == questID)
            {
                questList[i].progress = Quests.QuestProgress.DONE;
            }
        }
    }

    public void AddPoints(int points)
    {
        int questID = currentQuest;
        for(int i = 0; i < questList.Count; i++)
        {
           if(questList[i].id == questID && questList[i].progress != Quests.QuestProgress.DONE)
            {
                questList[i].pointReward = questList[i].pointReward + points;
            }
        }
    }

    public void ImageTargetFound(int questID)
    {
        for(int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID)
            {
                questList[i].imageProgress = Quests.ImagetargetProgress.FOUND;
            }
        }
    }

    public void MinigameDone(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID)
            {
                questList[i].minigameProgress = Quests.MinigameProgress.DONE;
            }
        }
    }

    public void ResetProgress(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID)
            {
                
                questList[i].minigameProgress = Quests.MinigameProgress.DONE;
                questList[i].imageProgress = Quests.ImagetargetProgress.NOT_FOUND;
            }
        }
    }

    //BOOLS

    public bool RequestAvailbleQuest(int questID)
    {
        for(int i = 0; i < questList.Count; i++)
        {
            if(questList[i].id == questID && questList[i].progress == Quests.QuestProgress.AVAILABLE)
            {
                return true;
            }
        }
        return false;
    }

    public bool RequestQuestDone(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progress == Quests.QuestProgress.DONE)
            {
                return true;
            }
        }
        return false;
    }

    public bool QuestTargetAllreadyFound()
    {
        for(int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == currentQuest && questList[i].imageProgress == Quests.ImagetargetProgress.FOUND)
            {
                return true;
            }
        }
        return false;
    }

    public bool QuestMinigameAllreadyDone()
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == currentQuest && questList[i].minigameProgress == Quests.MinigameProgress.DONE)
            {
                return true;
            }
        }
        return false;
    }

    //INT

    public int QuestPoints(int questID)
    {
        for(int i = 0; i < questList.Count; i++)
        {
            if(questList[i].id == questID)
            {
                return questList[i].pointReward;
            }
        }
        return 0;
    }

    //LOAD

    public void LoadQuest(int questID)
    {
        if (RequestAvailbleQuest(questID) || RequestQuestDone(questID))
        {          
            gameObject.SetActive(false);
            SceneManager.LoadScene(questID);
        }
    }

    public void LoadQuestHub()
    {
        //Completing the last quest
        if(RequestQuestDone(currentQuest) == false)
        { 
            ScoreScript.scoreAmount = ScoreScript.scoreAmount + questHubController.QuestPoints(currentQuest);
            questHubController.CompleteQuest(currentQuest);
            questHubController.ResetProgress(currentQuest);
            if(currentQuest != 12)
            currentQuest++;
        }

        //activating the next Quest
        questHubController.AvailbleQuest(currentQuest);
        gameObject.SetActive(true);

    }
}
