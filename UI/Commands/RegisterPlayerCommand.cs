using TicTacToe.Service.Interface;

namespace TicTacToe.UI.Commands
{
    public class RegisterPlayerCommand : ICommand
    {
        private readonly IGameAccountService _accountService;

        public RegisterPlayerCommand(IGameAccountService accountService)
        {
            _accountService = accountService;
        }

        public void Execute()
        {
            Console.Write("Введіть ім'я гравця: ");
            string username = Console.ReadLine();
            Console.Write("Введіть пароль: ");
            string password = ReadPassword();
            Console.Write("Введіть тип аккаунту (standard/loseless/vip): ");
            string accountType = Console.ReadLine();

            if (_accountService.CreateAccount(username, password, accountType))
            {
                Console.WriteLine("Гравець успішно зареєстрований!");
            }
            else
            {
                Console.WriteLine("Це ім'я вже зайняте. Спробуйте інше.");
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

        public void ShowInfo()
        {
            Console.WriteLine("Реєстрація нового гравця:");
            Console.WriteLine("- Введіть ім'я користувача");
            Console.WriteLine("- Введіть пароль");
            Console.WriteLine("- Виберіть тип аккаунту (standard/loseless/vip)");
            Console.WriteLine("Створює новий обліковий запис гравця з вказаними даними.");
        }
    }
}

