using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Tic_Tac_Toe
{
    internal class Logic
    {
        // Board configuration constants
        public static readonly int BOARD_SIZE = 3;
        public static readonly int WIN_LENGTH = 3;
        
        // Game state constants
        public static readonly char EMPTY_CELL = ' ';
        public static readonly char PLAYER_SYMBOL = 'X';
        public static readonly char AI_SYMBOL = 'O';
        
        // Game result constants
        public static readonly char PLAYER_WINS = 'P';
        public static readonly char AI_WINS = 'A';
        public static readonly char TIE_GAME = 'T';
        public static readonly char CONTINUE_GAME = 'C';

        public static char[,] gameBoard = new char[BOARD_SIZE, BOARD_SIZE];
        public static char playerSymbol = PLAYER_SYMBOL;
        public static char aiSymbol = AI_SYMBOL;
        public static Random random = new Random();

        public static void InitializeBoard()
        {
            for (int row = 0; row < BOARD_SIZE; row++)
            {
                for (int col = 0; col < BOARD_SIZE; col++)
                {
                    gameBoard[row, col] = EMPTY_CELL;
                }
            }
        }

        public static bool IsValidMove(int row, int col)
        {
            // Check if row is within bounds
            bool isRowValid = row >= 0 && row < BOARD_SIZE;

            // Check if column is within bounds
            bool isColValid = col >= 0 && col < BOARD_SIZE;

            // Check if the cell is empty
            bool isCellEmpty = gameBoard[row, col] == EMPTY_CELL;

            // A move is valid only if all three conditions are met:
            // 1. Row is within bounds
            // 2. Column is within bounds  
            // 3. The target cell is currently empty
            return isRowValid && isColValid && isCellEmpty;
        }

        public static void MakeMove(int row, int col, char symbol)
        {
            if (IsValidMove(row, col))
            {
                gameBoard[row, col] = symbol;
            }
        }

        public static bool CheckWin(char symbol)
        {
            // Check rows
            for (int row = 0; row < BOARD_SIZE; row++)
            {
                if (gameBoard[row, 0] == symbol && gameBoard[row, 1] == symbol && gameBoard[row, 2] == symbol)
                    return true;
            }

            // Check columns
            for (int col = 0; col < BOARD_SIZE; col++)
            {
                if (gameBoard[0, col] == symbol && gameBoard[1, col] == symbol && gameBoard[2, col] == symbol)
                    return true;
            }

            // Check diagonals
            if (gameBoard[0, 0] == symbol && gameBoard[1, 1] == symbol && gameBoard[2, 2] == symbol)
                return true;

            if (gameBoard[0, 2] == symbol && gameBoard[1, 1] == symbol && gameBoard[2, 0] == symbol)
                return true;

            return false;
        }

        public static bool IsBoardFull()
        {
            for (int row = 0; row < BOARD_SIZE; row++)
            {
                for (int col = 0; col < BOARD_SIZE; col++)
                {
                    if (gameBoard[row, col] == EMPTY_CELL)
                        return false;
                }
            }
            return true;
        }

        public static void MakeAIMove()
        {
            // Simple AI: Try to win, then block player, then random move
            
            // Try to win
            if (TryToWinOrBlock(aiSymbol))
                return;

            // Try to block player
            if (TryToWinOrBlock(playerSymbol))
                return;

            // Make random move
            MakeRandomMove();
        }

        private static bool TryToWinOrBlock(char symbol)
        {
            // Check all possible moves to see if we can win or block
            for (int row = 0; row < BOARD_SIZE; row++)
            {
                for (int col = 0; col < BOARD_SIZE; col++)
                {
                    if (IsValidMove(row, col))
                    {
                        // Temporarily place the symbol
                        gameBoard[row, col] = symbol;
                        
                        // Check if this creates a win
                        bool wouldWin = CheckWin(symbol);
                        
                        // Remove the temporary symbol
                        gameBoard[row, col] = EMPTY_CELL;
                        
                        // If this move would create a win (or block a win), make it
                        if (wouldWin)
                        {
                            gameBoard[row, col] = aiSymbol;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private static void MakeRandomMove()
        {
            List<(int row, int col)> availableMoves = new List<(int, int)>();
            
            for (int row = 0; row < BOARD_SIZE; row++)
            {
                for (int col = 0; col < BOARD_SIZE; col++)
                {
                    if (IsValidMove(row, col))
                    {
                        availableMoves.Add((row, col));
                    }
                }
            }

            if (availableMoves.Count > 0)
            {
                var move = availableMoves[random.Next(availableMoves.Count)];
                gameBoard[move.row, move.col] = aiSymbol;
            }
        }

        public static char GetGameState()
        {
            if (CheckWin(playerSymbol))
                return PLAYER_WINS;
            
            if (CheckWin(aiSymbol))
                return AI_WINS;
            
            if (IsBoardFull())
                return TIE_GAME;
            
            return CONTINUE_GAME;
        }
    }
}
