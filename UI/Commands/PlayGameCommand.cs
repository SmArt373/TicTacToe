using TicTacToe.GameAccounts;
using TicTacToe.Service.Interface;

namespace TicTacToe.UI.Commands
{
    public class PlayGameCommand : ICommand
    {
        private readonly IGameAccountService _accountService;
        private readonly IGameService _gameService;
        private readonly GameAccount _currentPlayer;

        public PlayGameCommand(IGameAccountService accountService, IGameService gameService, GameAccount currentPlayer)
        {
            _accountService = accountService;
            _gameService = gameService;
            _currentPlayer = currentPlayer;
        }

        public void Execute()
        {
            if (_currentPlayer == null)
            {
                Console.WriteLine("Спочатку потрібно увійти в систему!");
                return;
            }

            string[] players = _accountService.GetPlayersForGame(_currentPlayer.Username);
            if (players == null)
            {
                Console.WriteLine("Недостатньо гравців для початку гри.");
                return;
            }

            Console.Write("Виберіть тип гри (standard/training): ");
            string gameType = Console.ReadLine();

            int rating = 0;
            if (gameType.ToLower() == "standard")
            {
                Console.Write("Введіть рейтинг гри: ");
                int.TryParse(Console.ReadLine(), out rating);
            }

            var player1 = _accountService.GetPlayerStats(players[0]);
            var player2 = _accountService.GetPlayerStats(players[1]);

            _gameService.StartNewGame(player1, player2, gameType, rating);
            Console.WriteLine($"Гра починається між {players[0]} та {players[1]}");

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
                            string winnerName = winner == 'X' ? players[0] : players[1];
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

        public void ShowInfo()
        {
            Console.WriteLine("Грати в гру:");
            Console.WriteLine("- Виберіть тип гри (standard/training)");
            Console.WriteLine("- Для стандартної гри введіть рейтинг гри");
            Console.WriteLine("Починає нову гру в хрестики-нулики з вибраним опонентом.");
            Console.WriteLine("Ви можете робити ходи, вводячи числа від 1 до 9, що відповідають позиціям на дошці.");
        }
    }
}

