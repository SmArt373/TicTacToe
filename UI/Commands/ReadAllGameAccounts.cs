using TicTacToe.Service.Interface;

namespace TicTacToe.UI.Commands
{
    public class ReadAllGameAccounts : IUserInterface
    {
        private readonly IGameAccountService _gameAccountService;

        public ReadAllGameAccounts(IGameAccountService gameAccountService)
        {
            _gameAccountService = gameAccountService;
        }

        public string ShowInfo()
        {
            return "Show all players";
        }

        public void Action()
        {
            var players = _gameAccountService.GetAllPlayers();
            if (players.Length == 0)
            {
                Console.WriteLine("Немає зареєстрованих гравців.");
                return;
            }

            Console.WriteLine("\nСписок всіх гравців:");
            foreach (var player in players)
            {
                Console.WriteLine($"Гравець: {player.Username}");
                Console.WriteLine($"Рейтинг: {player.CurrentRating}");
                Console.WriteLine();
            }
        }
    }
}

