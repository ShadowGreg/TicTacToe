using TicTacToe;

namespace UnitTests;

public class ComputerMotionTest
{
    [Test]
    public void Step_Motions_Test()
    {
        int playFieldSize = 3;
        var playerIcon = PlayerIcon.O;
        var playField = new PlayField(playFieldSize);
        var testMotion = new ComputerMotion(playerIcon);

        bool motionItem = testMotion.StepMotions(playField);
        Assert.That(motionItem, Is.EqualTo(true));
    }

    [Test]
    public void Tow_Players_Test()
    {
        int playFieldSize = 3;
        var playerIcon1 = PlayerIcon.O;
        var playerIcon2 = PlayerIcon.X;
        var playField = new PlayField(playFieldSize);
        var firstPlayer = new ComputerMotion(playerIcon1);
        var secondPlayer = new ComputerMotion(playerIcon2);

        bool motionItem1 = firstPlayer.StepMotions(playField);
        Assert.That(motionItem1, Is.EqualTo(true));

        bool motionItem2 = secondPlayer.StepMotions(playField);
        Assert.That(motionItem2, Is.EqualTo(true));
    }
    [Test]
    public void Several_Players_Steps_Test()
    {
        int playFieldSize = 3;
        var playerIcon1 = PlayerIcon.O;
        var playerIcon2 = PlayerIcon.X;
        var playField = new PlayField(playFieldSize);
        var firstPlayer = new ComputerMotion(playerIcon2);
        var secondPlayer = new ComputerMotion(playerIcon1);

        for (int i = 0; i < 3; i++)
        {
            bool motionItem1 = firstPlayer.StepMotions(playField); 
            Assert.That(motionItem1, Is.EqualTo(true));

            bool motionItem2 = secondPlayer.StepMotions(playField);
            Assert.That(motionItem2, Is.EqualTo(true));
        }
    }
}