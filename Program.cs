namespace TicTacToe
{
    internal class Program
    {
        const int GRID_SIZE = 3;
        static char[,] grid = new char[GRID_SIZE, GRID_SIZE];

        static void Main(string[] args)
        {
            // Step 1: Initialize the grid
            InitializeGrid();

            // Step 2: Display the grid
            DisplayGrid();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        // Method to initialize the grid with empty spaces
        static void InitializeGrid()
        {
            for (int i = 0; i < GRID_SIZE; i++)
            {
                for (int j = 0; j < GRID_SIZE; j++)
                {
                    grid[i, j] = '-'; // Initialize each cell with '-'
                }
            }
        }

        // Method to display the grid in the console
        static void DisplayGrid()
        {
            for (int i = 0; i < GRID_SIZE; i++)
            {
                for (int j = 0; j < GRID_SIZE; j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine(); // Move to the next line after each row
            }
        }
    }
}
