namespace TicTacToe;

public class DTO
{
    private List<Coords> coordsList;

    private List<int> pointFill;
    private List<int> pointScoreList;
    public DTO(
        List<Coords> inCoordsList,
        int inLineWeight,
        List<int> inPointFill,
        List<int> inPointScoreList
    )
    {
        coordsList     = inCoordsList;
        LineWeight     = inLineWeight;
        pointFill      = inPointFill;
        pointScoreList = inPointScoreList;
    }

    public List<Coords> CoordsList
    {
        get => coordsList;
        set => coordsList = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int LineWeight { get; set; }

    public List<int> PointFill
    {
        get => pointFill;
        set => pointFill = value ?? throw new ArgumentNullException(nameof(value));
    }

    public List<int> PointScoreList
    {
        get => pointScoreList;
        set => pointScoreList = value ?? throw new ArgumentNullException(nameof(value));
    }
}

public class LineDictionary
{
    public Dictionary<int, DTO> GetLineDictionary { get; set; }
}

public class Coords
{
    public int xCoord { get; set; }
    public int yCoord { get; set; }
}
