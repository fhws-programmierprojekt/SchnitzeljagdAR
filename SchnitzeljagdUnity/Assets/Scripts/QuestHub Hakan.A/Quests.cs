using UnityEngine.UI;

[System.Serializable]
public class Quests 
{
    public enum QuestProgress {NOT_AVAILABE, AVAILABLE, DONE}
    public enum ImagetargetProgress {NOT_FOUND, FOUND}
    public enum MinigameProgress {NOT_DONE, DONE}

    public string title;                        //title for the quest
    public int id;                              //ID number for the quest
    public QuestProgress progress;              //state if the current quest (enum)
    public ImagetargetProgress imageProgress;   //state if the corrosponding imagetarget was allready found  
    public MinigameProgress minigameProgress;   //state if the corrosponding minigame is allready done
    public string imageTargerPosition;          //position of the Imagetarger   
    public int nextQuest;                       //ID for the next quest, if there is any
    public int previousQuest;                   //ID for the previous quest, if there is any
    public int pointReward;                     //points given for success
    public int firstDialogID;                   //ID of the first dialog in a scene
    public int dialogAfterQuizID;               //ID of the dialog that playes after the quiz
    public int dialogAfterMinigameID;           //ID of the dialog that playes afte the minigame
    public Button button;                       //corresponding button
}
