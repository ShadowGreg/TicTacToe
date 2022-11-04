namespace TicTacToe;

public interface IMotion
{
    public virtual bool StepMotions(
        int motionColumn,
        int motionRow,
        PlayField inputPlayField
    )
    {
        return true;
    }
}