public static class TicTacToeGame
{
    private const int GRID_SIZE = 3;
    private const int TOTAL_POSITIONS = GRID_SIZE * GRID_SIZE;
    private const char PLAYER_1_SYMBOL = 'X';
    private const char PLAYER_2_SYMBOL = 'O';
    private const char EMPTY_SYMBOL = ' ';

    // Public property to expose GRID_SIZE
    public static int GRID_SIZE_VALUE => GRID_SIZE;

    public static char[] InitializeGrid()
    {
        char[] grid = new char[TOTAL_POSITIONS];
        for (int i = 0; i < TOTAL_POSITIONS; i++)
        {
            grid[i] = EMPTY_SYMBOL;
        }
        return grid;
    }

    public static bool IsPositionAvailable(char[] grid, int position)
    {
        return grid[position] == EMPTY_SYMBOL;
    }

    public static void MakeMove(char[] grid, int position, char symbol)
    {
        grid[position] = symbol;
    }

    public static bool CheckWin(char[] grid, char symbol)
    {
        for (int i = 0; i < GRID_SIZE; i++)
        {
            if (grid[i * GRID_SIZE] == symbol && grid[i * GRID_SIZE + 1] == symbol && grid[i * GRID_SIZE + 2] == symbol)
                return true;
            if (grid[i] == symbol && grid[i + GRID_SIZE] == symbol && grid[i + 2 * GRID_SIZE] == symbol)
                return true;
        }
        if (grid[0] == symbol && grid[4] == symbol && grid[8] == symbol)
            return true;
        if (grid[2] == symbol && grid[4] == symbol && grid[6] == symbol)
            return true;

        return false;
    }

    public static bool IsDraw(char[] grid)
    {
        foreach (char cell in grid)
        {
            if (cell == EMPTY_SYMBOL)
                return false;
        }
        return true;
    }

    public static char GetCurrentSymbol(bool isPlayerOneTurn)
    {
        return isPlayerOneTurn ? PLAYER_1_SYMBOL : PLAYER_2_SYMBOL;
    }
}

