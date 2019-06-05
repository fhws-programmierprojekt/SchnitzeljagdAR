using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager {

    //attributes
    private GameObject question;
    private TextMeshProUGUI questionInfo;

    private GameObject answer;
    private Button[] answersButton;
    private TextMeshProUGUI[] answersInfo;

    //constructor
    public UIManager() {
        ReferenceElements();
    }

    //methods
    public void ReferenceElements() {
        question = GameObject.Find("Question");
        questionInfo = GameObject.Find("UI/Content/Question/Info").GetComponent<TextMeshProUGUI>();

        answer = GameObject.Find("Answer");

        answersButton = new Button[4];
        for(int i = 0; i < answersButton.Length; i++) {
            string path = "Button" + i;
            answersButton[i] = GameObject.Find(path).GetComponent<Button>();
        }

        answersInfo = new TextMeshProUGUI[4];
        for(int i = 0; i < answersInfo.Length; i++) {
            string path = "Button" + i + "/Info";
            answersInfo[i] = GameObject.Find(path).GetComponent<TextMeshProUGUI>();
        }
        ButtonOnClick();
    }
    public void UpdateQuestionInfo(string questionInfo, string[] answersInfo) {
        this.questionInfo.text = questionInfo;
        for(int i = 0; i < this.answersInfo.Length; i++) {
            this.answersInfo[i].text = answersInfo[i];
        }
    }
    public void ButtonOnClick() {
        foreach(Button button in answersButton) {
            button.onClick.AddListener(() => TaskOnClick(button));
        }
    }
    public void TaskOnClick(Button button) {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        int indexOfButton = Array.IndexOf(answersButton, button);
        if(indexOfButton == gameManager.Quiz.IndexOfAnswerCorrect()) {
            gameManager.NewQuestion();
        }
    }
}
