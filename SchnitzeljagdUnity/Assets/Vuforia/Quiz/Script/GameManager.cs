using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //attributes
    private UIManager ui;

    [SerializeField] private Question[] questions;  // Questions of a task
    private List<Question> questionsOpen;           // Questions yet to be answered
    private Question questionCurrent;               // Question currently to be answered
    private readonly int answerQuantity = 4;
    private int score;

    //getter and setter
    public Question[] Questions {
        get { return questions; }
        set { questions = value; }
    }
    public Question QuestionCurrent {
        get { return questionCurrent; }
        set { questionCurrent = value; }
    }

    // Start is called before the first frame update
    void Start() {
        ui = new UIManager();
        ui.ReferenceElements();

        if(questionsOpen == null || questionsOpen.Count == 0) {
            questionsOpen = questions.ToList<Question>();
        }
        SetCurrentQuestion();
    }

    // Sets a random current Question and deletes it from open Questions
    public void SetCurrentQuestion() {
        int index = Random.Range(0, questionsOpen.Count);
        questionCurrent = questionsOpen[index];
        questionCurrent.SetAnswersCurrent();
        SetUIInfo();
        //questionsOpen.RemoveAt(index);
    }
    private void SetUIInfo() {
        string[] answersCurrentInfo = new string[answerQuantity];
        for(int i = 0; i < questionCurrent.AnswersCurrent.Length; i++) {
            answersCurrentInfo[i] = questionCurrent.AnswersCurrent[i].Info;
        }
        ui.UpdateQuestionInfo(questionCurrent.Info, answersCurrentInfo);
    }
}