using NUnit.Framework;

public class DialogSystemTests 
{
    [Test]
    public void TestStartDialog()
    {
        //Arrange

        Dialog referceDialog = new Dialog();
        referceDialog.dialogStatus = Dialog.DialogStatus.READING;

        DialogSystem temp = new DialogSystem();
        temp.dialogs = new Dialog[1];
        temp.dialogs[0] = new Dialog();
        temp.dialogs[0].dialogStatus = Dialog.DialogStatus.UNREAD;
        Dialog testDialog = temp.dialogs[0];
        testDialog.dialogID = 1;

        //Act

        temp.StartDialog(1);

        //Assert

        Assert.That(testDialog.dialogStatus, Is.EqualTo(referceDialog.dialogStatus));

    }

    [Test]
    public void TestEndDialog()
    {
        //Arrange

        Dialog referceDialog = new Dialog();
        referceDialog.dialogStatus = Dialog.DialogStatus.READ;

        DialogSystem temp = new DialogSystem();
        temp.dialogs = new Dialog[1];
        temp.dialogs[0] = new Dialog();
        temp.dialogs[0].dialogStatus = Dialog.DialogStatus.UNREAD;
        Dialog testDialog = temp.dialogs[0];
        testDialog.dialogID = 1;

        //Act

        temp.StartDialog(1);
        temp.EndDialog(1);

        //Assert

        Assert.That(testDialog.dialogStatus, Is.EqualTo(referceDialog.dialogStatus));

    }


}
