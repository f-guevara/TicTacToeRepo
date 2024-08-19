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
    public bool IsPositionAvailable(int position)
    {
        int row = position / 3;
        int col = position % 3;
        return _grid[row, col] == ' '; // Returns true if the position is empty
    }


    public int GetAIMove()
    {
        // 1. Win: If AI can win, take that move
        int winningMove = FindWinningMove('O');
        if (winningMove != -1)
            return winningMove;

        // 2. Block: If player is about to win, block them
        int blockingMove = FindWinningMove('X');
        if (blockingMove != -1)
            return blockingMove;

        // 3. Take center if available
        if (_grid[1, 1] == ' ')
            return 4;  // Center position is 4 (1,1)

        // 4. Take a corner if available
        int cornerMove = GetCornerMove();
        if (cornerMove != -1)
            return cornerMove;

        // 5. Take a random move
        return GetRandomMove();
    }

    private int FindWinningMove(char symbol)
    {
        for (int i = 0; i < 9; i++)
        {
            if (_grid[i / 3, i % 3] == ' ')
            {
                _grid[i / 3, i % 3] = symbol;
                bool isWin = IsWin();
                Console.WriteLine($"Testing move at {i}: {(isWin ? "Winning move!" : "Not a win")}");
                _grid[i / 3, i % 3] = ' '; // Undo move

                if (isWin)
                    return i;
            }
        }
        return -1;
    }

    private int GetCornerMove()
    {
        int[] corners = { 0, 2, 6, 8 };
        foreach (int corner in corners)
        {
            if (_grid[corner / 3, corner % 3] == ' ')
                return corner;
        }
        return -1;
    }

    private int GetRandomMove()
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

