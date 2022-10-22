using TicTacToe;

namespace UnitTests;

public class DTOTest
{
    [Test]
    public void DTO_create_Test()
    {
        var inCoords1 = new Coords { xCoord = 1, yCoord = 2 };
        var inCoords2 = new Coords { xCoord = 0, yCoord = 0 };
        List<Coords> inCoordsList = new List<Coords> { inCoords1, inCoords2 };
        int inLineWeight = 21;
        List<int> inPointFill = new List<int> { 1, 2, 3 };
        List<int> inPointScoreList = new List<int> { 1, 2, 3 };
        var testDTO = new DTO(inCoordsList, inLineWeight, inPointFill, inPointScoreList);
        Assert.That(testDTO, Is.Not.Null);
    }
    [Test]
    public void CoordsList_Get_Set_Test()
    {
        var inCoords1 = new Coords { xCoord = 1, yCoord = 2 };
        var inCoords2 = new Coords { xCoord = 0, yCoord = 0 };
        List<Coords> inCoordsList = new List<Coords> { inCoords1, inCoords2 };
        int inLineWeight = 21;
        List<int> inPointFill = new List<int> { 1, 2, 3 };
        List<int> inPointScoreList = new List<int> { 1, 2, 3 };
        var testDTO = new DTO(inCoordsList, inLineWeight, inPointFill, inPointScoreList);
        testDTO.CoordsList = new List<Coords> { inCoords2, inCoords1 };
        List<Coords> testList = testDTO.CoordsList;
        Assert.AreEqual(1, testList[1].xCoord);
    }
    [Test]
    public void LineWeight_Test()
    {
        var inCoords1 = new Coords { xCoord = 1, yCoord = 2 };
        var inCoords2 = new Coords { xCoord = 0, yCoord = 0 };
        List<Coords> inCoordsList = new List<Coords> { inCoords1, inCoords2 };
        int inLineWeight = 21;
        List<int> inPointFill = new List<int> { 1, 2, 3 };
        List<int> inPointScoreList = new List<int> { 1, 2, 3 };
        var testDTO = new DTO(inCoordsList, inLineWeight, inPointFill, inPointScoreList);
        testDTO.LineWeight = 32;
        Assert.AreEqual(32, testDTO.LineWeight);
    }
    [Test]
    public void PointFill_Test()
    {
        var inCoords1 = new Coords { xCoord = 1, yCoord = 2 };
        var inCoords2 = new Coords { xCoord = 0, yCoord = 0 };
        List<Coords> inCoordsList = new List<Coords> { inCoords1, inCoords2 };
        int inLineWeight = 21;
        List<int> inPointFill1 = new List<int> { 1, 2, 3 };
        List<int> inPointScoreList = new List<int> { 1, 2, 3 };
        var testDTO = new DTO(inCoordsList, inLineWeight, inPointFill1, inPointScoreList);
        testDTO.PointFill = new List<int> { 5, 5, 5 };
        Assert.AreEqual(5, testDTO.PointFill[1]);
    }
    [Test]
    public void PointScoreList_Test()
    {
        var inCoords1 = new Coords { xCoord = 1, yCoord = 2 };
        var inCoords2 = new Coords { xCoord = 0, yCoord = 0 };
        List<Coords> inCoordsList = new List<Coords> { inCoords1, inCoords2 };
        int inLineWeight = 21;
        List<int> inPointFill1 = new List<int> { 1, 2, 3 };
        List<int> inPointScoreList = new List<int> { 1, 2, 3 };
        var testDTO = new DTO(inCoordsList, inLineWeight, inPointFill1, inPointScoreList);
        testDTO.PointScoreList = new List<int> { 5, 5, 5 };
        Assert.AreEqual(5, testDTO.PointScoreList[1]);
    }
}