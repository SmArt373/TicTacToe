using TicTacToe.Games;

namespace TicTacToe.GameAccounts
{
    public class VIPGameAccount : GameAccount
    {
        private int _winStreak = 0;

        public VIPGameAccount(string username, string password, int startingRating = 1)
            : base(username, password, startingRating)
        {
        }

        public override void WinGame(Game game)
        {
            _winStreak++;
            int bonusPoints = _winStreak >= 3 ? 2 : 0;
            CurrentRating += game.CalculateRating() + bonusPoints;
        }

        public override void LoseGame(Game game)
        {
            _winStreak = 0;
            CurrentRating -= game.CalculateRating();
        }
    }
}

