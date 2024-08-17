namespace TicTacToe
{
    internal class Program
    {
        //constants
        const int GRID_SIZE = 3;
        const char EMPTY_CELL = '-'; 

        static char[,] grid = new char[GRID_SIZE, GRID_SIZE];

        static void Main(string[] args)
        {
            InitializeGrid();
            char currentPlayer = 'X';

            for (int i = 0; i < GRID_SIZE * GRID_SIZE; i++) // Maximum of 9 moves
            {
                Console.Clear();
                DisplayGrid();

                var (row, col) = GetPlayerMove();
                PlaceMove(row, col, currentPlayer);

                // Alternate between players
                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            }

            Console.WriteLine("Game Over! Press any key to exit.");
            Console.ReadKey();
        }


        // Method to initialize the grid with empty spaces
        static void InitializeGrid()
        {
            for (int i = 0; i < GRID_SIZE; i++)
            {
                for (int j = 0; j < GRID_SIZE; j++)
                {
                    grid[i, j] = EMPTY_CELL; // Initialize each cell with '-'
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

        static (int, int) GetPlayerMove()
        {
            int row = -1, col = -1;
            bool validInput = false;

            while (!validInput)
            {
                try
                {
                    Console.Write($"Enter the row (1-{GRID_SIZE}): ");
                    row = int.Parse(Console.ReadLine()) - 1; // Convert to 0-based index

                    Console.Write($"Enter the column (1-{GRID_SIZE}): ");
                    col = int.Parse(Console.ReadLine()) - 1; // Convert to 0-based index

                    if (row >= 0 && row < GRID_SIZE && col >= 0 && col < GRID_SIZE && grid[row, col] == EMPTY_CELL)
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid move! The cell is already occupied or out of range. Try again.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }
            }

            return (row, col);
        }


        static void PlaceMove(int row, int col, char player)
        {
            grid[row, col] = player;
        }

    }
}
