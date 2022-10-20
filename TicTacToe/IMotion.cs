namespace TicTacToe;

public interface IMotion
{
    public bool StepMotions(
        int motionColumn,
        int motionRow,
        PlayField inputPlayField
    );
}