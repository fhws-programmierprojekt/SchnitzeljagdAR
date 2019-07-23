using NUnit.Framework;
using System.Collections.Generic;

public class NewBehaviourScript 
{
    [Test]
    public void TestAvailbleQuest()
    {
        //Arrange

        Quests referceQuest = new Quests();
        referceQuest.progress = Quests.QuestProgress.AVAILABLE;

        QuestHubController questHub = new QuestHubController();
        questHub.questList = new List<Quests>();
        Quests testQuest = new Quests();
        testQuest.id = 1;
        testQuest.progress = Quests.QuestProgress.NOT_AVAILABE;
        questHub.questList.Add(testQuest);

        //Act

        questHub.AvailbleQuest(1);

        //Assert

        Assert.That(testQuest.progress, Is.EqualTo(referceQuest.progress));
    }
    [Test]
    public void TestCompleteQuest()
    {
        //Arrange

        Quests referceQuest = new Quests();
        referceQuest.progress = Quests.QuestProgress.DONE;

        QuestHubController questHub = new QuestHubController();
        questHub.questList = new List<Quests>();
        Quests testQuest = new Quests();
        testQuest.id = 1;
        testQuest.progress = Quests.QuestProgress.NOT_AVAILABE;
        questHub.questList.Add(testQuest);

        //Act

        questHub.CompleteQuest(1);

        //Assert

        Assert.That(testQuest.progress, Is.EqualTo(referceQuest.progress));
    }
    [Test]
    public void TestAddPoints()
    {
        //Arrange

        Quests referceQuest = new Quests();
        referceQuest.progress = Quests.QuestProgress.NOT_AVAILABE;
        referceQuest.pointReward = 100;

        QuestHubController questHub = new QuestHubController();
        questHub.questList = new List<Quests>();
        Quests testQuest = new Quests();
        testQuest.id = 0;
        testQuest.progress = Quests.QuestProgress.NOT_AVAILABE;
        testQuest.pointReward = 75;
        questHub.questList.Add(testQuest);

        //Act

        questHub.AddPoints(25);

        //Assert

        Assert.That(testQuest.pointReward, Is.EqualTo(referceQuest.pointReward));
    }
    [Test]
    public void TestImageTargetFound()
    {
        //Arrange

        Quests referceQuest = new Quests();
        referceQuest.imageProgress = Quests.ImagetargetProgress.FOUND;

        QuestHubController questHub = new QuestHubController();
        questHub.questList = new List<Quests>();
        Quests testQuest = new Quests();
        testQuest.id = 1;
        testQuest.imageProgress = Quests.ImagetargetProgress.NOT_FOUND;
        questHub.questList.Add(testQuest);

        //Act

        questHub.ImageTargetFound(1);

        //Assert

        Assert.That(testQuest.imageTargerPosition, Is.EqualTo(referceQuest.imageTargerPosition));
    }
    [Test]
    public void TestMinigameDone()
    {
        //Arrange

        Quests referceQuest = new Quests();
        referceQuest.minigameProgress= Quests.MinigameProgress.DONE;

        QuestHubController questHub = new QuestHubController();
        questHub.questList = new List<Quests>();
        Quests testQuest = new Quests();
        testQuest.id = 1;
        testQuest.minigameProgress = Quests.MinigameProgress.NOT_DONE;
        questHub.questList.Add(testQuest);

        //Act

        questHub.MinigameDone(1);

        //Assert

        Assert.That(testQuest.minigameProgress, Is.EqualTo(referceQuest.minigameProgress));
    }
    [Test]
    public void TestResetProgress()
    {
        //Arrange

        Quests referceQuest = new Quests();
        referceQuest.minigameProgress = Quests.MinigameProgress.DONE;
        referceQuest.imageProgress = Quests.ImagetargetProgress.NOT_FOUND;

        QuestHubController questHub = new QuestHubController();
        questHub.questList = new List<Quests>();
        Quests testQuest = new Quests();
        testQuest.id = 1;
        testQuest.minigameProgress = Quests.MinigameProgress.NOT_DONE;
        testQuest.imageProgress = Quests.ImagetargetProgress.FOUND;
        questHub.questList.Add(testQuest);

        //Act

        questHub.ResetProgress(1);

        //Assert

        Assert.That(testQuest.minigameProgress, Is.EqualTo(referceQuest.minigameProgress));
        Assert.That(testQuest.imageProgress, Is.EqualTo(referceQuest.imageProgress));
    }
    [Test]
    public void TestRequestAvailbleQuest()
    {
        //Arrange

        bool referceQuest1 = true;
        bool referceQuest2 = false;

        QuestHubController questHub = new QuestHubController();
        questHub.questList = new List<Quests>();
        Quests testQuest = new Quests();
        Quests testQuest2 = new Quests();
        testQuest.id = 1;
        testQuest2.id = 2;
        testQuest.progress = Quests.QuestProgress.AVAILABLE;
        testQuest2.progress = Quests.QuestProgress.NOT_AVAILABE;
        questHub.questList.Add(testQuest);
        questHub.questList.Add(testQuest2);

        //Act

        questHub.RequestAvailbleQuest(1);
        questHub.RequestAvailbleQuest(2);

        //Assert

        Assert.That(questHub.RequestAvailbleQuest(1), Is.EqualTo(referceQuest1));
        Assert.That(questHub.RequestAvailbleQuest(2), Is.EqualTo(referceQuest2));
    }
    [Test]
    public void TestRequestQuestDone()
    {
        //Arrange

        bool referceQuest1 = true;
        bool referceQuest2 = false;

        QuestHubController questHub = new QuestHubController();
        questHub.questList = new List<Quests>();
        Quests testQuest = new Quests();
        Quests testQuest2 = new Quests();
        testQuest.id = 1;
        testQuest2.id = 2;
        testQuest.progress = Quests.QuestProgress.DONE;
        testQuest2.progress = Quests.QuestProgress.NOT_AVAILABE;
        questHub.questList.Add(testQuest);
        questHub.questList.Add(testQuest2);

        //Act

        questHub.RequestQuestDone(1);
        questHub.RequestQuestDone(2);

        //Assert

        Assert.That(questHub.RequestQuestDone(1), Is.EqualTo(referceQuest1));
        Assert.That(questHub.RequestQuestDone(2), Is.EqualTo(referceQuest2));
    }
    [Test]
    public void TestQuestTargetAllreadyFound()
    {
        //Arrange

        bool referceQuest1 = true;

        QuestHubController questHub = new QuestHubController();
        questHub.questList = new List<Quests>();
        Quests testQuest = new Quests();
        testQuest.id = 0;
        testQuest.imageProgress = Quests.ImagetargetProgress.FOUND;
        questHub.questList.Add(testQuest);

        //Act
        //Assert

        Assert.That(questHub.QuestTargetAllreadyFound(), Is.EqualTo(referceQuest1));
    }
    [Test]
    public void TestQuestTargetNotAllreadyFound()
    {
        //Arrange

        bool referceQuest1 = false;

        QuestHubController questHub = new QuestHubController();
        questHub.questList = new List<Quests>();
        Quests testQuest = new Quests();
        testQuest.id = 0;
        testQuest.imageProgress = Quests.ImagetargetProgress.NOT_FOUND;
        questHub.questList.Add(testQuest);

        //Act
        //Assert

        Assert.That(questHub.QuestTargetAllreadyFound(), Is.EqualTo(referceQuest1));
    }
    [Test]
    public void TestQuestMinigameAllreadyDone()
    {
        //Arrange

        bool referceQuest1 = true;

        QuestHubController questHub = new QuestHubController();
        questHub.questList = new List<Quests>();
        Quests testQuest = new Quests();
        testQuest.id = 0;
        testQuest.minigameProgress = Quests.MinigameProgress.DONE;
        questHub.questList.Add(testQuest);

        //Act
        //Assert

        Assert.That(questHub.QuestMinigameAllreadyDone(), Is.EqualTo(referceQuest1));
    }
    [Test]
    public void TestQuestMinigameNotAllreadyDone()
    {
        //Arrange

        bool referceQuest1 = false;

        QuestHubController questHub = new QuestHubController();
        questHub.questList = new List<Quests>();
        Quests testQuest = new Quests();
        testQuest.id = 0;
        testQuest.minigameProgress = Quests.MinigameProgress.NOT_DONE;
        questHub.questList.Add(testQuest);

        //Act
        //Assert

        Assert.That(questHub.QuestMinigameAllreadyDone(), Is.EqualTo(referceQuest1));
    }
    [Test]
    public void TestQuestPoints()
    {
        //Arrange

        int referceQuest1 = 100;

        QuestHubController questHub = new QuestHubController();
        questHub.questList = new List<Quests>();
        Quests testQuest = new Quests();
        testQuest.id = 1;
        testQuest.pointReward= 100;
        questHub.questList.Add(testQuest);

        //Act
        //Assert

        Assert.That(questHub.QuestPoints(1), Is.EqualTo(referceQuest1));
    }
}
