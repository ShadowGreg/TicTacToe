namespace TicTacToe;

public class ComputerMotion: IMotion
{
    private const    int        BallO = -2;
    private const    int        BallX = 2;
    private readonly PlayerIcon _setPlayerIcon;


    public ComputerMotion(PlayerIcon inputIcon)
    {
        _setPlayerIcon = inputIcon;
    }
    public bool StepMotions(
        PlayField inputPlayField
    )
    {
        List<int> localLineWeightList = inputPlayField.LineDictionary.Select(e => e.Key).ToList();

        List<int> GetMaxList(List<int> inputList)
        {
            List<int> outputIndexList = new List<int>();
            int maxItem = inputList.Max();
            for (int i = 0; i < inputList.Count; i++)
            {
                if (inputList[i] == maxItem)
                    outputIndexList.Add(i);
            }

            return outputIndexList;
        }

        Coords CoordStepPoint()
        {
            var rand = new Random();
            List<int> listMaxLineWeight = GetMaxList(localLineWeightList);
            int lineIndex = rand.Next(listMaxLineWeight.Count);
            List<int> pointScoreList = inputPlayField.LineDictionary[listMaxLineWeight[lineIndex]].PointScoreList;
            List<int> maxPointScoreList = GetMaxList(pointScoreList);
            int pointIndex = rand.Next(maxPointScoreList.Count);
            return inputPlayField.LineDictionary[lineIndex].CoordsList[pointIndex];
        }

        bool SetMotion(int inMotionColumn, int inMotionRow)
        {
            if (inputPlayField[inMotionColumn, inMotionRow] == 0)
            {
                if (_setPlayerIcon == PlayerIcon.O)
                {
                    inputPlayField[inMotionColumn, inMotionRow] = BallO;
                }
                else if (_setPlayerIcon == PlayerIcon.X)
                {
                    inputPlayField[inMotionColumn, inMotionRow] = BallX;
                }

                return true;
            }

            return false;
        }

        return SetMotion(CoordStepPoint().yCoord, CoordStepPoint().xCoord);
    }
}