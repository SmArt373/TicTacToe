using System.Collections.Generic;
using TicTacToe.GameAccounts;

namespace TicTacToe.Repository.Interface
{
    public interface IGameAccountRepository
    {
        void Add(GameAccount gameAccount);
        GameAccount GetByUsername(string username);
        IEnumerable<GameAccount> GetAll();

    }
}

