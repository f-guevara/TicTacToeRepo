// ConsoleUI.cs
public static class ConsoleUI
{
    public static void DisplayGrid(char[,] grid)
    {
        for (int row = 0; row < grid.GetLength(0); row++)
        {
            for (int col = 0; col < grid.GetLength(1); col++)
            {
                Console.Write(grid[row, col]);
                if (col < grid.GetLength(1) - 1)
                    Console.Write(" | "); // Display column separator
            }
            Console.WriteLine(); // New line after each row

            if (row < grid.GetLength(0) - 1)
                Console.WriteLine("---------"); // Display row separator
        }
    }
}
