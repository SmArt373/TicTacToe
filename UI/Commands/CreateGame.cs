using TicTacToe.GameAccounts;
using TicTacToe.Service.Interface;

namespace TicTacToe.UI.Commands
{
    public class CreateGame : IUserInterface
    {
        private readonly IGameAccountService _gameAccountService;
        private readonly IGameService _gameService;

        public CreateGame(IGameAccountService gameAccountService, IGameService gameService)
        {
            _gameAccountService = gameAccountService;
            _gameService = gameService;
        }

        public string ShowInfo()
        {
            return "Start a new game";
        }

        public void Action()
        {
            var players = _gameAccountService.GetAllPlayers();
            if (players.Length < 2)
            {
                Console.WriteLine("Недостатньо гравців для початку гри. Потрібно щонайменше 2 гравці.");
                return;
            }

            Console.WriteLine("Виберіть першого гравця:");
            for (int i = 0; i < players.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {players[i].Username}");
            }
            int player1Index = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Виберіть другого гравця:");
            for (int i = 0; i < players.Length; i++)
            {
                if (i != player1Index)
                    Console.WriteLine($"{i + 1}. {players[i].Username}");
            }
            int player2Index = int.Parse(Console.ReadLine()) - 1;

            GameAccount player1 = players[player1Index];
            GameAccount player2 = players[player2Index];

            Console.Write("Виберіть тип гри (standard/training): ");
            string gameType = Console.ReadLine();

            int rating = 0;
            if (gameType.ToLower() == "standard")
            {
                Console.Write("Введіть рейтинг гри: ");
                int.TryParse(Console.ReadLine(), out rating);
            }

            _gameService.StartNewGame(player1, player2, gameType, rating);
            Console.WriteLine($"Гра починається між {player1.Username} та {player2.Username}");

            PlayGame();
        }

        private void PlayGame()
        {
            while (true)
            {
                DisplayBoard();

                string currentPlayerName = _gameService.GetCurrentPlayerName();
                Console.WriteLine($"Хід гравця {currentPlayerName} ({_gameService.GetCurrentPlayer()}).");
                Console.Write("Введіть позицію (1-9) або 'q' для виходу: ");
                string input = Console.ReadLine();

                if (input.ToLower() == "q")
                {
                    break;
                }

                if (int.TryParse(input, out int position))
                {
                    if (_gameService.MakeMove(position))
                    {
                        if (_gameService.CheckWin(out char winner))
                        {
                            DisplayBoard();
                            string winnerName = _gameService.GetCurrentPlayerName();
                            Console.WriteLine($"Гравець {winnerName} переміг!");

                            _gameService.EndGame(winner == 'X');
                            break;
                        }
                        else if (_gameService.IsBoardFull())
                        {
                            DisplayBoard();
                            Console.WriteLine("Нічия!");

                            _gameService.EndGame(false);
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Невірний хід. Спробуйте ще раз.");
                    }
                }
                else
                {
                    Console.WriteLine("Невірне введення. Спробуйте ще раз.");
                }
            }
        }

        private void DisplayBoard()
        {
            char[] board = _gameService.GetBoard();
            Console.WriteLine("\n-------------");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"| {board[i * 3]} | {board[i * 3 + 1]} | {board[i * 3 + 2]} |");
                Console.WriteLine("-------------");
            }
        }
    }
}

