using TicTacToe.Service.Interface;

namespace TicTacToe.UI.Commands
{
    public class ShowAllPlayersCommand : ICommand
    {
        private readonly IGameAccountService _accountService;

        public ShowAllPlayersCommand(IGameAccountService accountService)
        {
            _accountService = accountService;
        }

        public void Execute()
        {
            var players = _accountService.GetAllPlayers();
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

        public void ShowInfo()
        {
            Console.WriteLine("Показати всіх гравців:");
            Console.WriteLine("Відображає список всіх зареєстрованих гравців та їх поточний рейтинг.");
        }
    }
}

