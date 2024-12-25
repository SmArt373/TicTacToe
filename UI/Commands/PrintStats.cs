using TicTacToe.Repository.Interface;
using TicTacToe.Service.Interface;

namespace TicTacToe.UI.Commands
{
    public class PrintStats : IUserInterface
    {
        private readonly IGameAccountService _gameAccountService;
        private readonly IGameRepository _gameRepository;

        public PrintStats(IGameAccountService gameAccountService, IGameRepository gameRepository)
        {
            _gameAccountService = gameAccountService;
            _gameRepository = gameRepository;
        }

        public string ShowInfo()
        {
            return "Show player statistics";
        }

        public void Action()
        {
            Console.Write("Введіть ім'я гравця для перегляду статистики: ");
            string username = Console.ReadLine();

            var player = _gameAccountService.GetPlayerStats(username);
            if (player != null)
            {
                var games = _gameRepository.GetPlayerGames(player.Id);

                Console.WriteLine($"\nСтатистика гравця {player.Username}:");
                Console.WriteLine($"Рейтинг: {player.CurrentRating}");

                if (games.Any())
                {
                    Console.WriteLine("\nІсторія ігор:");
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine("| Опонент        | Результат  | Рейтинг | Тип гри     |");
                    Console.WriteLine("----------------------------------------------------");

                    foreach (var game in games)
                    {
                        string opponentName = game.Player1.Id == player.Id ? game.Player2.Username : game.Player1.Username;
                        bool isWin = (game.IsPlayer1Win && game.Player1.Id == player.Id) || (!game.IsPlayer1Win && game.Player2.Id == player.Id);
                        int ratingChange = game.Rating;

                        string result = isWin ? "Перемога" : "Поразка";
                        string ratingChangeStr = ratingChange >= 0 ?
                            $"+{ratingChange}" :
                            ratingChange.ToString();

                        Console.WriteLine($"| {opponentName,-13} | {result,-9} | {ratingChangeStr,7} | {game.GameType,-10} |");
                    }
                    Console.WriteLine("----------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("\nІсторія ігор порожня.");
                }
            }
            else
            {
                Console.WriteLine("Гравця не знайдено.");
            }
        }
    }
}

