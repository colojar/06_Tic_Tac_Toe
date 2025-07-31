using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Tic_Tac_Toe
{
    internal class GameData
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

        // UI Display constants
        public static readonly char EMPTY_DISPLAY = '·';
        public static readonly int AI_DELAY_MS = 1000;
        public static readonly int RESULT_BORDER_LENGTH = 50;

        // Game Introduction Text
        public static List<string> Intro =>
        [
            "06 - Tic Tac Toe",
            "========================================================================",
            "Welcome to Tic Tac Toe!",
            "",
            "The game is played on a 3x3 grid.",
            "Players take turns placing their symbols (X or O) in empty cells.",
            "The first player to get three of their symbols in a row (horizontally, vertically, or diagonally) wins.",
            "If all cells are filled and no player has three in a row, the game ends in a tie.",
            "",
            "Good luck and have fun!",
            "========================================================================",
        ];

        public static List<string> Instructions =>
        [
            "How to play:",
            "",
            "- You are 'X' and the AI is 'O'",
            "- Enter your move as 'row column' (e.g., '0 1' for top-middle)",
            "- Try to get 3 in a row (horizontally, vertically, or diagonally)",
            "",
        ];
    }
}