using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question {

    //attributes
    [SerializeField] private string info;
    [SerializeField] private Answer[] answers;

    //constructors
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

    //methods
    public Answer[] AnswersAreCorrect(bool isCorrect) {
        List<Answer> answersAreCorrect = new List<Answer>();

        foreach(Answer answer in Answers) {
            if(answer.IsCorrect == isCorrect) {
                answersAreCorrect.Add(answer);
            }
        }

        return answersAreCorrect.ToArray();
    }

    //nested class
    [System.Serializable]
    public class Answer {

        //attributes
        [SerializeField] private string info;
        [SerializeField] private bool isCorrect = false;

        //constructors
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
