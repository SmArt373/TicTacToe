using System.Collections.Generic;
using TicTacToe.Games;

namespace TicTacToe.GameAccounts
{
    public abstract class GameAccount
    {
        private static int _id = 0;
        public int Id { get; }
        public string Username { get; set; }
        public string Password { get; set; }
        protected int _rating;
        public List<GameResult> GameHistory { get; private set; }

        public int CurrentRating
        {
            get { return _rating; }
            set
            {
                if (value > 1)
                {
                    _rating = value;
                }
                else
                {
                    _rating = 1;
                }
            }
        }

        protected GameAccount(string username, string password, int startingRating = 1)
        {
            Id = ++_id;
            Username = username;
            Password = password;
            CurrentRating = startingRating;
            GameHistory = new List<GameResult>();
        }

        protected void AddGameToHistory(string opponentName, bool isWin, int ratingChange, string gameType)
        {
            GameHistory.Add(new GameResult(opponentName, isWin, ratingChange, gameType));
        }

        public abstract void WinGame(Game game);
        public abstract void LoseGame(Game game);
    }
}

