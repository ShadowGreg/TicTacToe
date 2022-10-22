namespace TicTacToe;

public class Motion: IMotion
{
    private const int BallO = -2;
    private const int BallX = 2;

    private readonly PlayerIcon _playerPosition;

    public Motion(PlayerIcon inputIcon)
    {
        _playerPosition = inputIcon;
    }
    public bool StepMotions(
        int motionRow,
        int motionColumn,
        PlayField inputPlayField
    )
    {
        if (inputPlayField[motionRow, motionColumn] == 1)
        {
            if (_playerPosition == PlayerIcon.O)
            {
                inputPlayField[motionRow, motionColumn] = BallO;
            }
            else if (_playerPosition == PlayerIcon.X)
            {
                inputPlayField[motionRow, motionColumn] = BallX;
            }

            return true;
        }

        return false;
    }
}