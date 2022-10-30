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
    public void play_Field_Point_Score_Test()
    {
        const int playFieldSize = 3;
        var playField = new PlayField(playFieldSize);
        int[,] expectedPlayFieldPointScore =
        {
            { 9, 6, 9 },
            { 6, 12, 6 },
            { 9, 6, 9 }
        };
        Assert.That(playFieldPointScore[1, 1], Is.EqualTo(expectedPlayFieldPointScore[1, 1]));

        playField[1, 1] = -2;

        int[,] expectedPlayFieldPointScore2 =
        {
            { 6, 3, 6 },
            { 4, 0, 3 },
            { 6, 3, 6 }
        };
        Assert.That(playFieldPointScore[1, 1], Is.EqualTo(expectedPlayFieldPointScore2[1, 1]));

        playField[2, 0] = 2;

        int[,] expectedPlayFieldPointScore3 =
        {
            { 7, 4, 9 },
            { 3, 1, 3 },
            { 7, 3, 6 }
        };
        Assert.That(playFieldPointScore[1, 2], Is.EqualTo(expectedPlayFieldPointScore3[1, 2]));
    }
    [Test]
    public void Line_Dictionary_Point_Score_Test()
    {
        int playFieldSize = 3;
        var playField = new PlayField(playFieldSize);
        Assert.That(playField.LineDictionary[1].PointScoreList[1], Is.EqualTo(12));

        playField[1, 1] = -2;
        playField[1, 2] = 2;
        Assert.That(playField.LineDictionary[1].PointScoreList[2], Is.EqualTo(3));
    }
    [Test]
    public void Line_Dictionary_Point_Score_Set_Test()
    {
        int playFieldSize = 3;
        var playField = new PlayField(playFieldSize);
        var inCoords1 = new Coords { xCoord = 1, yCoord = 2 };
        var inCoords2 = new Coords { xCoord = 0, yCoord = 0 };
        List<Coords> inCoordsList = new List<Coords> { inCoords1, inCoords2 };
        int inLineWeight = 21;
        List<int> inPointFill = new List<int> { 1, 2, 3 };
        List<int> inPointScoreList = new List<int> { 1, 2, 3 };
        var testDTO = new DTO(inCoordsList, inLineWeight, inPointFill, inPointScoreList);
        playField.LineDictionary[1] = testDTO;
        Assert.That(playField.LineDictionary[1].PointScoreList[2], Is.EqualTo(3));
    }
    [Test]
    public void Get_Length_Test()
    {
        int playFieldSize = 3;
        var playField = new PlayField(playFieldSize);
        Assert.That(GetLength(), Is.EqualTo(3));
    }

    [Test]
    public void Order_Line_Weights_Test()
    {
        int playFieldSize = 3;
        var playField = new PlayField(playFieldSize)
                        {
                            [0, 0] = 2,
                            [1, 0] = 2
                        };
        List<int> actualLineWeight = new List<int>();
        for (int i = 0; i < playField.LineDictionary.Count; i++)
        {
            actualLineWeight.Add(playField.LineDictionary[i].LineWeight);
        }

        List<int> expectedLineWeight = new List<int>
                                       {
                                           33,
                                           27,
                                           27,
                                           30,
                                           30,
                                           27,
                                           37,
                                           35
                                       };


        Assert.That(actualLineWeight, Is.EqualTo(expectedLineWeight));
    }
    private int inputSize = 3;
    public PlayFieldTests(int inputSize): base(inputSize)
    {
    }
}