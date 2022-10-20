namespace TicTacToe;

public class PlayField
{
    protected const  int     DiagonalCount = 2;
    protected const  int     SideCount     = 2;
    protected static int     MatrixSize;
    protected static int[,]? playField;
    protected static int[]?  lineWeight;
    protected static int[]   lineFilling;

    protected static int lineCount;

    public PlayField(int inputSize)
    {
        MatrixSize = inputSize;
        playField  = new int[MatrixSize, MatrixSize];
        lineCount  = inputSize * SideCount + DiagonalCount;
        lineWeight = new int[lineCount];
        FillLineWeight();
        lineFilling = new int[lineCount];
        IdentifierFillLines();
    }

    public int[]? LineWeight
    {
        get => lineWeight;
    }

    public int[] LineFilling
    {
        get => lineFilling;
    }

    public int this[int column, int row]
    {
        get => playField[column, row];
        set => playField[column, row] = value;
    }

    public int GetLength(int side)
    {
        return playField.GetLength(side);
    }

    /// <summary>
    ///     определение заполнения линий в нат числах
    /// </summary>
    public void IdentifierFillLines()
    {
        int i = 0;
        for (int j = 0; j < playField.GetLength(0); j++)
        {
            lineFilling[i] = GetFillRowCount(j);
            i++;
        }

        for (int j = 0; j < playField.GetLength(1); j++)
        {
            lineFilling[i] = GetFillColumnCount(j);
            i++;
        }

        for (int j = 0; j < DiagonalCount; j++)
        {
            lineFilling[i] = GetFillDiagonalSum(j);
            i++;
        }
    }
    protected int GetFillDiagonalSum(int inputDiagonal)
    {
        int sum = 0;
        if (inputDiagonal == 0)
        {
            for (int i = 0; i < MatrixSize; i++)
            {
                if (playField[i, i] != 0)
                {
                    sum++;
                }
            }
        }

        if (inputDiagonal == 1)
        {
            for (int i = MatrixSize - 1; i >= 0; i--)
            {
                if (playField[i, i] != 0)
                {
                    sum++;
                }
            }
        }

        return sum;
    }
    protected int GetFillColumnCount(int inputColumn)
    {
        int sum = 0;
        for (int i = 0; i < playField.GetLength(0); i++)
        {
            if (playField[i, inputColumn] != 0)
            {
                sum++;
            }
        }

        return sum;
    }
    protected int GetFillRowCount(int inputRow)
    {
        int sum = 0;
        for (int i = 0; i < playField.GetLength(1); i++)
        {
            if (playField[inputRow, i] != 0)
            {
                sum++;
            }
        }

        return sum;
    }

    /// <summary>
    ///     баллы в линиях по сумме заполненной внутри
    ///     баллы считаются так
    ///     -1 один игрок
    ///     1 другой игрок
    ///     в квадрате 3х3 если линия заполнена полностью
    ///     то ее вес 3 либо -3
    /// </summary>
    public void FillLineWeight()
    {
        int i = 0;
        for (int j = 0; j < playField.GetLength(0); j++)
        {
            if (lineWeight != null) lineWeight[i] = GetRowSum(j);
            i++;
        }

        for (int j = 0; j < playField.GetLength(1); j++)
        {
            if (lineWeight != null) lineWeight[i] = GetColumnSum(j);
            i++;
        }

        for (int j = 0; j < DiagonalCount; j++)
        {
            if (lineWeight != null) lineWeight[i] = GetDiagonalSum(j);
            i++;
        }
    }
    protected static int GetDiagonalSum(int inputDiagonal)
    {
        int sum = 0;
        if (inputDiagonal == 0)
        {
            for (int i = 0; i < MatrixSize; i++)
            {
                sum = sum + playField[i, i];
            }
        }

        if (inputDiagonal == 1)
        {
            for (int i = MatrixSize - 1; i >= 0; i--)
            {
                sum = sum + playField[i, i];
            }
        }

        return sum;
    }
    protected static int GetColumnSum(int inputColumn)
    {
        int sum = 0;
        for (int i = 0; i < playField.GetLength(0); i++)
        {
            sum = sum + playField[i, inputColumn];
        }

        return sum;
    }
    protected static int GetRowSum(int inputRow)
    {
        int sum = 0;
        for (int i = 0; i < playField.GetLength(1); i++)
        {
            sum = sum + playField[inputRow, i];
        }

        return sum;
    }
}