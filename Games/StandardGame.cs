using TicTacToe.GameAccounts;

namespace TicTacToe.Games
{
    public class StandardGame : Game
    {
        public override string GameType => "Стандартна";

        public StandardGame(GameAccount player1, GameAccount player2, int rating)
            : base(player1, player2, rating)
        {
        }

        public override void Play()
        {
            int ratingChange = CalculateRating();
            if (IsPlayer1Win)
            {
                Player1.WinGame(this);
                Player2.LoseGame(this);
                ((GameAccount)Player1).GameHistory.Add(new GameResult(Player2.Username, true, ratingChange, GameType));
                ((GameAccount)Player2).GameHistory.Add(new GameResult(Player1.Username, false, -ratingChange, GameType));
            }
            else
            {
                Player2.WinGame(this);
                Player1.LoseGame(this);
                ((GameAccount)Player2).GameHistory.Add(new GameResult(Player1.Username, true, ratingChange, GameType));
                ((GameAccount)Player1).GameHistory.Add(new GameResult(Player2.Username, false, -ratingChange, GameType));
            }
        }

        public override int CalculateRating()
        {
            return Rating;
        }
    }
}

