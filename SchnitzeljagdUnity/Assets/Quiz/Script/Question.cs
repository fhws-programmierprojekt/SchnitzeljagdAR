using UnityEngine;

[System.Serializable]
public class Question {

    //attributes
    [SerializeField] private string info;
    [SerializeField] private Answer[] answers;

    //constructor
    public Question(string info, Answer[] answers) {
        Info = info;
        Answers = answers;
    }
    //getter and setter
    public string Info {
        get { return info; }
        set { info = value; }
    }
    public Answer[] Answers {
        get { return answers; }
        set { answers = value; }
    }

    //nested class
    [System.Serializable]
    public class Answer {
        //attributes
        [SerializeField] private string info;
        [SerializeField] private bool isCorrect = false;

        //constructor
        public Answer(string info, bool isCorrect) {
            Info = info;
            IsCorrect = isCorrect;
        }
        //getter and setter
        public string Info {
            get { return info; }
            set { info = value; }
        }
        public bool IsCorrect {
            get { return isCorrect; }
            set { isCorrect = value; }
        }
    }
}
