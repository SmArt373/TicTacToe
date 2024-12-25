using TicTacToe.Repository.Interface;
using TicTacToe.Service.Interface;

namespace TicTacToe.UI.Commands
{
    public class ShowPlayerStatsCommand : ICommand
    {
        private readonly IGameAccountService _accountService;
        private readonly IGameRepository _gameRepository;

        public ShowPlayerStatsCommand(IGameAccountService accountService, IGameRepository gameRepository)
        {
            _accountService = accountService;
            _gameRepository = gameRepository;
        }

        public void Execute()
        {
            Console.Write("Введіть ім'я гравця для перегляду статистики: ");
            string username = Console.ReadLine();

            var player = _accountService.GetPlayerStats(username);
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

        public void ShowInfo()
        {
            Console.WriteLine("Статистика гравця:");
            Console.WriteLine("- Введіть ім'я гравця");
            Console.WriteLine("Показує детальну статистику вказаного гравця, включаючи:");
            Console.WriteLine("- Поточний рейтинг");
            Console.WriteLine("- Історію ігор (опонент, результат, зміна рейтингу, тип гри)");
        }
    }
}

