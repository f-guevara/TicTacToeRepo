
namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Step 1: Initialize the grid (3x3)
            char[,] grid = new char[3, 3];

            // Fill the grid with empty spaces
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    grid[row, col] = ' ';
                }
            }

            // Step 2: Display the grid using the UI class
            ConsoleUI.DisplayGrid(grid);

            // Step 3: Keep the console open
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}

