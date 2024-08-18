// ConsoleUI.cs
public static class ConsoleUI
{
    public static void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }

    public static string GetInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

    public static void DisplayGrid(char[,] grid)
    {
        for (int row = 0; row < grid.GetLength(0); row++)
        {
            for (int col = 0; col < grid.GetLength(1); col++)
            {
                Console.Write(grid[row, col]);
                if (col < grid.GetLength(1) - 1)
                    Console.Write(" | ");
            }
            Console.WriteLine();
            if (row < grid.GetLength(0) - 1)
                Console.WriteLine("---------");
        }
    }

    public static int GetPlayerMove(string playerName)
    {
        while (true)
        {
            string input = GetInput($"{playerName}, enter your move (1-9): ");
            if (int.TryParse(input, out int move) && move >= 1 && move <= 9)
                return move - 1; // Adjust for 0-based index
            else
                DisplayMessage("Invalid input. Please enter a number between 1 and 9.");
        }
    }
}
