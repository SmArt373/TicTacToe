using TicTacToe.GameAccounts;

namespace TicTacToe.Service.Interface
{
    public interface IGameService
    {
        void StartNewGame(GameAccount player1, GameAccount player2, string gameType, int rating = 0);
        bool MakeMove(int position);
        bool CheckWin(out char winner);
        bool IsBoardFull();
        char[] GetBoard();
        char GetCurrentPlayer();
        string GetCurrentPlayerName();
        void EndGame(bool isPlayer1Win);
    }
}

