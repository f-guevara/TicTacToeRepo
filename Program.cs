namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool playingAgainstAI = TicTacToeGame.IsPlayingAgainstAI();
            var game = new TicTacToeGame(playingAgainstAI);
            bool isPlayerOneTurn = true;

            while (true)
            {
                Console.Clear();
                ConsoleUI.DisplayGrid(game.GetGrid());

                string currentPlayer = isPlayerOneTurn ? "Player 1" : "Player 2";
                char currentSymbol = isPlayerOneTurn ? 'X' : 'O';

                int move;
                if (isPlayerOneTurn || !playingAgainstAI)
                {
                    move = ConsoleUI.GetPlayerMove(currentPlayer, game);
                }
                else
                {
                    move = game.GetAIMove();
                    ConsoleUI.DisplayMessage($"AI chose position {move + 1}");
                }

                game.MakeMove(move, currentSymbol);

                if (game.IsWin())
                {
                    Console.Clear();
                    ConsoleUI.DisplayGrid(game.GetGrid());
                    ConsoleUI.DisplayMessage($"{currentPlayer} wins!");
                    break;
                }

                if (game.IsDraw())
                {
                    Console.Clear();
                    ConsoleUI.DisplayGrid(game.GetGrid());
                    ConsoleUI.DisplayMessage("The game is a draw!");
                    break;
                }

                isPlayerOneTurn = !isPlayerOneTurn;
            }
            ConsoleUI.DisplayMessage("Press any key to exit...");
            Console.ReadKey();
        }
    }

}


