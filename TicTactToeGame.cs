// TicTacToeGame.cs
public class TicTacToeGame
{
    private readonly char[,] _grid;
    private readonly char _player1Symbol;
    private readonly char _player2Symbol;
    private readonly bool _isPlayingAgainstAI;

    public TicTacToeGame(bool isPlayingAgainstAI)
    {
        _grid = new char[3, 3];
        for (int row = 0; row < 3; row++)
            for (int col = 0; col < 3; col++)
                _grid[row, col] = ' ';

        _player1Symbol = 'X';
        _player2Symbol = 'O';
        _isPlayingAgainstAI = isPlayingAgainstAI;
    }

    public void MakeMove(int position, char symbol)
    {
        int row = position / 3;
        int col = position % 3;
        _grid[row, col] = symbol;
    }

    public bool IsWin()
    {
        return CheckRows() || CheckColumns() || CheckDiagonals();
    }

    public bool IsDraw()
    {
        foreach (char cell in _grid)
        {
            if (cell == ' ')
                return false;
        }
        return true;
    }

    public char[,] GetGrid()
    {
        return _grid;
    }

    public static bool IsPlayingAgainstAI()
    {
        while (true)
        {
            string input = ConsoleUI.GetInput("Do you want to play against the AI? (y/n): ");
            if (input.ToLower() == "y")
                return true;
            else if (input.ToLower() == "n")
                return false;
            else
                ConsoleUI.DisplayMessage("Invalid input. Please enter 'y' or 'n'.");
        }
    }

    public int GetAIMove()
    {
        Random random = new Random();
        int move;
        do
        {
            move = random.Next(0, 9);
        } while (_grid[move / 3, move % 3] != ' ');
        return move;
    }

    private bool CheckRows()
    {
        for (int row = 0; row < 3; row++)
        {
            if (_grid[row, 0] == _grid[row, 1] && _grid[row, 1] == _grid[row, 2] && _grid[row, 0] != ' ')
                return true;
        }
        return false;
    }

    private bool CheckColumns()
    {
        for (int col = 0; col < 3; col++)
        {
            if (_grid[0, col] == _grid[1, col] && _grid[1, col] == _grid[2, col] && _grid[0, col] != ' ')
                return true;
        }
        return false;
    }

    private bool CheckDiagonals()
    {
        return (_grid[0, 0] == _grid[1, 1] && _grid[1, 1] == _grid[2, 2] && _grid[0, 0] != ' ') ||
               (_grid[0, 2] == _grid[1, 1] && _grid[1, 1] == _grid[2, 0] && _grid[0, 2] != ' ');
    }
}

