using TicTacToe.GameAccounts;
using TicTacToe.Games;

namespace TicTacToe
{
    public class Factory
    {
        public GameAccount CreateGameAccount(string type, string username, string password, int startingRating = 1)
        {
            switch (type.ToLower())
            {
                case "standard":
                    return new StandardGameAccount(username, password, startingRating);
                case "loseless":
                    return new LoseLessGameAccount(username, password, startingRating);
                case "vip":
                    return new VIPGameAccount(username, password, startingRating);
                default:
                    throw new System.ArgumentException("Invalid game account type", nameof(type));
            }
        }

        public Game CreateGame(string type, GameAccount player1, GameAccount player2, int rating = 0)
        {
            switch (type.ToLower())
            {
                case "standard":
                    return new StandardGame(player1, player2, rating);
                case "training":
                    return new TrainingGame(player1, player2);
                default:
                    throw new System.ArgumentException("Invalid game type", nameof(type));
            }
        }
    }
}

