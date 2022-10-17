namespace TicTacToe;

public class Motion
{
    private       PlayField inMatrix;
    private       double    lineWeight;
    private       int       motionPositionRow;
    private       int       motionPositionColumn;
    private const int       FIRST_PLAYER  = 1;
    private const int       SECOND_PLAYER = -1;

    public Motion(PlayField playField)
    {
        MatrixCopy(inMatrix, playField);
    }
    /// <summary>
    /// Копирование матрицы 
    /// </summary>
    /// <param name="motionMatrix"></param>
    /// <param name="inputPlayField"></param>
    private void MatrixCopy(PlayField motionMatrix, PlayField inputPlayField)
    {
        for (int i = 0; i < inputPlayField.GetLength(0); i++)
        {
            for (int j = 0; j < inputPlayField.GetLength(1); j++)
            {
                motionMatrix[i, j] = inputPlayField[i, j];
            }
        }
    }

    public void SetMotion(int row, int column, PlayerIcon symbol)
    {
        if (symbol == PlayerIcon.O)
        {
            inMatrix[row, column] = FIRST_PLAYER;
        }
        else if (symbol == PlayerIcon.X)
        {
            inMatrix[row, column] = SECOND_PLAYER;
        }
    }
    public Motion GetComputerMotion()
    {
        List<Motion> computerMotions = new List<Motion>();
        computerMotions = inMatrix.GetCoordinated();
        return FindRight(computerMotions);
    }
   
}