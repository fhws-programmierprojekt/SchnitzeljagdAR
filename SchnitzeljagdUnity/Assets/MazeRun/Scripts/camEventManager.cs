using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class camEventManager : MonoBehaviour
{
    public Camera[] cams;

    public Button[] buttons;

    public Joystick joystick;

    public TextMeshProUGUI infotext;

    void Start()
    {
        buttons[0].interactable = false;
        joystick.enabled = false;
        infotext.enabled = true;
    }


    public void camArMove()
    {
        //In augmented reality

        infotext.enabled = false;
        joystick.enabled = false;

        buttons[0].interactable = false;
        buttons[1].interactable = true;

        cams[0].enabled = true;
        cams[1].enabled = false;
    }
    public void camFpMove()
    {
        //In thirdperson 

        infotext.enabled = false;
        joystick.enabled = true;

        buttons[0].interactable = true;
        buttons[1].interactable = false;
        buttons[1].interactable = false;

        cams[0].enabled = false;
        cams[1].enabled = true;
    }
}
