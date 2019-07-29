using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizUIManager {

    #region Attributes
    // Question
    private GameObject Question { get; set; }
    private TextMeshProUGUI QuestionInfo { get; set; }
    // Answer
    private Button[] AnswersButton { get; set; }
    private TextMeshProUGUI[] AnswersInfo { get; set; }
    // Resources
    public Sprite ImageSprite { get; private set; } = Resources.Load<Sprite>("Fantasy Wooden GUI  Free/UI board Small  Set");
    public TMP_FontAsset FontAsset { get; private set; } = Resources.Load<TMP_FontAsset>("Fonts & Materials/Rotis-SemiSans-Std-ExtraBold_38715 SDF");
    #endregion

    #region Constructor
    public QuizUIManager() {
        ReferenceElements();
    }
    #endregion

    #region Methods
    private void ReferenceElements() {
        Question = GameObject.Find("Question");
        Question.GetComponent<Image>().sprite = ImageSprite;

        QuestionInfo = GameObject.Find("Question/Info").GetComponent<TextMeshProUGUI>();
        QuestionInfo.font = FontAsset;

        int buttonQuantity = 4;
        AnswersButton = new Button[buttonQuantity];
        for(int i = 0; i < AnswersButton.Length; i++) {
            string path = "Button" + i;
            AnswersButton[i] = GameObject.Find(path).GetComponent<Button>();
            AnswersButton[i].GetComponent<Image>().sprite = ImageSprite;
        }
        
        AnswersInfo = new TextMeshProUGUI[buttonQuantity];
        for(int i = 0; i < AnswersInfo.Length; i++) {
            string path = "Button" + i + "/Info";
            AnswersInfo[i] = GameObject.Find(path).GetComponent<TextMeshProUGUI>();
            AnswersInfo[i].font = FontAsset;
        }
        ButtonOnClick();
    }
    private void ButtonOnClick() {
        foreach(Button button in AnswersButton) {
            button.onClick.AddListener(() => TaskOnClick(button));
        }
    }
    private void TaskOnClick(Button button) {
        int indexOfButton = Array.IndexOf(AnswersButton, button);

        QuizManager gameManager = GameObject.Find("QuizManager").GetComponent<QuizManager>();
        gameManager.CompareIndex(indexOfButton);
    }
    public void UpdateInfo(string questionInfo, string[] answersInfo) {
        QuestionInfo.text = questionInfo;
        for(int i = 0; i < AnswersInfo.Length; i++) {
            AnswersInfo[i].text = answersInfo[i];
        }
    }
    #endregion
}
