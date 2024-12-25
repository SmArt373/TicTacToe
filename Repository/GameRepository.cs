using System.Collections.Generic;
using System.Linq;
using TicTacToe.Games;
using TicTacToe.Repository.Interface;

namespace TicTacToe.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly DbContext _dbContext;

        public GameRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Game game)
        {
            _dbContext.Games.Add(game);
        }

        public Game GetById(int id)
        {
            return _dbContext.Games.FirstOrDefault(g => g.Id == id);
        }

        public IEnumerable<Game> GetAll()
        {
            return _dbContext.Games;
        }

        public IEnumerable<Game> GetPlayerGames(int playerId)
        {
            return _dbContext.Games.Where(g => g.Player1.Id == playerId || g.Player2.Id == playerId);
        }
    }
}

