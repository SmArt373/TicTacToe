using TicTacToe.GameAccounts;

namespace TicTacToe.Games
{
    public abstract class Game
    {
        private static int _id = 0;
        public int Id { get; }
        public GameAccount Player1 { get; }
        public GameAccount Player2 { get; }
        public bool IsPlayer1Win { get; set; }
        public int Rating { get; protected set; }
        public abstract string GameType { get; }

        protected Game(GameAccount player1, GameAccount player2, int rating)
        {
            Id = ++_id;
            Player1 = player1;
            Player2 = player2;
            Rating = rating;
        }

        public abstract void Play();
        public abstract int CalculateRating();
    }
}

