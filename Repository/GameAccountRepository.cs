using System.Collections.Generic;
using System.Linq;
using TicTacToe.GameAccounts;
using TicTacToe.Repository.Interface;

namespace TicTacToe.Repository
{
    public class GameAccountRepository : IGameAccountRepository
    {
        private readonly DbContext _dbContext;

        public GameAccountRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(GameAccount gameAccount)
        {
            _dbContext.GameAccounts.Add(gameAccount);
        }

        public GameAccount GetByUsername(string username)
        {
            return _dbContext.GameAccounts.FirstOrDefault(a => a.Username == username);
        }

        public IEnumerable<GameAccount> GetAll()
        {
            return _dbContext.GameAccounts;
        }
               
    }
}