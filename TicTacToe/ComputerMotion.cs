namespace TicTacToe;

public class ComputerMotion: IMotion
{
    private const           int        BallO = -2;
    private const           int        BallX = 2;
    private static          PlayField  inPlayField;
    private static          int[]      localLineFilling;
    private static          int[]      localLineWeight;
    private static readonly int[]      motionArray = new int[inPlayField.GetLength(0) * inPlayField.GetLength(0)];
    private readonly        PlayerIcon setPlayerIcon;

    public ComputerMotion(PlayerIcon inputIcon)
    {
        setPlayerIcon = inputIcon;
    }
    public bool StepMotions(
        int motionColumn,
        int motionRow,
        PlayField inputPlayField
    )
    {
        inPlayField = inputPlayField;
        if (inputPlayField[motionColumn, motionRow] == 0)
        {
            if (setPlayerIcon == PlayerIcon.O)
            {
                inputPlayField[motionColumn, motionRow] = BallO;
            }
            else if (setPlayerIcon == PlayerIcon.X)
            {
                inputPlayField[motionColumn, motionRow] = BallX;
            }

            return true;
        }

        return false;
    }


    private void FillMotionArray()
    {
    }
}