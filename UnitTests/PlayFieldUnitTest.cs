using NUnit.Framework.Internal;
using TicTacToe;

namespace UnitTests;

[TestFixture(3)]
public class PlayFieldTests: PlayField
{
    [Test]
    public void Row_Column_Size_Dif_Side_Test()
    {
        int columnSide = 0;
        int rowSide = 1;
        int playFieldSize = 3;
        PlayField playField = new PlayField(playFieldSize);
        int columnLight = playField.GetLength(columnSide);
        int rowLight = playField.GetLength(rowSide);
        Assert.That(columnLight, Is.EqualTo(3));
        Assert.That(rowLight, Is.EqualTo(3));
    }
    [Test]
    public void PlayField_Input_Item_Test()
    {
        int playFieldSize = 3;
        PlayField playField = new PlayField(playFieldSize)
                              {
                                  [1, 1] = 1,
                                  [1, 2] = 1
                              };

        Assert.That(playField[1, 1], Is.EqualTo(1));
        Assert.That(playField[1, 2], Is.EqualTo(1));
    }

    [Test]
    public void FillLineWeight_Test()
    {
        int playFieldSize = 3;
        var playField = new PlayField(playFieldSize)
                        {
                            [1, 1] = 1,
                            [1, 2] = 1
                        };
        playField.FillLineWeight();

        Assert.AreEqual("0;2;0;0;1;1;1;1", string.Join(";", lineWeight));
    }
    [Test]
    public void IdentifierFillLines_Test()
    {
        int playFieldSize = 3;
        var playField = new PlayField(playFieldSize)
                        {
                            [1, 1] = 1,
                            [1, 2] = 1
                        };
        playField.IdentifierFillLines();

        Assert.AreEqual("0;2;0;0;1;1;1;1", string.Join(";", lineFilling));
    }
    private int inputSize = 3;
    public PlayFieldTests(int inputSize): base(inputSize)
    {
    }
}