namespace TicTacToe;

public class ComputerMotion: IMotion
{
    private static          PlayField  inPlayField;
    private static          int[]      localLineFilling;
    private static          int[]      localLineWeight;
    private static readonly int[]      motionArray = new int[inPlayField.GetLength(0) * inPlayField.GetLength(0)];
    private readonly        int        ballO       = -1;
    private readonly        int        ballX       = 1;
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
                inputPlayField[motionColumn, motionRow] = ballO;
            }
            else if (setPlayerIcon == PlayerIcon.X)
            {
                inputPlayField[motionColumn, motionRow] = ballX;
            }

            return true;
        }

        return false;
    }


    private void FillMotionArray()
    {
    }
}

// этот класс обрабатывает игровое поле и позволяет получить важные для хода клетки 
internal class ImportanceCells
{
    private const           int               XY_COORD = 2;
    private static          PlayField         inPlayField;
    private static readonly int[]             param = new int[XY_COORD];
    private readonly        int[]             inputLineFilling;
    private readonly        int[]             inputLineWeight;
    private readonly        List<List<int[]>> listLineParam = new List<List<int[]>>();
    private readonly        int               matrixSize;


    public ImportanceCells(PlayField inputPlayField)
    {
        matrixSize = inputPlayField.GetLength(0);
        for (int i = 0; i < matrixSize * matrixSize + 2; i++)
        {
            for (int j = 0; j < matrixSize; j++)
            {
                for (int k = 0; k < matrixSize; k++)
                {
                    param[0] = j;
                    param[1] = k;
                    listLineParam[i].Add(param);
                }
            }
        }

        inputLineFilling = inputPlayField.LineFilling;
        inputLineWeight  = inputPlayField.LineWeight;
    }
    public int[,] GetCellWeight()
    {
        int[,] cellWeight = new int[matrixSize, matrixSize];
        for (int i = 0; i < matrixSize; i++)
        {
            for (int j = 0; j < matrixSize; j++)
            {
                cellWeight[i, j] = GetWeight(i, j);
            }
        }

        return cellWeight;
    }
    private static int GetWeight(int rowCoord, int columnCoord)
    {
        int localWeight = 0;

        return localWeight;
    }
}