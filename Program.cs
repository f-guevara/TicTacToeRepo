namespace TicTacToe
{
    internal class Program
    {
        const int GRID_SIZE = 3;
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

        static (int, int) GetPlayerMove()
        {
            int row = -1, col = -1;
            bool validInput = false;

            while (!validInput)
            {
                Console.Write("Enter the row (0-2): ");
                row = int.Parse(Console.ReadLine());

                Console.Write("Enter the column (0-2): ");
                col = int.Parse(Console.ReadLine());

                if (row >= 0 && row < GRID_SIZE && col >= 0 && col < GRID_SIZE && grid[row, col] == '-')
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid move! Try again.");
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
