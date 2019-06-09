using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialog 
{
    public enum DialogStatus{UNREAD, READING, READ};

    public int dialogID;                //ID of the Dialog
    public GameObject dialogObject;     //The Dialog Object itself
    public DialogStatus dialogStatus;   //Current status of the Dialog
    public string dialogText;           //The text in the dialog
    public Image character;             //Person who is speaking
    public Image speachBubble;          //Speachbubble for the text
    public GameObject button;           //button to play the next action

}
