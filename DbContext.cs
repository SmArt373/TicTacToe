using System.Collections.Generic;
using TicTacToe.GameAccounts;
using TicTacToe.Games;

namespace TicTacToe
{
    public class DbContext
    {
        public List<GameAccount> GameAccounts { get; set; }
        public List<Game> Games { get; set; }

        public DbContext()
        {
            GameAccounts = new List<GameAccount>();
            Games = new List<Game>();
        }
    }
}

