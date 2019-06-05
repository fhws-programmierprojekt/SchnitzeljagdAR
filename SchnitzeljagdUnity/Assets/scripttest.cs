using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scripttest : MonoBehaviour
{
    public void loadScene()
    {
        QuestHubController.questHubController.loadQuestHub();
    }
}
