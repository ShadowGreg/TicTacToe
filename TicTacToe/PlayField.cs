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

    public PlayField(int inputSize)
    {
        MatrixSize          = inputSize;
        playField           = new int[MatrixSize, MatrixSize];
        playFieldPointScore = new int[MatrixSize, MatrixSize];
        FillNewPlayField();
        lineCount = inputSize * SideCount + DiagonalCount;
        GetPointScore();
        FillLineDictionary();
    }

    public int this[int column, int row]
    {
        get => playField[column, row];
        set => playField[column, row] = value;
    }

    private void GetPointScore()
    {
        throw new NotImplementedException();
    }

    private void FillLineDictionary()
    {
        int count = 0;
        for (int i = 0; i < MatrixSize; i++)
        {
            LineDictionary.GetLineDictionary.Add(count, null);
            LineDictionary.GetLineDictionary[count].CoordsList     = GetLineCoordList(i, MatrixSide.ROW);
            LineDictionary.GetLineDictionary[count].LineWeight     = GetRowWeight(i);
            LineDictionary.GetLineDictionary[count].PointFill      = GetRowPointFill(i);
            LineDictionary.GetLineDictionary[count].PointScoreList = GetRowPointScoreList(i);
            count++;
        }

        for (int i = 0; i < MatrixSize; i++)
        {
            LineDictionary.GetLineDictionary.Add(count, null);
            LineDictionary.GetLineDictionary[count].CoordsList     = GetLineCoordList(i, MatrixSide.COLUMN);
            LineDictionary.GetLineDictionary[count].LineWeight     = GetColumnWeight(i);
            LineDictionary.GetLineDictionary[count].PointFill      = GetColumnPointFill(i);
            LineDictionary.GetLineDictionary[count].PointScoreList = GetColumnPointScoreList(i);
            count++;
        }

        for (int i = 0; i < DiagonalCount; i++)
        {
            LineDictionary.GetLineDictionary.Add(count, null);
            LineDictionary.GetLineDictionary[count].CoordsList     = GetDiagonalCoordList(i);
            LineDictionary.GetLineDictionary[count].LineWeight     = GetDiagonalWeight(i);
            LineDictionary.GetLineDictionary[count].PointFill      = GetDiagonalPointFill(i);
            LineDictionary.GetLineDictionary[count].PointScoreList = GetDiagonalPointScoreList(i);
            count++;
        }
    }
    private static List<Coords> GetLineCoordList(int inputIndex, MatrixSide inSide)
    {
        List<Coords> tempList = new List<Coords>();
        if (inSide == MatrixSide.ROW)
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
        else if (inSide == MatrixSide.COLUMN)
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

    public int GetLength(int side)
    {
        return playField.GetLength(side);
    }

    protected enum MatrixSide
    {
        ROW,
        COLUMN
    }
}