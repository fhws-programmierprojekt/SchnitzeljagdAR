﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Sets the player screen to landscapemode
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        DialogSystem.dialogSystem.startDialog(1);
    }

    
}