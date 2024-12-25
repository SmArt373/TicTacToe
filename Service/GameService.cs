using TicTacToe.Games;
using TicTacToe.GameAccounts;
using TicTacToe.Service.Interface;

namespace TicTacToe.Service
{
    public class GameService : IGameService
    {
        private Game currentGame;
        private DbContext _dbContext;
        private Factory _factory;
        private char[] board;
        private char currentPlayer;

        public GameService(DbContext dbContext, Factory factory)
        {
            _dbContext = dbContext;
            _factory = factory;
            ResetBoard();
        }

        public void StartNewGame(GameAccount player1, GameAccount player2, string gameType, int rating = 0)
        {
            currentGame = _factory.CreateGame(gameType, player1, player2, rating);
            _dbContext.Games.Add(currentGame);
            ResetBoard();
            currentPlayer = 'X';
        }

        public bool MakeMove(int position)
        {
            if (position < 1 || position > 9 || board[position - 1] != ' ')
                return false;

            board[position - 1] = currentPlayer;
            currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
            return true;
        }

        public bool CheckWin(out char winner)
        {

            for (int i = 0; i < 3; i++)
            {
                if (board[i * 3] != ' ' && board[i * 3] == board[i * 3 + 1] && board[i * 3] == board[i * 3 + 2])
                {
                    winner = board[i * 3];
                    return true;
                }
                if (board[i] != ' ' && board[i] == board[i + 3] && board[i] == board[i + 6])
                {
                    winner = board[i];
                    return true;
                }
            }
            if (board[0] != ' ' && board[0] == board[4] && board[0] == board[8])
            {
                winner = board[0];
                return true;
            }
            if (board[2] != ' ' && board[2] == board[4] && board[2] == board[6])
            {
                winner = board[2];
                return true;
            }

            winner = ' ';
            return false;
        }

        public bool IsBoardFull()
        {
            foreach (char c in board)
            {
                if (c == ' ')
                    return false;
            }
            return true;
        }

        public char[] GetBoard()
        {
            return (char[])board.Clone();
        }

        public char GetCurrentPlayer()
        {
            return currentPlayer;
        }

        public string GetCurrentPlayerName()
        {
            return currentPlayer == 'X' ? currentGame.Player1.Username : currentGame.Player2.Username;
        }

        public void EndGame(bool isPlayer1Win)
        {
            currentGame.IsPlayer1Win = isPlayer1Win;
            currentGame.Play();
        }

        private void ResetBoard()
        {
            board = new char[9];
            for (int i = 0; i < 9; i++)
                board[i] = ' ';
        }
    }
}

