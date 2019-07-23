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

        DialogSystem.dialogSystem.StartDialog(1);
        scoreFunction = scoreObject.GetComponent<ScoreFunction>();

    }
    void Update()
    {
        score = scoreFunction.score;
        if (score >= 150 && trigger == false)
        {
            trigger = true;
            DialogSystem.dialogSystem.StartDialog(2);
        }
    }


}
