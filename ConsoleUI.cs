public static class ConsoleUI
{
    private const int MIN_MOVE = 1;

    public static void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }

    public static string GetInput(string prompt)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();
        return input ?? string.Empty;
    }

    public static void DisplayGrid(char[] grid)
    {
        int gridSize = TicTacToeGame.GRID_SIZE_VALUE;
        for (int row = 0; row < gridSize; row++)
        {
            for (int col = 0; col < gridSize; col++)
            {
                Console.Write(grid[row * gridSize + col]);
                if (col < gridSize - 1)
                    Console.Write(" | ");
            }
            Console.WriteLine();
            if (row < gridSize - 1)
                Console.WriteLine("---------");
        }
    }

    public static int GetPlayerMove(int TOTAL_POSITIONS)
    {
        while (true)
        {
            string input = GetInput($"Enter your move (1-{TOTAL_POSITIONS}): ");
            if (int.TryParse(input, out int move) && move >= 1 && move <= TOTAL_POSITIONS)
                return move - 1; // Adjust for 0-based index

            DisplayMessage($"Invalid input. Please enter a number between {MIN_MOVE} and {TOTAL_POSITIONS}.");
        }
    }
}
