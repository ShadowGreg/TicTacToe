using TicTacToe;

namespace UnitTests;

public class MotionTests
{
    [Test]
    public void Step_Motions_Test()
    {
        int playFieldSize = 3;
        var playerIcon = PlayerIcon.O;
        var playField = new PlayField(playFieldSize);
        var testMotion = new Motion(playerIcon);
        int testColumn = 2;
        int testRow = 2;
        bool motionItem = testMotion.StepMotions(testRow, testColumn, playField);
        Assert.That(motionItem, Is.EqualTo(true));
    }
    [Test]
    public void Tow_Players_Step_Motions_Test()
    {
        int playFieldSize = 3;
        var playerIcon1 = PlayerIcon.O;
        var playerIcon2 = PlayerIcon.X;
        var playField = new PlayField(playFieldSize);
        var testMotion = new Motion(playerIcon1);
        int testColumn1 = 2;
        int testRow1 = 2;
        int testColumn2 = 1;
        int testRow2 = 1;
        bool motionItem1 = testMotion.StepMotions(testRow1, testColumn1, playField);
        bool motionItem2 = testMotion.StepMotions(testRow2, testColumn2, playField);
        Assert.Multiple(() =>
        {
            Assert.That(motionItem1, Is.EqualTo(true));
            Assert.That(motionItem2, Is.EqualTo(true));
        });
    }
    [Test]
    public void Tow_Players_Step_Motions_Test_4x4()
    {
        int playFieldSize = 4;
        var playerIcon1 = PlayerIcon.O;
        var playerIcon2 = PlayerIcon.X;
        var playField = new PlayField(playFieldSize);
        var testMotion = new Motion(playerIcon1);
        int testColumn1 = 2;
        int testRow1 = 2;
        int testColumn2 = 1;
        int testRow2 = 1;
        bool motionItem1 = testMotion.StepMotions(testRow1, testColumn1, playField);
        bool motionItem2 = testMotion.StepMotions(testRow2, testColumn2, playField);
        Assert.Multiple(() =>
        {
            Assert.That(motionItem1, Is.EqualTo(true));
            Assert.That(motionItem2, Is.EqualTo(true));
        });
    }

    [Test]
    public void Impossible_Step_Motions_Test()
    {
        int playFieldSize = 3;
        var playerIcon = PlayerIcon.X;
        var playField = new PlayField(playFieldSize);
        var testMotion = new Motion(playerIcon);
        int testColumn = 2;
        int testRow = 2;
        playField[2, 2] = -2;
        bool motionItem = testMotion.StepMotions(testRow, testColumn, playField);
        Assert.That(motionItem, Is.EqualTo(false));
    }
}