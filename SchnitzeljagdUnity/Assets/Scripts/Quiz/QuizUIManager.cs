using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizUIManager {

    //attributes
    private GameObject question;
    private TextMeshProUGUI questionInfo;

    private Button[] answersButton;
    private TextMeshProUGUI[] answersInfo;

    private readonly Sprite imageSprite = Resources.Load<Sprite>("Fantasy Wooden GUI  Free/UI board Small  Set");
    private readonly TMP_FontAsset fontAsset = Resources.Load<TMP_FontAsset>("Fonts & Materials/Rotis-SemiSans-Std-ExtraBold_38715 SDF");

    //constructors
    public QuizUIManager() {
        ReferenceElements();
    }

    //methods
    private void ReferenceElements() {
        question = GameObject.Find("Question");
        question.GetComponent<Image>().sprite = imageSprite;

        questionInfo = GameObject.Find("Question/Info").GetComponent<TextMeshProUGUI>();
        questionInfo.font = fontAsset;

        int buttonQuantity = 4;
        answersButton = new Button[buttonQuantity];
        for(int i = 0; i < answersButton.Length; i++) {
            string path = "Button" + i;
            answersButton[i] = GameObject.Find(path).GetComponent<Button>();
            answersButton[i].GetComponent<Image>().sprite = imageSprite;
        }
        
        answersInfo = new TextMeshProUGUI[buttonQuantity];
        for(int i = 0; i < answersInfo.Length; i++) {
            string path = "Button" + i + "/Info";
            answersInfo[i] = GameObject.Find(path).GetComponent<TextMeshProUGUI>();
            answersInfo[i].font = fontAsset;
        }
        ButtonOnClick();
    }
    public void UpdateInfo(string questionInfo, string[] answersInfo) {
        this.questionInfo.text = questionInfo;
        for(int i = 0; i < this.answersInfo.Length; i++) {
            this.answersInfo[i].text = answersInfo[i];
        }
    }
    private void ButtonOnClick() {
        foreach(Button button in answersButton) {
            button.onClick.AddListener(() => TaskOnClick(button));
        }
    }
    private void TaskOnClick(Button button) {
        int indexOfButton = Array.IndexOf(answersButton, button);

        QuizManager gameManager = GameObject.Find("QuizManager").GetComponent<QuizManager>();
        gameManager.CompareIndex(indexOfButton);
    }
}
