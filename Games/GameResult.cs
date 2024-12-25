namespace TicTacToe.Games
{
    public class GameResult
    {
        public string OpponentName { get; set; }
        public bool IsWin { get; set; }
        public int RatingChange { get; set; }
        public string GameType { get; set; }

        public GameResult(string opponentName, bool isWin, int ratingChange, string gameType)
        {
            OpponentName = opponentName;
            IsWin = isWin;
            RatingChange = ratingChange;
            GameType = gameType;
        }
    }
}

