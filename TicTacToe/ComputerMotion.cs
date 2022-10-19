namespace TicTacToe;

public class ComputerMotion: IMotion
{
    private static          PlayField inPlayField;
    private static          int[]     localLineFilling;
    private static          int[]     localLineWeight;
    private static readonly int[]     motionArray = new int[inPlayField.GetLength(0) * inPlayField.GetLength(0)];
    private readonly        int       ballO       = -1;
    private readonly        int       ballX       = 1;

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
    public List<int> GetMaxScoreLineOpponent()
    {
        List<int> coords = new List<int>();

        return coords;
    }
    public List<int> GetMaxScoreLineComputer()
    {
        List<int> coords = new List<int>();

        return coords;
    }

    private void FillMotionArray()
    {
    }
}

//этот класс будет в себе хранить все направления линий подсчёта очков и занятости линий с расшифровкой - 
//какие в этих линиях есть ячейки
internal class DTOMotion
{
    private const           int               XY_COORD      = 2;
    private static readonly int[]             param         = new int[XY_COORD];
    private readonly        List<List<int[]>> listLineParam = new List<List<int[]>>();


    public DTOMotion(int inputMatrixSize)
    {
        for (int i = 0; i < inputMatrixSize * inputMatrixSize + 2; i++)
        {
            for (int j = 0; j < inputMatrixSize; j++)
            {
                for (int k = 0; k < inputMatrixSize; k++)
                {
                    param[0] = j;
                    param[1] = k;
                    listLineParam[i].Add(param);
                }
            }
        }
    }
    public void SetLineParam(int[] inputLineWeight, int[] inputLineFilling)
    {
        for (int i = 0; i < inputLineWeight.Length; i++)
        {
            param[0] = inputLineFilling[i];
            param[1] = inputLineWeight[i];
            listLineParam[i].Add(param);
        }
    }
}
