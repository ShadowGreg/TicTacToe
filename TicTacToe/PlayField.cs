namespace TicTacToe;

public class PlayField
{
    protected const  int            DiagonalCount = 2;
    protected const  int            SideCount     = 2;
    protected const  int            StartScore    = 1;
    protected static int            MatrixSize;
    protected static int[,]?        playField;
    protected static int[,]?        playFieldPointScore;
    protected static int            lineCount;
    protected        LineDictionary LineDictionary;
    protected        int            lineIndex;
    /// <summary>
    ///     Задём игровое поле через его величину
    /// </summary>
    /// <param name="inputSize"></param>
    public PlayField(int inputSize)
    {
        MatrixSize          = inputSize;
        playField           = new int[MatrixSize, MatrixSize];
        playFieldPointScore = new int[MatrixSize, MatrixSize];
        FillNewPlayField();
        lineCount = inputSize * SideCount + DiagonalCount;
        FillPointScore();
        FillLineDictionary();
    }

    public int this[int column, int row]
    {
        get => playField != null ? playField[column, row] : 0;
        set
        {
            if (playField != null) playField[column, row] = value;
            FillPointScore();
            FillLineDictionary();
        }
    }

    /// <summary>
    ///     Заполняем поле баллами
    /// </summary>
    public static void FillPointScore()
    {
        {
            for (int i = 0; i < MatrixSize; i++)
            {
                for (int j = 0; j < MatrixSize; j++)
                {
                    if (playFieldPointScore != null) playFieldPointScore[i, j] = GetPointScore(i, j);
                }
            }
        }
    }
    private static int GetPointScore(int inRow, int inColumn)
    {
        int tempScore = 0;

        int TempScore(int inRow1, int inColumn1, int tempScore1, int i)
        {
            tempScore1 = tempScore1 + playField[i, inColumn1];
            tempScore1 = tempScore1 + playField[inRow1, i];
            return tempScore1;
        }

        if (inRow == inColumn)
        {
            for (int i = 0; i < MatrixSize; i++)
            {
                tempScore = TempScore(inRow, inColumn, tempScore, i);
            }

            for (int i = 0; i < MatrixSize; i++)
            {
                tempScore = tempScore + playField[i, i];
            }
        }

        if (inRow == -inColumn + MatrixSize)
        {
            for (int i = 0; i < MatrixSize; i++)
            {
                tempScore = TempScore(inRow, inColumn, tempScore, i);
            }

            for (int i = 0; i < MatrixSize; i++)
            {
                tempScore = tempScore + playField[i, -i + MatrixSize - 1];
            }
        }

        return tempScore;
    }

    private void FillLineDictionary()
    {
        DTO tempDTO;

        void FillLineDictionary(int inIndex, int temIndex, MatrixSide inMatrixSide)
        {
            List<Coords> coordsList = GetLineCoordList(temIndex, inMatrixSide);
            int lineWeight = GetLineWeight(temIndex, inMatrixSide);
            List<int> pointFill = GetPointFill(temIndex, inMatrixSide);
            List<int> pointScoreList = GetPointScoreList(temIndex, inMatrixSide);
            tempDTO = new DTO(coordsList, lineWeight, pointFill, pointScoreList);
            LineDictionary.GetLineDictionary.Add(inIndex, tempDTO);
        }

        int GetLineWeight(int inIndex, MatrixSide inMatrixSide)
        {
            int tempWeight = 0;
            if (inMatrixSide == MatrixSide.Row)
            {
                for (int i = 0; i < MatrixSize; i++)
                {
                    tempWeight += playFieldPointScore[inIndex, i];
                }
            }
            else if (inMatrixSide == MatrixSide.Column)
            {
                for (int i = 0; i < MatrixSize; i++)
                {
                    tempWeight += playFieldPointScore[i, inIndex];
                }
            }

            return tempWeight;
        }

        List<int> GetPointFill(int inIndex, MatrixSide inSide)
        {
            List<int> tempList = new List<int>();
            if (inSide == MatrixSide.Row)
            {
                for (int i = 0; i < MatrixSize; i++)
                {
                    tempList.Add(playField[inIndex, i]);
                }
            }
            else if (inSide == MatrixSide.Column)
            {
                for (int i = 0; i < MatrixSize; i++)
                {
                    tempList.Add(playField[i, inIndex]);
                }
            }

            return tempList;
        }

        List<int> GetPointScoreList(int inputIndex, MatrixSide inMatrixSide)
        {
            List<int> tempList = new List<int>();
            if (inMatrixSide == MatrixSide.Row)
            {
                for (int i = 0; i < MatrixSize; i++)
                {
                    tempList.Add(playFieldPointScore[inputIndex, i]);
                }
            }
            else if (inMatrixSide == MatrixSide.Column)
            {
                for (int i = 0; i < MatrixSize; i++)
                {
                    tempList.Add(playFieldPointScore[i, inputIndex]);
                }
            }

            return tempList;
        }

        List<Coords> GetDiagonalCoordList(int inDiagonal)
        {
            List<Coords> tempList = new List<Coords>();
            Coords tempCoords;
            if (inDiagonal == 0)
            {
                for (int i = 0; i < MatrixSize; i++)
                {
                    tempCoords = new Coords
                                 {
                                     xCoord = i,
                                     yCoord = i
                                 };
                    tempList.Add(tempCoords);
                }
            }
            else if (inDiagonal == 1)
            {
                for (int i = 0; i < MatrixSize; i++)
                {
                    tempCoords = new Coords
                                 {
                                     xCoord = i,
                                     yCoord = -i + MatrixSize - 1
                                 };
                    tempList.Add(tempCoords);
                }
            }

            return tempList;
        }

        int GetDiagonalWeight(int inDiagonal)
        {
            int tempSum = 0;
            if (inDiagonal == 0)
            {
                for (int i = 0; i < MatrixSize; i++)
                {
                    tempSum += playFieldPointScore[i, i];
                }
            }
            else if (inDiagonal == 1)
            {
                for (int i = 0; i < MatrixSize; i++)
                {
                    tempSum += playFieldPointScore[i, -i + MatrixSize - 1];
                }
            }

            return tempSum;
        }

        List<int> GetDiagonalListBy(int[,] inMatrix, int inDiagonal)
        {
            List<int> tempList = new List<int>();
            if (inDiagonal == 0)
            {
                for (int i = 0; i < MatrixSize; i++)
                {
                    tempList.Add(inMatrix[i, i]);
                }
            }
            else if (inDiagonal == 1)
            {
                for (int i = 0; i < MatrixSize; i++)
                {
                    tempList.Add(inMatrix[i, -i + MatrixSize - 1]);
                }
            }

            return tempList;
        }

        int count = 0;
        for (int i = 0; i < MatrixSize; i++)
        {
            FillLineDictionary(count, i, MatrixSide.Row);
            count++;
        }

        for (int i = 0; i < MatrixSize; i++)
        {
            FillLineDictionary(count, i, MatrixSide.Column);
            count++;
        }

        for (int i = 0; i < DiagonalCount; i++)
        {
            List<Coords> coordsList = GetDiagonalCoordList(i);
            int lineWeight = GetDiagonalWeight(i);
            List<int> pointFill = GetDiagonalListBy(playField, i);
            List<int> pointScoreList = GetDiagonalListBy(playFieldPointScore, i);
            tempDTO = new DTO(coordsList, lineWeight, pointFill, pointScoreList);
            LineDictionary.GetLineDictionary.Add(count, tempDTO);
            count++;
        }
    }
    private static List<Coords> GetLineCoordList(int inputIndex, MatrixSide inSide)
    {
        List<Coords> tempList = new List<Coords>();
        if (inSide == MatrixSide.Row)
        {
            for (int i = 0; i < MatrixSize; i++)
            {
                var tempCoords = new Coords
                                 {
                                     xCoord = inputIndex,
                                     yCoord = i
                                 };
                tempList.Add(tempCoords);
            }
        }
        else if (inSide == MatrixSide.Column)
        {
            for (int i = 0; i < MatrixSize; i++)
            {
                var tempCoords = new Coords
                                 {
                                     xCoord = i,
                                     yCoord = inputIndex
                                 };
                tempList.Add(tempCoords);
            }
        }

        return tempList;
    }
    /// <summary>
    ///     Заполняем игровое поле в момент созданяи экземпляра класса
    /// </summary>
    private static void FillNewPlayField()
    {
        for (int i = 0; i < playField.Length; i++)
        {
            for (int j = 0; j < playField.Length; j++)
            {
                playField[i, j] = StartScore;
            }
        }
    }
    /// <summary>
    ///     Получить длину любой стороны матрицы
    /// </summary>
    /// <returns></returns>
    public int GetLength()
    {
        return playField.GetLength(0);
    }

    protected enum MatrixSide
    {
        Row,
        Column
    }
}