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
        "Good luck and have fun!",
        "========================================================================",
    ];
    }
}
