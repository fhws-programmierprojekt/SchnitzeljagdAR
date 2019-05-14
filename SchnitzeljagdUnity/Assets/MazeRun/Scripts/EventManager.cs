using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public Camera[] cams;
    public Button camSwitchButton;
    public Joystick joystick;
    public GameObject joystickHandle;
    Image[] joystickImage = new Image[2];
    public Image keyImage;
    public GameObject player;
    Animator animPlayer;
    Animator animCamera;
    public GameObject lancelotSprite;
    public TextMeshProUGUI speach1;
    public TextMeshProUGUI speach2;

    void Start()
    {
        //Sets the player screen to landscapemode
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        speach2.enabled = false;

        //Only allowes joystick in thirdperson.
        joystick.enabled = false;
        joystickImage[0] = joystick.GetComponent<Image>();
        joystickImage[1] = joystickHandle.GetComponent<Image>();
        joystickImage[0].enabled = false;
        joystickImage[1].enabled = false;
        
        keyImage.enabled = false;

        //Starts the game in AR mode.
        cams[0].enabled = true; 
        cams[1].enabled = false;

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

    public void GameStart()
    {
        lancelotSprite.SetActive(false);
        speach1.enabled = false;
        
    }

    public void CamSwitch()
    {
        //Only allowes joystick in thirdperson.
        JoystickSwitch();

        //Switch from AR camera to thirdperson and back.
        cams[0].enabled = ! cams[0].enabled;   
        cams[1].enabled = ! cams[1].enabled;
    }

    void JoystickSwitch()
    {
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

    }

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
        lancelotSprite.SetActive(true);
        speach2.enabled = true;
        
    }
    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
    }

}
