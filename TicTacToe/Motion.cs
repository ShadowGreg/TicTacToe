namespace TicTacToe;

public class Motion: IMotion
{
    private const    int        BallO = -1;
    private const    int        BallX = 1;
    private readonly PlayerIcon _playerPosition;

    public Motion(PlayerIcon inputIcon)
    {
        _playerPosition = inputIcon;
    }
    public bool StepMotions(
        int motionColumn,
        int motionRow,
        PlayField inputPlayField
    )
    {
        if (inputPlayField[motionColumn, motionRow] == 0)
        {
            if (_playerPosition == PlayerIcon.O)
            {
                inputPlayField[motionColumn, motionRow] = BallO;
            }
            else if (_playerPosition == PlayerIcon.X)
            {
                inputPlayField[motionColumn, motionRow] = BallX;
            }

            return true;
        }

        return false;
    }
}