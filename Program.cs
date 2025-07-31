using _06_Tic_Tac_Toe;

namespace _06_Tic_Tac_Toe
{
    internal class Program
    {
        static void Main()
        {
            bool playAgain = true;
            
            UI.ShowIntro();
            UI.ShowInstructions();

            while (playAgain)
            {
                // Initialize game
                Logic.InitializeBoard();
                char gameState = GameData.CONTINUE_GAME;

                // Game loop
                while (gameState == GameData.CONTINUE_GAME)
                {
                    // Display board
                    UI.DisplayBoardWithPositions();

                    // Player turn
                    var playerMove = UI.GetPlayerMove();
                    Logic.MakeMove(playerMove.row, playerMove.col, Logic.playerSymbol);

                    // Check game state after player move
                    gameState = Logic.GetGameState();
                    if (gameState != GameData.CONTINUE_GAME) break;

                    // AI turn
                    UI.ShowAIMove();
                    Logic.MakeAIMove();

                    // Check game state after AI move
                    gameState = Logic.GetGameState();
                }

                // Show final board and result
                UI.DisplayBoard();
                UI.ShowGameResult(gameState);

                // Ask if player wants to play again
                playAgain = UI.AskPlayAgain();
            }

            UI.ShowExtro();
        }
    }
}
