using TicTacToe.GameAccounts;

namespace TicTacToe.Games
{
    public class TrainingGame : Game
    {
        public override string GameType => "Тренування";

        public TrainingGame(GameAccount player1, GameAccount player2)
            : base(player1, player2, 0)
        {
        }

        public override void Play()
        {
            if (IsPlayer1Win)
            {
                ((GameAccount)Player1).GameHistory.Add(new GameResult(Player2.Username, true, 0, GameType));
                ((GameAccount)Player2).GameHistory.Add(new GameResult(Player1.Username, false, 0, GameType));
            }
            else
            {
                ((GameAccount)Player2).GameHistory.Add(new GameResult(Player1.Username, true, 0, GameType));
                ((GameAccount)Player1).GameHistory.Add(new GameResult(Player2.Username, false, 0, GameType));
            }
        }

        public override int CalculateRating()
        {
            return 0;
        }
    }
}

