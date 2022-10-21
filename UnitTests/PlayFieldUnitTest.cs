using TicTacToe;

namespace UnitTests;

[TestFixture(3)]
public class PlayFieldTests: PlayField
{
    [Test]
    public void Row_Column_Size_Dif_Side_Test()
    {
    }
    [Test]
    public void PlayField_Input_Item_Test()
    {
        int playFieldSize = 3;
        var playField = new PlayField(playFieldSize)
                        {
                            [1, 1] = 1,
                            [1, 2] = 1
                        };

        Assert.That(playField[1, 1], Is.EqualTo(1));
        Assert.That(playField[1, 2], Is.EqualTo(1));
    }
    private int inputSize = 3;
    public PlayFieldTests(int inputSize): base(inputSize)
    {
    }
}