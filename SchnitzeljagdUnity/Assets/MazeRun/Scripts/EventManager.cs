using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    //Game vars 
    public Camera[] cams;                       //array for the cameras in the scene
    public Button camSwitchButton;              //Gameobject for the button to switch between views
    public Joystick joystick;                   //Joystick objects
    public GameObject joystickHandle;           // "
    Image[] joystickImage = new Image[2];       // "     
    public Image keyImage;                      //image for the key in the upper right coner
    public GameObject player;                   //Player gameobjects
    Animator animPlayer;                        // "
    Animator animCamera;                        //Cameraobject

    void Start()
    {

        //Only allowes joystick in thirdperson.
        joystick.enabled = false;
        joystickImage[0] = joystick.GetComponent<Image>();
        joystickImage[1] = joystickHandle.GetComponent<Image>();
        joystickImage[0].enabled = false;
        joystickImage[1].enabled = false;
        
        //Deactivets the key image at the beginn of the game
        keyImage.enabled = false;

        //Starts the game in AR mode.
        cams[0].enabled = true; 
        cams[1].enabled = false;

        //Starts the dialogs
        DialogSystem.dialogSystem.startDialog(1);
        
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
        DialogSystem.dialogSystem.endDialog(1);
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
        //only allows the joystick in the thridperson view
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

    void ExitEvent()
    {

        JoystickSwitch();
        DisableCamButton();

        keyImage.enabled = false;

        animPlayer = player.GetComponent<Animator>();
        animPlayer.Play("ChickenDance");
        animPlayer.SetBool("isChickenDance", true);
        animCamera = cams[1].GetComponent<Animator>();
        animCamera.SetBool("isExit", true);
        GateController.exitCount--;
        StartCoroutine(Wait());
        DialogSystem.dialogSystem.startDialog(2);
        QuestHubController.questHubController.addPoints(100);
    }
  
    //SLEEP

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
    }

}
