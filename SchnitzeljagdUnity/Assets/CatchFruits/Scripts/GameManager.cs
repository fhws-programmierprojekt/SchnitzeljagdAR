using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool trigger = false;           //Used for trigger the end sequenz once
    int score;                      
    public GameObject scoreObject;
    ScoreFunction scoreFunction;

    // Start is called before the first frame update
    void Start()
    {
        //Sets the player screen to landscapemode
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        DialogSystem.dialogSystem.startDialog(1);
        scoreFunction = scoreObject.GetComponent<ScoreFunction>();

    }
    void Update()
    {
        score = scoreFunction.score;
        if (score >= 250 && trigger == false)
        {
            trigger = true;
            DialogSystem.dialogSystem.startDialog(2);
        }
    }


}
