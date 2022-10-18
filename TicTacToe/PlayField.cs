namespace TicTacToe;

public class PlayField
{
    protected static int     matrixSize;
    protected static int[,]? playField;
    protected static int[]?  lineWeight;
    protected static int[]   lineFilling;
    protected static int     lineCount;
    protected const  int     DIAGONAL_COUNT = 2;
    protected const  int     SIDE_COUNT     = 2;

    public PlayField(int inputSize)
    {
        matrixSize = inputSize;
        playField  = new int[matrixSize, matrixSize];
        lineCount  = inputSize * SIDE_COUNT + DIAGONAL_COUNT;
        lineWeight = new int[lineCount];
        FillLineWeight();
        lineFilling = new int[lineCount];
        IdentifierFillLines();
    }

    public int this[int column, int row]
    {
        get => playField[column, row];
        set => playField[column, row] = value;
    }

    public int GetLength(int side) => playField.GetLength(side);
        /// <summary>
        /// определение заполнения линий в нат числах 
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

        for (int j = 0; j < DIAGONAL_COUNT; j++)
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
            for (int i = 0; i < matrixSize; i++)
            {
                if (playField[i, i] != 0)
                {
                    sum++;
                }
            }
        }

        if (inputDiagonal == 1)
        {
            for (int i = matrixSize - 1; i >= 0; i--)
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
    /// баллы в линиях по сумме заполненной внутри
    /// баллы считаются так
    /// -1 один игрок
    /// 1 другой игрок
    /// в квадрате 3х3 если линия заполнена полностью
    /// то ее вес 3 либо -3
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

        for (int j = 0; j < DIAGONAL_COUNT; j++)
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
            for (int i = 0; i < matrixSize; i++)
            {
                sum = sum + playField[i, i];
            }
        }

        if (inputDiagonal == 1)
        {
            for (int i = matrixSize - 1; i >= 0; i--)
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