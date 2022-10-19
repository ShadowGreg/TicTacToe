namespace TicTacToe;

public interface IMotion
{
    public bool StepMotions(
        int motionColumn,
        int motionRow,
        PlayerIcon playerPosition,
        PlayField inputPlayField
    );
}