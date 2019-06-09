using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestHubController : MonoBehaviour
{
    public static QuestHubController questHubController;

    public List<Quests> questList = new List<Quests>();         //Quest list with all quests
    public int currentQuest;                                    //Current Quest List
    public GameObject questHub;                                 //Questhub as a Object to make it invisible if neded
 

    void Awake()
    {
        if(questHubController == null)
        {
            questHubController = this;
        }
        else if(questHubController != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        for(int i = 0; i < questList.Count; i++)
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

    //AVAILBLE QUEST

    public void AvailbleQuest(int questID)
    {
        for(int i = 0; i < questList.Count; i++)
        {
            if(questList[i].id == questID)
            {
                questList[i].progress = Quests.QuestProgress.AVAILABLE;
            }
        }
    }

    //COMPLETE QUEST

    public void CompleteQuest(int questID)
    {
        for(int i = 0; i < questList.Count; i++)
        {
            if(questList[i].id == questID && questList[i].progress == Quests.QuestProgress.DONE)
            {
                questList[i].progress = Quests.QuestProgress.DONE;
            }
        }
    }

    public void addPoints(int points)
    {
        int questID = currentQuest;
        for(int i = 0; i < questList.Count; i++)
        {
           if(questList[i].id == questID)
            {
                questList[i].pointReward = questList[i].pointReward + points;
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

    public bool DoneCompletedQuest(int questID)
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

    public void loadQuest(QuestObject questObject)
    {
        
        if (RequestAvailbleQuest(questObject.ID))
        {
            
            gameObject.SetActive(false);
            SceneManager.LoadScene(questObject.ID);
            currentQuest = questObject.ID;
            
        }
    }

    public void loadQuestHub()
    {
        currentQuest++;
       
        ScoreScript.scoreAmount = ScoreScript.scoreAmount + questHubController.QuestPoints(currentQuest -1);
        questHubController.AvailbleQuest(currentQuest);
        gameObject.SetActive(true);
    }
}
