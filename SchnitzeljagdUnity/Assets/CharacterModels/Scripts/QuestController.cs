using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestController : MonoBehaviour
{
    public GameObject searchingImage;   //Gameobject for the image target 
    public Canvas canvas;               //Object of the canvas in every scene
    

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
                DialogSystem.dialogSystem.StartDialog(1);
                SearchingImageStatus(false);
            }
            //Quest02-12 for a more detailed explation -> documation 3.3.1 picture 7
            else
            {
                for (int i = 2; i <= questListLenght; i++)
                {
                    if (questID == i)
                    {
                        if (QuestHubController.questHubController.QuestTargetAllreadyFound() == false)
                        {
                            DialogSystem.dialogSystem.StartDialog(QuestHubController.questHubController.questList[i - 1].firstDialogID);
                        }
                        else if (QuestHubController.questHubController.QuestTargetAllreadyFound() && QuestHubController.questHubController.QuestMinigameAllreadyDone() == false)
                        {
                            DialogSystem.dialogSystem.StartDialog(QuestHubController.questHubController.questList[i - 1].dialogAfterQuizID);
                            QuestHubController.questHubController.questList[1].imageProgress = Quests.ImagetargetProgress.NOT_FOUND;
                        }
                        else if (QuestHubController.questHubController.QuestTargetAllreadyFound() && QuestHubController.questHubController.QuestMinigameAllreadyDone())
                        {
                            DialogSystem.dialogSystem.StartDialog(QuestHubController.questHubController.questList[i - 1].dialogAfterMinigameID);
                            QuestHubController.questHubController.questList[1].imageProgress = Quests.ImagetargetProgress.NOT_FOUND;
                        }
                    }
                }
            }
        }
    }

    void Update()
    {
        //The imagetarget helping text will pop up when the canvas in the imagetarget gameobject gets inactiv,
        //and will disapear when the canvas gets activ again. Scene 9 and 10 are speacial scene where we have 2 canvas,
        //so they are not incluaded in this function
        if(canvas.enabled == false && SceneManager.GetActiveScene().buildIndex != 9 && SceneManager.GetActiveScene().buildIndex != 10)
        {
            SearchingImageStatus(true);
        }
        if(canvas.enabled == true && SceneManager.GetActiveScene().buildIndex != 9 && SceneManager.GetActiveScene().buildIndex != 10)
        {
            SearchingImageStatus(false);
        }
    }

    //LOAD
    public void LoadPuzzelGame()
    {
        SceneManager.LoadScene(17);
    }

    public void LoadTraning()
    {
        SceneManager.LoadScene(16);
    }

    public void LoadQuestHub()
    {
        QuestHubController.questHubController.LoadQuestHub();
    }

    public void LoadQuiz()
    {
        SceneManager.LoadScene(19);
    }

    public void LoadChestGame()
    {
        SceneManager.LoadScene(13);
    }

    public void LoadMazeRun()
    {
        SceneManager.LoadScene(14);
    }

    public void LoadCurrentquest()
    {
        SceneManager.LoadScene(QuestHubController.questHubController.currentQuest);
    }

    public void LoadLastFight()
    {
        SceneManager.LoadScene(18);

    }

    public void LoadEatingGame()
    {
        SceneManager.LoadScene(15);
    }

    //ADD

    public void AddPoints(int points)
    {
        QuestHubController.questHubController.AddPoints(points);
    }

    //CHANGE

    public void SearchingImageStatus(bool status)
    {
        searchingImage.SetActive(status);
    }

    public void ImageTargertFound()
    {
        QuestHubController.questHubController.ImageTargetFound(QuestHubController.questHubController.currentQuest);
    }

    public void MinigameDone()
    {
        QuestHubController.questHubController.MinigameDone(QuestHubController.questHubController.currentQuest);
    }
  
}
