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

    // AI logic
    public static int GetBestMove(char[] grid)
    {
        // Check if AI can win or needs to block the player
        int winningMove = FindBestMove(grid, PLAYER_2_SYMBOL); // Priority 1: AI tries to win
        if (winningMove != -1) return winningMove;

        int blockingMove = FindBestMove(grid, PLAYER_1_SYMBOL); // Priority 2: AI blocks player
        if (blockingMove != -1) return blockingMove;

        // Priority 3: Take the center if available
        int centerPosition = GRID_SIZE_VALUE * GRID_SIZE_VALUE / 2;
        if (IsPositionAvailable(grid, centerPosition))
        {
            return centerPosition;
        }

        // Priority 4: Take any available corner
        int[] corners = GetCornerPositions(GRID_SIZE_VALUE);
        foreach (int corner in corners)
        {
            if (IsPositionAvailable(grid, corner))
            {
                return corner;
            }
        }

        // Priority 5: Take any available position
        for (int i = 0; i < TOTAL_POSITIONS; i++)
        {
            if (IsPositionAvailable(grid, i))
            {
                return i;
            }
        }

        return -1; // Should never happen as we assume AI only calls this when it can make a move
    }

    private static int[] GetCornerPositions(int gridSize)
    {
        return new int[]
        {
        0,                           // Top-left corner
        gridSize - 1,                // Top-right corner
        gridSize * (gridSize - 1),   // Bottom-left corner
        gridSize * gridSize - 1      // Bottom-right corner
        };
    }

    private static int FindBestMove(char[] grid, char symbol)
    {
        for (int i = 0; i < TOTAL_POSITIONS; i++)
        {
            if (IsPositionAvailable(grid, i))
            {
                grid[i] = symbol;
                if (CheckWin(grid, symbol))
                {
                    grid[i] = EMPTY_SYMBOL; // Undo the move
                    return i; // Return the best move
                }
                grid[i] = EMPTY_SYMBOL; // Undo the move
            }
        }
        return -1; // No winning/blocking move found
    }


}

