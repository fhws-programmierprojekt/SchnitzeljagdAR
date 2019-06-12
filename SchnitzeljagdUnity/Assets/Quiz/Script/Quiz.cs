using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Quiz {

    #region Attributes

    public static string quizDataPath { get; }  = Path.Combine(Application.streamingAssetsPath, "Quiz/QuizData.json");

    [SerializeField] private Stage[] stages;
    public Stage[] Stages {
        get { return stages; }
        set { stages = value; }
    }

    //AutoImplementedProperties
    public List<Question> QuestionsOpen { get; set; }
    public Question QuestionCurrent { get; set; }
    public Question.Answer[] AnswersCurrent { get; set; }
    public int StageCurrent { get; set; }
    public int Attempt { get; set; }

    #endregion

    #region constructors
    public Quiz() {
        //ReadQuiz();
    }
    public Quiz(int stageCurrent) {
        //ReadQuiz();
        StageCurrent = stageCurrent;
    }
    #endregion

    #region Methods

    public static Quiz ReadQuizData() {
        Quiz quiz = new Quiz();
        try {
            string quizDataAsJson = File.ReadAllText(quizDataPath);
            quiz = JsonUtility.FromJson<Quiz>(quizDataAsJson);
        } catch(FileNotFoundException) {
            Debug.Log("Error: QuizData not found at: \n" + quizDataPath);
        }
        return quiz;
    }


    //public void SetQuestionsOpen() {
    //    if(QuestionsOpen == null || QuestionsOpen.Count == 0) {
    //        QuestionsOpen = Stages[stageCurrent].Questions.ToList<Question>();
    //    }
    //}
    public void SetQuestionsOpen(int stageCurrent) {
        QuestionsOpen = Stages[stageCurrent].Questions.ToList<Question>();
    }
    public void SetQuestionCurrent() {
        int index = Random.Range(0, QuestionsOpen.Count);
        QuestionCurrent = QuestionsOpen[index];
        SetAnswersCurrent();
        Attempt = 4;
        QuestionsOpen.RemoveAt(index);
        //SetQuestionsOpen();
    }
    public void SetAnswersCurrent() {
        AnswersCurrent = new Question.Answer[4];
        List<Question.Answer> answersTrue = AnswersAreCorrect(true);
        List<Question.Answer> answersFalse = AnswersAreCorrect(false);

        AnswersCurrent[0] = RandomElement(answersTrue);
        for(int i = 1; i < AnswersCurrent.Length;) {
            Question.Answer answerRandom = RandomElement(answersFalse);
            if(!AnswersCurrent.Contains(answerRandom)) {
                AnswersCurrent[i] = answerRandom;
                i++;
            }
        }
        AnswersCurrent = ShuffleArray(AnswersCurrent);
    }
    private List<Question.Answer> AnswersAreCorrect(bool isCorrect) {
        List<Question.Answer> answersAreCorrect = new List<Question.Answer>();
        for(int i = 0; i < QuestionCurrent.Answers.Length; i++) {
            if(QuestionCurrent.Answers[i].IsCorrect == isCorrect) {
                answersAreCorrect.Add(QuestionCurrent.Answers[i]);
            }
        }
        return answersAreCorrect;
    }
    private T RandomElement<T>(List<T> list) {
        return list.ElementAt(Random.Range(0, list.Count));
    }
    private static T[] ShuffleArray<T>(T[] array) {
        System.Random random = new System.Random();
        for(int i = array.Length; i > 0; i--) {
            int j = random.Next(i);
            T element = array[j];
            array[j] = array[i - 1];
            array[i - 1] = element;
        }
        return array;
    }
    public int IndexOfAnswerCorrect() {
        Question.Answer answerCorrect = null;
        foreach(Question.Answer answer in AnswersCurrent) {
            if(answer.IsCorrect) {
                answerCorrect = answer;
            }
        }
        int indexOfAnswerCorrect = System.Array.IndexOf(AnswersCurrent, answerCorrect);
        return indexOfAnswerCorrect;
    }
    #endregion

    //nested class
    [System.Serializable]
    public class Stage {

        //attributes
        [SerializeField] private Question[] questions;

        //constructor
        public Stage(Question[] questions) {
            Questions = questions;
        }

        //getter and setter
        public Question[] Questions {
            get { return questions; }
            set { questions = value; }
        }
    }
}
