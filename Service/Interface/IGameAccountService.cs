using TicTacToe.GameAccounts;
using TicTacToe.Games;

namespace TicTacToe.Service.Interface
{
    public interface IGameAccountService
    {
        bool CreateAccount(string username, string password, string accountType);
        GameAccount Login(string username, string password);
        GameAccount[] GetAllPlayers();
        GameAccount GetPlayerStats(string username);
        void UpdateGameStats(GameAccount player, bool isWin, Game game);
        bool AreTwoPlayersRegistered();
        string[] GetPlayersForGame(string currentPlayer);
    }
}

