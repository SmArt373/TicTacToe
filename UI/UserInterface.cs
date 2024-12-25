using System;
using System.Collections.Generic;
using TicTacToe.UI.Commands;
using TicTacToe.GameAccounts;
using TicTacToe.Repository.Interface;
using TicTacToe.Service.Interface;

namespace TicTacToe.UI
{
    public class UserInterface
    {
        private readonly List<IUserInterface> commands;
        private GameAccount currentPlayer;

        public UserInterface(IGameAccountService gameAccountService, IGameService gameService, IGameRepository gameRepository)
        {
            currentPlayer = null;
            commands = new List<IUserInterface>
            {
                new ReadAllGameAccounts(gameAccountService),
                new CreateGameAccount(gameAccountService),
                new LoginCommand(gameAccountService, ref currentPlayer),
                new CreateGame(gameAccountService, gameService),
                new PrintStats(gameAccountService, gameRepository)
            };

        }

        public void Run()
        {
            while (true)
            {
                for (int i = 0; i < commands.Count; i++)
                {
                    Console.Write($"{i + 1}. {commands[i].ShowInfo()}\n");
                    if (i == commands.Count - 1)
                    {
                        Console.WriteLine($"{i + 2}. Exit");
                    }
                }

                if (int.TryParse(Console.ReadLine(), out int response))
                {
                    if (response > 0 && response <= commands.Count)
                    {
                        commands[response - 1].Action();
                    }
                    else if (response == commands.Count + 1)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}

