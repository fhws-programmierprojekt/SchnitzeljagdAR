using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Quests 
{
    public enum QuestProgress {NOT_AVAILABE, AVAILABLE, DONE}
    public enum ImagetargetProgress {NOT_FOUND, FOUND}

    public string title;                        //title for the quest
    public int id;                              //ID number for the quest
    public QuestProgress progress;              //state if the current quest (enum)
    public ImagetargetProgress imageProgress;   //state if the corrosponding imagetarget was allready found  
    public string imageTargerPosition;          //position of the Imagetarger   
    public int nextQuest;                       //ID for the next quest, if there is any
    public int previousQuest;                   //ID for the previous quest, if there is any
    public int pointReward;                     //points given for success
    public Button button;                       //corresponding button
}
