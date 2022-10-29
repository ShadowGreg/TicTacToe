namespace TicTacToe;

public class ComputerMotion: IMotion
{
    private const    int        BallO = -2;
    private const    int        BallX = 2;
    private readonly PlayerIcon _setPlayerIcon;
    private          PlayField  localPlayField;


    public ComputerMotion(PlayerIcon inputIcon)
    {
        _setPlayerIcon = inputIcon;
    }
    /// <summary>
    ///     Рассчитываем компьютерный ход
    /// </summary>
    /// <param name="inputPlayField">подаваемое игровое поле на вход</param>
    /// <returns></returns>
    public bool StepMotions(PlayField inputPlayField)
    {
        localPlayField = inputPlayField;
        List<int> localLineWeightList = new List<int>(GetLineWeight());

        ///Обрабатываем словари и веса линий
        IEnumerable<int> GetLineWeight()
        {
            List<int> lineWeight = new List<int>();
            for (int i = 0; i < localPlayField.LineDictionary.Count; i++)
            {
                lineWeight.Add(localPlayField.LineDictionary[i].LineWeight);
            }

            return lineWeight;
        }

        ///Получаем неопределенный лист максимальных значений
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

        ///Автоматически находим координаты точки установки
        Coords CoordStepPoint()
        {
            ///Возвращем случайное число из списка
            int GetRandIndex(IReadOnlyList<int> inList)
            {
                var rand = new Random();
                int index = rand.Next(inList.Count);
                return inList[index];
            }

            List<int> listMaxLineWeight = GetMaxList(localLineWeightList);
            int lineIndex = GetRandIndex(listMaxLineWeight);
            List<int> pointScoreList = inputPlayField.LineDictionary[lineIndex].PointScoreList;
            List<int> maxPointScoreList = GetMaxList(pointScoreList);
            int pointIndex = GetRandIndex(maxPointScoreList);
            return inputPlayField.LineDictionary[lineIndex].CoordsList[pointIndex];
        }

        ///Делаем ход с проверкой поля на условную пустоту - за него отвечает 1
        bool SetMotion(int inMotionColumn, int inMotionRow)
        {
            if (inputPlayField[inMotionColumn, inMotionRow] == 1)
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