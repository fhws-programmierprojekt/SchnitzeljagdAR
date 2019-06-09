using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        DialogSystem.dialogSystem.startDialog(2);
        QuestHubController.questHubController.addPoints(100);
    }
    
}
