using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest1Controller : MonoBehaviour
{
   

    // Start is called before the first frame update
    void Start()
    {
        DialogSystem.dialogSystem.startDialog(1);
        
    }
    
    public void loadQuestHub()
    {
        QuestHubController.questHubController.loadQuestHub();
    }

}
