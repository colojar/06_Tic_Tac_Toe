using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Tic_Tac_Toe
{
    internal class UI
    {
        public static void ShowIntro()
        {
            foreach (string line in GameData.Intro)
            {
                Console.WriteLine(line);
            }
        }

        public static void ShowInstructions()
        {
            foreach (string line in GameData.Instructions)
            {
                Console.WriteLine(line);
            }
        }

        public static void ShowExtro()
        {
            Console.WriteLine("Thank you for playing Tic Tac Toe!");
            Console.WriteLine("Goodbye!");
        }

        public static void DisplayBoard()
        {
            Console.WriteLine("\nCurrent Board:");
            Console.WriteLine("     0   1   2");
            Console.WriteLine("   +---+---+---+");
            
            for (int row = 0; row < GameData.BOARD_SIZE; row++)
            {
                Console.Write($" {row} ");
                for (int col = 0; col < GameData.BOARD_SIZE; col++)
                {
                    Console.Write($"| {Logic.gameBoard[row, col]} ");
                }
                Console.WriteLine("|");
                Console.WriteLine("   +---+---+---+");
            }
            Console.WriteLine();
        }

        public static void DisplayBoardWithPositions()
        {
            Console.WriteLine("\nBoard positions (row, column):");
            Console.WriteLine("     0   1   2");
            Console.WriteLine("   +---+---+---+");
            
            for (int row = 0; row < GameData.BOARD_SIZE; row++)
            {
                Console.Write($" {row} ");
                for (int col = 0; col < GameData.BOARD_SIZE; col++)
                {
                    char display;
                    if (Logic.gameBoard[row, col] == GameData.EMPTY_CELL)
                    {
                        display = GameData.EMPTY_DISPLAY;
                    }
                    else
                    {
                        display = Logic.gameBoard[row, col];
                    }
                    Console.Write($"| {display} ");
                }
                Console.WriteLine("|");
                Console.WriteLine("   +---+---+---+");
            }
            Console.WriteLine();
        }

        public static (int row, int col) GetPlayerMove()
        {
            while (true)
            {
                Console.WriteLine("Enter your move (row column, e.g., '1 2'):");
                Console.Write("Your move: ");
                
                string? input = Console.ReadLine();
                
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please enter a valid move.");
                    continue;
                }

                string[] parts = input.Split(' ');
                
                if (parts.Length != 2)
                {
                    Console.WriteLine("Please enter row and column separated by a space (e.g., '1 2').");
                    continue;
                }

                if (int.TryParse(parts[0], out int row) && int.TryParse(parts[1], out int col))
                {
                    if (Logic.IsValidMove(row, col))
                    {
                        return (row, col);
                    }
                    else
                    {
                        Console.WriteLine("Invalid move! That position is either taken or out of bounds.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter valid numbers for row and column.");
                }
            }
        }

        public static void ShowGameResult(char gameState)
        {
            Console.WriteLine("\n" + new string('=', GameData.RESULT_BORDER_LENGTH));
            
            switch (gameState)
            {
                case 'P':
                    Console.WriteLine("🎉 Congratulations! You won! 🎉");
                    break;
                case 'A':
                    Console.WriteLine("💻 AI wins! Better luck next time! 💻");
                    break;
                case 'T':
                    Console.WriteLine("🤝 It's a tie! Well played! 🤝");
                    break;
            }
            
            Console.WriteLine(new string('=', GameData.RESULT_BORDER_LENGTH));
        }

        public static void ShowAIMove()
        {
            Console.WriteLine("AI is making its move...");
            System.Threading.Thread.Sleep(GameData.AI_DELAY_MS);
        }

        public static bool AskPlayAgain()
        {
            Console.WriteLine("\nWould you like to play again? (y/n):");
            Console.Write("Your choice: ");
            
            string? input = Console.ReadLine();
            return !string.IsNullOrEmpty(input) && 
                   (input.ToLower().StartsWith('y') || input.ToLower() == "yes");
        }
    }
}
