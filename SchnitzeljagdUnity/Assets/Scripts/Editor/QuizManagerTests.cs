using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class QuizManagerTests{

    [Test]
    public void TestQuizManagerNull() {

        // Arrange
        QuizManager quizManager = new QuizManager();

        // Act

        // Assert
        Assert.Null(quizManager.Quiz);
        Assert.Null(quizManager.CurrentStage);
        Assert.Null(quizManager.CurrentQuestion);
        Assert.Null(quizManager.CurrentAnswers);


    }
    [Test]
    public void TestPreUserInput() {

        // Arrange
        QuizManager quizManager = new QuizManager();
        quizManager.Quiz = QuizData.ReadQuizData(QuizData.Path);

        // Act
        quizManager.SetCurrentStage(0);

        // Assert
        Assert.NotNull(quizManager.Quiz);
        Assert.NotNull(quizManager.CurrentStage);
    }

}
