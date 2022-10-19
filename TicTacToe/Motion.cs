namespace TicTacToe;

public class Motion: IMotion
{
    private readonly int ballO = -1;
    private readonly int ballX = 1;

    public bool StepMotions(
        int motionColumn,
        int motionRow,
        PlayerIcon playerPosition,
        PlayField inputPlayField
    )
    {
        if (inputPlayField[motionColumn, motionRow] == 0)
        {
            if (playerPosition == PlayerIcon.O)
            {
                inputPlayField[motionColumn, motionRow] = ballO;
            }
            else if (playerPosition == PlayerIcon.X)
            {
                inputPlayField[motionColumn, motionRow] = ballX;
            }

            return true;
        }

        return false;
    }
}