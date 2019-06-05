using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Question {

    //attributes
    [SerializeField] private string info;
    [SerializeField] private Answer[] answers;
    private Answer[] answersCurrent;

    //getter and setter
    public string Info {
        get { return info; }
        set { info = value; }
    }
    public Answer[] Answers {
        get { return answers; }
        set { answers = value; }
    }
    public Answer[] AnswersCurrent {
        get { return answersCurrent; }
        set { answersCurrent = value; }
    }


    //methods
    public void SetAnswersCurrent() {
        answersCurrent = new Answer[4];
        List<Answer> answersTrue = AnswersAreCorrect(true);
        List<Answer> answersFalse = AnswersAreCorrect(false);

        answersCurrent[0] = AnswerRandom(answersTrue);
        for(int i = 1; i < answersCurrent.Length; ) {
            Answer answerRandom = AnswerRandom(answersFalse);
            if(!answersCurrent.Contains(answerRandom)) {
                answersCurrent[i] = answerRandom;
                i++;
            }
        }
        answersCurrent = ShuffleArray(answersCurrent);
    }

    private List<Answer> AnswersAreCorrect(bool isCorrect) {
        List<Answer> answersAreCorrect = new List<Answer>();
        for(int i = 0; i < answers.Length; i++) {
            if(answers[i].IsCorrect == isCorrect) {
                answersAreCorrect.Add(answers[i]);
            }
        }
        return answersAreCorrect;
    }
    private Answer AnswerRandom(List<Answer> answerRandom) {
        return answerRandom.ElementAt(Random.Range(0, answerRandom.Count));
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
    public Answer AnswerCorrect() {
        Answer answerCorrect = null;
        foreach(Answer answer in answersCurrent) {
            if(answer.IsCorrect) {
                answerCorrect = answer;
            }
        }
        return answerCorrect;
    }

    //nested objects
    [System.Serializable]
    public class Answer {
        //attributes
        [SerializeField] private string info;
        [SerializeField] private bool isCorrect = false;

        //constructor
        public Answer(string info, bool isCorrect) {
            this.info = info;
            this.isCorrect = isCorrect;
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