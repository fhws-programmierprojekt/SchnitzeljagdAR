﻿using System;
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

    private readonly string fontAssetPath = "Fonts & Materials/Rotis-SemiSans-Std-ExtraBold_38715 SDF";
    private readonly TMP_FontAsset fontAsset = Resources.Load("Fonts & Materials/Rotis-SemiSans-Std-ExtraBold_38715 SDF", typeof(TMP_FontAsset)) as TMP_FontAsset;


    //constructor
    public UIManager() {
        ReferenceElements();
    }

    //methods
    public void ReferenceElements() {
        question = GameObject.Find("Question");
        questionInfo = GameObject.Find("UI/Content/Question/Info").GetComponent<TextMeshProUGUI>();
        questionInfo.font = fontAsset;

        answer = GameObject.Find("Answer");

        int buttonQuantity = 4;
        answersButton = new Button[buttonQuantity];
        for(int i = 0; i < answersButton.Length; i++) {
            string path = "Button" + i;
            answersButton[i] = GameObject.Find(path).GetComponent<Button>();
        }
        
        answersInfo = new TextMeshProUGUI[buttonQuantity];
        for(int i = 0; i < answersInfo.Length; i++) {
            string path = "Button" + i + "/Info";
            answersInfo[i] = GameObject.Find(path).GetComponent<TextMeshProUGUI>();
            questionInfo.font = fontAsset;
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
            gameManager.Next();
        }
    }
    private class MyTextMeshProGUI : TextMeshProUGUI{

        public MyTextMeshProGUI(string fontAsset) {
            this.font = Resources.Load(fontAsset, typeof(TMP_FontAsset)) as TMP_FontAsset;
            this.fontSize = 12;
        }
    }
}