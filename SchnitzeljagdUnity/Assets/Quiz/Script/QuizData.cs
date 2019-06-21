using System.IO;
using UnityEngine;

[System.Serializable]
public class QuizData {

    //attributes
    public static string Path { get; }  = System.IO.Path.Combine(Application.streamingAssetsPath, "Quiz/QuizData.json");
    [SerializeField] private Stage[] stages;

    //constructors
    public QuizData() {}
    public QuizData(Stage[] stages) {
        Stages = stages;
    }

    //getter and setter
    public Stage[] Stages {
        get { return stages; }
        set { stages = value; }
    }

    //methods
    public static QuizData ReadQuizData(string path) {
        QuizData quiz = new QuizData();
        try {
            string quizDataAsJson = File.ReadAllText(path);
            quiz = JsonUtility.FromJson<QuizData>(quizDataAsJson);
            if(QuizDataChecker(quiz)) {
                Debug.Log("QuizData is Correct");
            } else {
                Debug.Log("QuizData is Incorrect");
            }
        } catch(FileNotFoundException) {
            Debug.Log("QuizData not found at: \n" + path);
        }
        return quiz;
    }
    public static bool QuizDataChecker(QuizData quizData) {
        bool quizDataIsCorrect = true;

        foreach(Stage stage in quizData.Stages) {
            foreach(Question question in stage.Questions) {
                int trueAnswers = question.AnswersAreCorrect(true).Length;
                int falseAnswers = question.AnswersAreCorrect(false).Length;

                if(trueAnswers < 1 || falseAnswers < 3) {
                    quizDataIsCorrect = false;
                }
            }
        }

        return quizDataIsCorrect;
    }

    //public void Reload() {
    //    if(CurrentStage == null || CurrentStage.Length == 0) {
    //        CurrentStage = Stages[0].Questions;
    //    }
    //}

    //nested class
    [System.Serializable]
    public class Stage {

        //attributes
        [SerializeField] private Question[] questions;

        //constructors
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
