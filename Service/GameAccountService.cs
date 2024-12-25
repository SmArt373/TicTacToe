using System.Linq;
using TicTacToe.GameAccounts;
using TicTacToe.Games;
using TicTacToe.Service.Interface;

namespace TicTacToe.Service
{
    public class GameAccountService : IGameAccountService
    {
        private DbContext _dbContext;
        private Factory _factory;

        public GameAccountService(DbContext dbContext, Factory factory)
        {
            _dbContext = dbContext;
            _factory = factory;
        }

        public bool CreateAccount(string username, string password, string accountType)
        {
            if (_dbContext.GameAccounts.Any(a => a.Username == username))
                return false;

            var newAccount = _factory.CreateGameAccount(accountType, username, password);
            _dbContext.GameAccounts.Add(newAccount);
            return true;
        }

        public GameAccount Login(string username, string password)
        {
            return _dbContext.GameAccounts.FirstOrDefault(a => a.Username == username && a.Password == password);
        }

        public GameAccount[] GetAllPlayers()
        {
            return _dbContext.GameAccounts.ToArray();
        }

        public GameAccount GetPlayerStats(string username)
        {
            return _dbContext.GameAccounts.FirstOrDefault(a => a.Username == username);
        }

        public void UpdateGameStats(GameAccount player, bool isWin, Game game)
        {
            if (isWin)
                player.WinGame(game);
            else
                player.LoseGame(game);
        }

        public bool AreTwoPlayersRegistered()
        {
            return _dbContext.GameAccounts.Count >= 2;
        }

        public string[] GetPlayersForGame(string currentPlayer)
        {
            var allPlayers = _dbContext.GameAccounts.ToArray();
            if (allPlayers.Length < 2)
            {
                return null;
            }

            var currentPlayerIndex = Array.FindIndex(allPlayers, p => p.Username == currentPlayer);
            if (currentPlayerIndex == -1)
            {
                return new string[] { allPlayers[0].Username, allPlayers[1].Username };
            }

            var nextPlayerIndex = (currentPlayerIndex + 1) % allPlayers.Length;
            return new string[] { allPlayers[currentPlayerIndex].Username, allPlayers[nextPlayerIndex].Username };
        }
    }
}

