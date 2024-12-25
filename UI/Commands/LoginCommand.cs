using TicTacToe.GameAccounts;
using TicTacToe.Service.Interface;

namespace TicTacToe.UI.Commands
{
    public class LoginCommand : IUserInterface
    {
        private readonly IGameAccountService _accountService;
        private GameAccount _currentPlayer;

        public LoginCommand(IGameAccountService accountService, ref GameAccount currentPlayer)
        {
            _accountService = accountService;
            _currentPlayer = currentPlayer;
        }

        public string ShowInfo()
        {
            return "Login to an existing account";
        }

        public void Action()
        {
            Console.Write("Введіть ім'я гравця: ");
            string username = Console.ReadLine();
            Console.Write("Введіть пароль: ");
            string password = ReadPassword();

            var player = _accountService.Login(username, password);
            if (player != null)
            {
                _currentPlayer = player;
                Console.WriteLine($"Ласкаво просимо, {username}!");
            }
            else
            {
                Console.WriteLine("Невірне ім'я користувача або пароль.");
            }
        }

        private string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
        }
    }
}

