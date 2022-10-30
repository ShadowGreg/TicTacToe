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

        ///Получаем неопределенный лист Отличных от прочих значений
        List<int> GetEvolvedList(List<int> inputList)
            ///TODO поменять местами иконки, что бы препятствовать победе противника - поменял
        {
            List<int> outputIndexList = new List<int>();
            if (_setPlayerIcon == PlayerIcon.O)
            {
                int maxItem = inputList.Max();
                for (int i = 0; i < inputList.Count; i++)
                {
                    if (inputList[i] == maxItem)
                        outputIndexList.Add(i);
                }
            }
            else if (_setPlayerIcon == PlayerIcon.X)
            {
                int minItem = inputList.Min();
                for (int i = 0; i < inputList.Count; i++)
                {
                    if (inputList[i] == minItem)
                        outputIndexList.Add(i);
                }
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
                const int minValue = 0;
                int index = rand.Next(minValue, inList.Count);
                if (inList.Count > 1)
                {
                    return inList[index]; ///TODO Возникает не постоянная ошибка
                }

                return 0;
            }
            ///TODO Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')

            List<int> GetEvolvedPointList(int inLineIndex)
            {
                List<int> pointScoreList = inputPlayField.LineDictionary[inLineIndex].PointScoreList;
                List<int> pointIndex = new List<int>();
                for (int i = 0; i < pointScoreList.Count; i++)
                {
                    if (inputPlayField.LineDictionary[inLineIndex].PointFill[i] == 1)
                    {
                        pointIndex.Add(i);
                    }
                }

                return pointIndex;
            }

            List<int> listMaxLineWeight = GetEvolvedList(localLineWeightList);
            int lineIndex = GetRandIndex(listMaxLineWeight);
            List<int> evolvedPointScoreList = GetEvolvedPointList(lineIndex);
            int pointIndex = GetRandIndex(evolvedPointScoreList); ///TODO Возникает не постоянная ошибка

            return inputPlayField.LineDictionary[lineIndex].CoordsList[pointIndex];
        }

        ///Делаем ход с проверкой поля на условную пустоту - за него отвечает 1
        bool SetMotion()
        {
            Coords inCoord = CoordStepPoint(); ///TODO Возникает не постоянная ошибка
            if (inputPlayField[inCoord.xCoord, inCoord.yCoord] == 1)
            {
                if (_setPlayerIcon == PlayerIcon.O)
                {
                    inputPlayField[inCoord.xCoord, inCoord.yCoord] = BallO;
                }
                else if (_setPlayerIcon == PlayerIcon.X)
                {
                    inputPlayField[inCoord.xCoord, inCoord.yCoord] = BallX;
                }
            }


            return true;
        }

        return SetMotion(); ///TODO Возникает не постоянная ошибка
    }
}