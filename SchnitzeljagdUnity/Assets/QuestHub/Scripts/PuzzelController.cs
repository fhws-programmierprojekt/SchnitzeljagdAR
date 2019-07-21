using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class PuzzelController : MonoBehaviour
{
    public static int counter;         //Counter to start end dialog if the player sloves the puzzel
    public GameObject puzzelPlace;     //To turn off the place for better animation
    public GameObject finalTarget;     //Image of the final target

    //Var used for the ChestGame
    PointsGainController points;       
    GameObject chest;               
    Animator anim;                      //Animator of the chest    
    Animator animMap;                   //Animator of the map
    bool trigger = true;                
   

    private void Start()
    {
        //If the ucrrent scene is the ChestGameScene
        if (SceneManager.GetActiveScene().buildIndex == 13)
        {
            points = PointsGainController.FindObjectOfType<PointsGainController>();
            chest = GameObject.Find("Old_chest");
            anim = chest.GetComponent<Animator>();
            animMap = finalTarget.GetComponent<Animator>();
            DialogSystem.dialogSystem.StartDialog(1);
        }
        finalTarget.SetActive(false);
        //Opens help
        DialogSystem.dialogSystem.StartDialog(3);
    }

    void Update()
    {
        //If the current scene is the PuzzelGameScene
        if(SceneManager.GetActiveScene().buildIndex == 17)
        {
            if(counter == 12)
            {
                puzzelPlace.SetActive(false);
                DialogSystem.dialogSystem.StartDialog(1);
            }
        }
        //If the ucrrent scene is the ChestGameScene
        if(SceneManager.GetActiveScene().buildIndex == 13)
        {
            if(counter == 1 && trigger)
            {
                exitEvent();
                trigger = false;
            }
        }
    }

    void exitEvent()
    {
        puzzelPlace.SetActive(false);
        anim.Play("Open");
        StartCoroutine(Example());
        DialogSystem.dialogSystem.StartDialog(2);
    }
    IEnumerator Example()
    {
        yield return new WaitForSeconds(1);
        points.playPointAnimation(100);
        QuestHubController.questHubController.AddPoints(100);
        finalTarget.SetActive(true);
        animMap.Play("KartenAnim");
        DialogSystem.dialogSystem.StartDialog(2);
    }
}
