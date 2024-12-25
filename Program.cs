using TicTacToe.Service;
using TicTacToe.UI;
using TicTacToe.Repository;
using TicTacToe.Repository.Interface;
using TicTacToe.Service.Interface;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new DbContext();

            IGameAccountRepository gameAccountRepository = new GameAccountRepository(dbContext);
            IGameRepository gameRepository = new GameRepository(dbContext);

            var factory = new Factory();

            IGameAccountService gameAccountService = new GameAccountService(dbContext, factory);
            IGameService gameService = new GameService(dbContext, factory);

            var userInterface = new UserInterface(gameAccountService, gameService, gameRepository);

            userInterface.Run();
        }
    }
}
