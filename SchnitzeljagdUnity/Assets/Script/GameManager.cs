using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;


public class GameManager : MonoBehaviour {

    //attributes
    private UIManager ui;
    [SerializeField] private Quiz quiz;

    //getter and setter
    public Quiz Quiz {
        get { return quiz; }
        set { quiz = value; }
    }

    // Start is called before the first frame update
    void Start() {
        ui = new UIManager();
        quiz = new Quiz();
        quiz.StageCurrent = 0;
        quiz.SetQuestionsOpen(QuestHubController.questHubController.currentQuest - 1);
        Next();
    }

    public void Next() {
        quiz.SetQuestionCurrent();

        string[] answersCurrentInfo = new string[4];
        for(int i = 0; i < quiz.AnswersCurrent.Length; i++) {
            answersCurrentInfo[i] = quiz.AnswersCurrent[i].Info;
        }
        ui.UpdateQuestionInfo(quiz.QuestionCurrent.Info, answersCurrentInfo);
    }

    public void Complete() {

    }



    //public void TestWriteQuiz() {
    //    int indexStages = 12;
    //    int indexQuestions = 4;
    //    Quiz.Stage[] stages = new Quiz.Stage[indexStages];

    //    for(int i = 0; i < stages.Length; i++) {
    //        stages[i] = new Quiz.Stage(new Question[indexQuestions]);

    //        for(int j = 0; j < indexQuestions; j++) {
    //            string index = "[" + i + "." + j + "]";
    //            stages[i].Questions[j] = new Question("Question" + index, new Question.Answer[] {
    //            new Question.Answer("Right", true),
    //            new Question.Answer("Wrong", false),
    //            new Question.Answer("Wrong", false),
    //            new Question.Answer("Wrong", false)
    //            });
    //        }
    //    }

    //    string json = MyJsonUtility.ToJson(stages, true);
    //    File.WriteAllText(quizDataPath.Replace(".json", "") + "Test.json", json);
    //}
}
