namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] grid = TicTacToeGame.InitializeGrid();
            bool isPlayerOneTurn = true;

            while (true)
            {
                Console.Clear();
                ConsoleUI.DisplayGrid(grid);

                int move = ConsoleUI.GetPlayerMove(TicTacToeGame.GRID_SIZE_VALUE * TicTacToeGame.GRID_SIZE_VALUE);

                if (TicTacToeGame.IsPositionAvailable(grid, move))
                {
                    char currentSymbol = TicTacToeGame.GetCurrentSymbol(isPlayerOneTurn);
                    TicTacToeGame.MakeMove(grid, move, currentSymbol);

                    if (TicTacToeGame.CheckWin(grid, currentSymbol))
                    {
                        Console.Clear();
                        ConsoleUI.DisplayGrid(grid);
                        ConsoleUI.DisplayMessage($"{(isPlayerOneTurn ? "Player 1" : "Player 2")} wins!");
                        break;
                    }

                    if (TicTacToeGame.IsDraw(grid))
                    {
                        Console.Clear();
                        ConsoleUI.DisplayGrid(grid);
                        ConsoleUI.DisplayMessage("The game is a draw!");
                        break;
                    }

                    isPlayerOneTurn = !isPlayerOneTurn;
                }
                else
                {
                    ConsoleUI.DisplayMessage("Position already taken. Please choose another.");
                }
            }
            ConsoleUI.DisplayMessage("Press any key to exit...");
            Console.ReadKey();
        }
    }
}



