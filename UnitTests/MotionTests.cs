using TicTacToe;

namespace UnitTests;

[TestFixture(3)]
public class MotionTests: PlayField
{
    [Test]
    public void Motion_PlayField_Test()
    {
        int playFieldSize = 3;
        var playerIcon = PlayerIcon.O;
        var playField = new PlayField(playFieldSize)
                        {
                            [1, 1] = 1,
                            [1, 2] = 1
                        };
        var testMotion = new Motion();
        int testColumn = 2;
        int testRow = 2;
        bool motionItem = testMotion.StepMotions(testColumn, testRow, playerIcon, playField);
        int actualItem = playField[testColumn, testRow];
        int expectedItem = -1;
        Assert.AreEqual(expectedItem, actualItem);
    }
    [Test]
    public void Motion_Impossible_Test()
    {
        int playFieldSize = 3;
        var playerIcon = PlayerIcon.X;
        var playField = new PlayField(playFieldSize)
                        {
                            [1, 1] = 1,
                            [1, 2] = 1
                        };
        var testMotion = new Motion();
        int testColumn = 2;
        int testRow = 2;
        bool motionItemFirst = testMotion.StepMotions(testColumn, testRow, playerIcon, playField);
        bool actualMotionItem = testMotion.StepMotions(testColumn, testRow, playerIcon, playField);
        bool expectedItem = false;
        Assert.AreEqual(expectedItem, actualMotionItem);
    }
    public MotionTests(int inputSize): base(inputSize)
    {
    }
}