namespace TicTacToe;

public class PlayField
{
    private static int    matrixSize;
    private static int[,] playField;
    private static int[]  lineWeight;
    private        int[]  lineFilling;
    private static int    lineCount;
    const          int    DIAGONAL_COUNT = 2;
    const          int    SIDE_COUNT     = 2;

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

    public int this[int i, int i1]
    {
        get => playField[i, i1];
        set => playField[i, i1] = value;
    }

    public int GetLength(int side) => playField.GetLength(side);
    void IdentifierFillLines()
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
    private int GetFillDiagonalSum(int inputDiagonal)
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
    private int GetFillColumnCount(int inputColumn)
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
    private int GetFillRowCount(int inputRow)
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


    private static void FillLineWeight()
    {
        int i = 0;
        for (int j = 0; j < playField.GetLength(0); j++)
        {
            lineWeight[i] = GetRowSum(j);
            i++;
        }

        for (int j = 0; j < playField.GetLength(1); j++)
        {
            lineWeight[i] = GetColumnSum(j);
            i++;
        }

        for (int j = 0; j < DIAGONAL_COUNT; j++)
        {
            lineWeight[i] = GetDiagonalSum(j);
            i++;
        }
    }
    private static int GetDiagonalSum(int inputDiagonal)
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
    private static int GetColumnSum(int inputColumn)
    {
        int sum = 0;
        for (int i = 0; i < playField.GetLength(0); i++)
        {
            sum = sum + playField[i, inputColumn];
        }

        return sum;
    }
    private static int GetRowSum(int inputRow)
    {
        int sum = 0;
        for (int i = 0; i < playField.GetLength(1); i++)
        {
            sum = sum + playField[inputRow, i];
        }

        return sum;
    }
}