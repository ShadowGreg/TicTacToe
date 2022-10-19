namespace TicTacToe;

public class ComputerMotion: IMotion
{
    private static          PlayField inPlayField;
    private static          int[]     localLineFilling;
    private static          int[]     localLineWeight;
    private readonly        int       ballO       = -1;
    private readonly        int       ballX       = 1;
    private static readonly int[]     motionArray = new int[inPlayField.GetLength(0) * inPlayField.GetLength(0)];

    public bool StepMotions(
        int motionColumn,
        int motionRow,
        PlayerIcon playerPosition,
        PlayField inputPlayField
    )
    {
        inPlayField = inputPlayField;
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
    private static void FindMotion()
    {
        /// для некоего набора ходов определить самый важный или любой из равныйх
        foreach (int motionItem in motionArray)
        {
        }

        localLineWeight  = inPlayField.LineWeight;
        localLineFilling = inPlayField.LineFilling;
    }

    private void FillMotionArray()
    {
        
    }
}