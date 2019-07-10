using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


public class QuizManager : MonoBehaviour {

    #region Attributes

    [SerializeField] private QuizData quiz;

    // Auto-Properties
    public Question[] CurrentStage { get; set; }
    public Question CurrentQuestion { get; set; }
    public Question.Answer[] CurrentAnswers { get; set; }
    public int Attempts { get; set; }

    private QuizUIManager QuizUIManager { get; set; }

    #endregion

    #region Getter and Setter
    public QuizData Quiz {
        get { return quiz; }
        set { quiz = value; }
    }
    #endregion

    #region UnityMethods
    // Start is called before the first frame update
    void Start() {
        QuizUIManager = new QuizUIManager();
        quiz = QuizData.ReadQuizData(QuizData.Path);

        if(QuestHubController.questHubController != null) {
            SetCurrentStage(QuestHubController.questHubController.currentQuest - 1);
        }
        else {
            SetCurrentStage(0);
        }
        RandomQuestion();
    }
    #endregion UnityMethods

    #region PreUserInput
    public void RandomQuestion() {
        int index = Random.Range(0, CurrentStage.Length);
        SetCurrentQuestion(index);
    }
    private void SetCurrentStage(int index) {
        CurrentStage = Quiz.Stages[index].Questions;
    }
    private void SetCurrentQuestion(int index) {
        CurrentQuestion = CurrentStage[index];
        SetCurrentAnswers();
        DisplayCurrentInfo();
        Attempts = 4;
        CurrentStage = CurrentStage.RemoveAt(index);
    }
    private void SetCurrentAnswers() {
        CurrentAnswers = new Question.Answer[4];
        Question.Answer[] answersTrue = CurrentQuestion.AnswersAreCorrect(true);
        Question.Answer[] answersFalse = CurrentQuestion.AnswersAreCorrect(false);

        CurrentAnswers[0] = answersTrue.RandomElement();
        for(int i = 1; i < CurrentAnswers.Length;) {
            Question.Answer answerRandom = answersFalse.RandomElement();
            if(!CurrentAnswers.Contains(answerRandom)) {
                CurrentAnswers[i] = answerRandom;
                i++;
            }
        }
        CurrentAnswers = CurrentAnswers.Shuffle();
    }
    private void DisplayCurrentInfo() {
        string[] currentAnswersInfo = new string[CurrentAnswers.Length];
        for(int i = 0; i < CurrentAnswers.Length; i++) {
            currentAnswersInfo[i] = CurrentAnswers[i].Info;
        }
        QuizUIManager.UpdateInfo(CurrentQuestion.Info, currentAnswersInfo);
    }
    #endregion

    #region PostUserInput
    public void CompareIndex(int indexOfButton) {
        int indexOfCorrectAnswer = IndexOfCorrectAnswer();
        if(indexOfButton == indexOfCorrectAnswer) {
            AddPoints();
            if(CurrentStage.Length > 0) {
                RandomQuestion();
            } else {
                EndGame();
            }
        } else {
            if(Attempts > 1) {
                Attempts--;
            }
        }
    }
    private int IndexOfCorrectAnswer() {
        Question.Answer correctAnswer = null;
        foreach(Question.Answer answer in CurrentAnswers) {
            if(answer.IsCorrect) {
                correctAnswer = answer;
            }
        }
        int indexOfCorrectAnswer = System.Array.IndexOf(CurrentAnswers, correctAnswer);
        return indexOfCorrectAnswer;
    }
    public void AddPoints() {
        int points = Attempts * 5;
        if(QuestHubController.questHubController != null) {
            QuestHubController.questHubController.addPoints(points);
        }
        PointsGainController pointController = GameObject.Find("PointController").GetComponent<PointsGainController>();
        pointController.playPointAnimation(points);
    }
    public void EndGame() {
        if(QuestHubController.questHubController != null) {
            SceneManager.LoadScene(QuestHubController.questHubController.currentQuest);
        }
        else {
            CurrentStage = Quiz.Stages[1].Questions;
            RandomQuestion();
        }
    }
    #endregion
}
