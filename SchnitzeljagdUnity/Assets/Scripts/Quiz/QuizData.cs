using System.IO;
using UnityEngine;

[System.Serializable]
public class QuizData {

    #region QuizData
    // Attributes
    public static string Path { get; } = System.IO.Path.Combine(Application.streamingAssetsPath, "Quiz/QuizData.json");
    [SerializeField] private Stage[] stages;

    // Constructors
    public QuizData() {}
    public QuizData(Stage[] stages) {
        Stages = stages;
    }

    // Getter and Setter
    public Stage[] Stages {
        get { return stages; }
        set { stages = value; }
    }

    // Methods
    public static QuizData ReadQuizData(string path) {
        QuizData quiz = new QuizData();
        try {
            string quizDataAsJson = string.Empty;
            if(Application.platform == RuntimePlatform.WindowsEditor) {
                quizDataAsJson = File.ReadAllText(path);
            }
            if(Application.platform == RuntimePlatform.Android) {
                #pragma warning disable 0618
                WWW reader = new WWW(path);
                while(!reader.isDone) { }

                quizDataAsJson = reader.text;
                #pragma warning restore 0618
            }
            if(Application.platform == RuntimePlatform.IPhonePlayer) {
                quizDataAsJson = File.ReadAllText(path);
            }
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
    #endregion

    #region Stage
    [System.Serializable]
    public class Stage {

        // Attributes
        [SerializeField] private Question[] questions;

        // Constructors
        public Stage(Question[] questions) {
            Questions = questions;
        }

        // Getter and Setter
        public Question[] Questions {
            get { return questions; }
            set { questions = value; }
        }
    }
    #endregion
}
