using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LabyrinthController : MonoBehaviour
{
    //Game variables
    public Camera[] cams;                       //Array for the cameras in the scene
    public Button camSwitchButton;              //Gameobject for the button to switch between views
    public Joystick joystick;                   //Joystick objects
    public GameObject joystickHandle;           // "
    Image[] joystickImage = new Image[2];       // "     
    public Image keyImage;                      //Image object for the key in the upper right coner
    public GameObject player;                   //Player gameobjects
    Animator animPlayer;                        // "
    Animator animCamera;                        //Cameraobject

    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        //Starts the game in AR mode.
        cams[0].enabled = true;
        cams[1].enabled = false;

        //Only allowes joystick in thirdperson.
        joystick.enabled = false;
        joystickImage[0] = joystick.GetComponent<Image>();
        joystickImage[1] = joystickHandle.GetComponent<Image>();
        joystickImage[0].enabled = false;
        joystickImage[1].enabled = false;
        
        //Deactivets the key image at the beginn of the game
        keyImage.enabled = false;

        //Starts the dialogs
        DialogSystem.dialogSystem.StartDialog(1);
        
    }

    void Update()
    {
        //Detects if player picked up the key.
        if (GateController.keyCount > 0)
        {
            keyImage.enabled = true;
        }
        //Detects if player hit the exit and plays endsequenz.
        if (GateController.exitCount > 0)
        {
            ExitEvent();
        } 
    }

    //ON CLICK EVENTS

    void GameStart()
    {
        //ends the first dialog
        DialogSystem.dialogSystem.EndDialog(1);
    }

    public void CamSwitch()
    {
        //Only allowes joystick in thirdperson.
        JoystickSwitch();

        //Switch from AR camera to thirdperson and back.
        cams[0].enabled = ! cams[0].enabled;   
        cams[1].enabled = ! cams[1].enabled;
    }

    //FUNCTIONS

    void JoystickSwitch()
    {
        //Switches the Joystick for activ to incactive when changeing the view of the player 
        joystick.enabled = !joystick.enabled; 
        joystickImage[0].enabled = !joystickImage[0].enabled;
        joystickImage[1].enabled = !joystickImage[1].enabled;
    }

    void DisableCamButton()
    {
        //Disables camswitchbutton and makes it invisible.
        Image camSwitchButtonImage = camSwitchButton.GetComponent<Image>();
        camSwitchButton.interactable = false;
        camSwitchButtonImage.enabled = false;
        TextMeshProUGUI camSwitchButtonText = camSwitchButton.GetComponentInChildren<TextMeshProUGUI>();
        

    }

    //EXIT EVENT
    public void SetScreen()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    void ExitEvent()
    {
        JoystickSwitch();                               //Diable the joystick so player cant move in ending scene 
        DisableCamButton();                             //Diable the camswitchbutton when ending scene is playing so player cant switch view 

        keyImage.enabled = false;

        animPlayer = player.GetComponent<Animator>();   //Plays the right animation for our character
        animPlayer.Play("ChickenDance");                // "
        animPlayer.SetBool("isChickenDance", true);     // " 
        animCamera = cams[1].GetComponent<Animator>();  //Moves the camerea at the ending scene around the character
        animCamera.SetBool("isExit", true);             // "
        GateController.exitCount--;                     //Removes trigger so exit event only play once
        StartCoroutine(Wait());                         //Starts dialog after 3 secondes so player can see the character dancing
        DialogSystem.dialogSystem.StartDialog(2);       
        QuestHubController.questHubController.AddPoints(100);
    }
  
    //SLEEP

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
    }

}
