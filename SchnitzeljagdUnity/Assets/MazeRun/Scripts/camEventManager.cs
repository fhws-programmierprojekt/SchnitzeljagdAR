using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camEventManager : MonoBehaviour
{
    public Camera[] cams;

    public Button[] buttons;

    

    
    public void camArMove()
    {
        buttons[0].interactable = false;
        buttons[1].interactable = true;

        cams[0].enabled = true;
        cams[1].enabled = false;
    }
    public void camFpMove()
    {
        buttons[0].interactable = true;
        buttons[1].interactable = false;

        cams[0].enabled = false;
        cams[1].enabled = true;
    }
}
