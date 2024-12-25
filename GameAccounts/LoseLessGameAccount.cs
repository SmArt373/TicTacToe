using TicTacToe.Games;

namespace TicTacToe.GameAccounts
{
    public class LoseLessGameAccount : GameAccount
    {
        public LoseLessGameAccount(string username, string password, int startingRating = 1)
            : base(username, password, startingRating)
        {
        }

        public override void WinGame(Game game)
        {
            CurrentRating += game.CalculateRating();
        }

        public override void LoseGame(Game game)
        {
            CurrentRating -= game.CalculateRating() / 2;
        }
    }
}

