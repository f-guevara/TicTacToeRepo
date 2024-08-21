namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string PLAYER_1_WINS = "Player 1";
            const string PLAYER_2_WINS = "Player 2";
            const string AI_WINS = "AI";   //just add this comment to make a commit

            char[] grid = TicTacToeGame.InitializeGrid();
            bool isPlayerOneTurn = true;
            bool isPlayingAgainstAI = ConsoleUI.AskForGameMode(); // Ask if the player wants to play against AI

            while (true)
            {
                Console.Clear();
                ConsoleUI.DisplayGrid(grid);

                int move;
                if (isPlayerOneTurn || !isPlayingAgainstAI)
                {
                    move = ConsoleUI.GetPlayerMove(TicTacToeGame.GRID_SIZE_VALUE * TicTacToeGame.GRID_SIZE_VALUE);
                }
                else
                {
                    move = TicTacToeGame.GetBestMove(grid);
                    ConsoleUI.DisplayMessage($"AI chose position {move + 1}");
                }

                if (TicTacToeGame.IsPositionAvailable(grid, move))
                {
                    char currentSymbol = TicTacToeGame.GetCurrentSymbol(isPlayerOneTurn);
                    TicTacToeGame.MakeMove(grid, move, currentSymbol);

                    if (TicTacToeGame.CheckWin(grid, currentSymbol))
                    {
                        Console.Clear();
                        ConsoleUI.DisplayGrid(grid);
                        ConsoleUI.DisplayMessage($"{(isPlayerOneTurn ? PLAYER_1_WINS : isPlayingAgainstAI ? AI_WINS : PLAYER_2_WINS)} wins!");
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




