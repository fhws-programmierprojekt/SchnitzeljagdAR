using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    #region Attributes

    [SerializeField] private Quiz quiz;
    public Quiz Quiz {
        get { return quiz; }
        set { quiz = value; }
    }

    private UIManager UIManager { get; set; }

    #endregion

    // Start is called before the first frame update
    void Start() {
        UIManager = new UIManager();
        quiz = Quiz.ReadQuizData();
        quiz.SetQuestionsOpen(QuestHubController.questHubController.currentQuest - 1);
        //quiz.SetQuestionsOpen(0);
        Next();
    }



    public void Next() {
        quiz.SetQuestionCurrent();

        string[] answersCurrentInfo = new string[4];
        for(int i = 0; i < quiz.AnswersCurrent.Length; i++) {
            answersCurrentInfo[i] = quiz.AnswersCurrent[i].Info;
        }
        UIManager.UpdateQuestionInfo(quiz.QuestionCurrent.Info, answersCurrentInfo);
    }

    public void CheckButtonToAnswer(int indexOfButton) {
        int indexOfAnswerCorrect = quiz.IndexOfAnswerCorrect();
        if(indexOfButton == indexOfAnswerCorrect) {
            AddPoints();
            if(quiz.QuestionsOpen.Count >= 1) {
                Next();
            } else {
                EndGame();
            }

        } else {
            if(quiz.Attempt >= 4) {
                quiz.Attempt--;
            }
        }
    }
    public void AddPoints() {
        int point = (int) Mathf.Pow(2, quiz.Attempt);
        QuestHubController.questHubController.addPoints(point);
    }

    public void EndGame() {
        SceneManager.LoadScene(QuestHubController.questHubController.currentQuest);
    }
}
