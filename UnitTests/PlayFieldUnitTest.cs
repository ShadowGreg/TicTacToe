using TicTacToe;

namespace UnitTests;

[TestFixture(3)]
public class PlayFieldTests: PlayField
{
    [Test]
    public void Input_Item_Test()
    {
        int playFieldSize = 3;
        var playField = new PlayField(playFieldSize)
                        {
                            [1, 1] = -2,
                            [1, 2] = 2
                        };

        Assert.That(playField[1, 1], Is.EqualTo(-2));
        Assert.That(playField[1, 2], Is.EqualTo(2));
    }
    [Test]
    public void Line_Dictionary_Test()
    {
        int playFieldSize = 3;
        var playField = new PlayField(playFieldSize)
                        {
                            [1, 1] = -2,
                            [1, 2] = 2
                        };

        Assert.IsNotEmpty(playField.LineDictionary);
    }
    [Test]
    public void Line_Dictionary_PointFill_Test()
    {
        int playFieldSize = 3;
        var playField = new PlayField(playFieldSize)
                        {
                            [1, 1] = -2,
                            [1, 2] = 2
                        };

        Assert.IsNotEmpty(playField.LineDictionary[0].PointFill);
    }
    [Test]
    public void Line_Dictionary_FillPointScore_Test()
    {
        int playFieldSize = 3;
        var playField = new PlayField(playFieldSize)
                        {
                            [1, 1] = -2,
                            [1, 2] = 2
                        };

        Assert.IsNotEmpty(playField.LineDictionary[0].PointScoreList);
    }
    [Test]
    public void Line_Dictionary_Point_Fill_Test()
    {
        int playFieldSize = 3;
        var playField = new PlayField(playFieldSize)
                        {
                            [1, 1] = -2,
                            [1, 2] = 2
                        };
        int actualInt1 = playField.LineDictionary[0].PointFill[1];
        Assert.AreEqual(1, actualInt1);
        int actualInt2 = playField.LineDictionary[1].PointFill[1];
        Assert.AreEqual(-2, actualInt2);
    }
    [Test]
    public void Line_Dictionary_Point_Score_Test()
    {
        int playFieldSize = 3;
        var playField = new PlayField(playFieldSize);
        int[,] expecedPlayFieldPointScore =
        {
            { 9, 6, 9 },
            { 6, 12, 6 },
            { 9, 6, 9 }
        };
        Assert.That(playFieldPointScore[1, 1], Is.EqualTo(expecedPlayFieldPointScore[1, 1]));

        playField[1, 1] = -2;
        playField[1, 2] = 2;

        int[,] expecedPlayFieldPointScore2 =
        {
            { 9, 3, 7 },
            { 4, 1, 5 },
            { 6, 3, 7 }
        };
        Assert.That(playFieldPointScore[1, 1], Is.EqualTo(expecedPlayFieldPointScore2[1, 1]));
    }
    private int inputSize = 3;
    public PlayFieldTests(int inputSize): base(inputSize)
    {
    }
}