using System.Collections.Generic;
using TicTacToe.Games;

namespace TicTacToe.Repository.Interface
{
    public interface IGameRepository
    {
        void Add(Game game);
        Game GetById(int id);
        IEnumerable<Game> GetAll();
        IEnumerable<Game> GetPlayerGames(int playerId);
    }
}

