using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question {

    #region Question
    // Attributes
    [SerializeField] private string info;
    [SerializeField] private Answer[] answers;

    // Constructor
    public Question(string info, Answer[] answers) {
        Info = info;
        Answers = answers;
    }

    // Getter and Setter
    public string Info {
        get { return info; }
        set { info = value; }
    }
    public Answer[] Answers {
        get { return answers; }
        set { answers = value; }
    }

    // Methods
    public Answer[] AnswersAreCorrect(bool isCorrect) {
        List<Answer> answersAreCorrect = new List<Answer>();

        foreach(Answer answer in Answers) {
            if(answer.IsCorrect == isCorrect) {
                answersAreCorrect.Add(answer);
            }
        }

        return answersAreCorrect.ToArray();
    }
    #endregion

    #region Answer
    [System.Serializable]
    public class Answer {

        // Attributes
        [SerializeField] private string info;
        [SerializeField] private bool isCorrect = false;

        // Constructor
        public Answer(string info, bool isCorrect) {
            Info = info;
            IsCorrect = isCorrect;
        }
        // Getter and Setter
        public string Info {
            get { return info; }
            set { info = value; }
        }
        public bool IsCorrect {
            get { return isCorrect; }
            set { isCorrect = value; }
        }
    }
    #endregion
}
