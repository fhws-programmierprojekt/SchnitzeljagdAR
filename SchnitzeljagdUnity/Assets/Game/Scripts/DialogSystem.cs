﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogSystem : MonoBehaviour
{
    public static DialogSystem dialogSystem;
    
    public Dialog[] dialogs;        //number of dialogs in a scene;

    void Awake()
    {
        //Checks for wrong clones
        if(dialogSystem == null)
        {
            dialogSystem = this;
        }
        else if (dialogSystem != this)
        {
            Destroy(gameObject);
        }
        //Sets every dialog and the beginn of the scene to false
        for(int i = 0; i < dialogs.Length; i++)
        {
            dialogs[i].dialogObject.SetActive(false);
        }
       
    }
    

    //START DIALOG

    public void startDialog(int dialogID)
    {
        for(int i = 0; i < dialogs.Length; i++)
        {
            if(dialogs[i].dialogID == dialogID && dialogs[i].dialogStatus == Dialog.DialogStatus.UNREAD)
            {
                dialogs[i].dialogObject.SetActive(true);
                dialogs[i].dialogStatus = Dialog.DialogStatus.READING;
                dialogs[i].speachBubble.GetComponentInChildren<TextMeshProUGUI>().text = dialogs[i].dialogText;

            }
        }
    }
    
    //END DIALOG
    
    public void endDialog(int dialogID)
    {
        for (int i = 0; i < dialogs.Length; i++)
        {
            if (dialogs[i].dialogID == dialogID && dialogs[i].dialogStatus == Dialog.DialogStatus.READING)
            {
                dialogs[i].dialogStatus = Dialog.DialogStatus.READ;
                dialogs[i].dialogObject.SetActive(false);
            }
        }
    }
}
