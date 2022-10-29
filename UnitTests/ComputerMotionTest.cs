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
}