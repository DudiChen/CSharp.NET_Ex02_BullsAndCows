using System;

using BullsAndCows;
using BullsAndCows.GameBoard;

namespace BullsAndCows
{

    public class Runner
    {
        ////public const uint k_MinimumNumberOfTries = 4;
        ////public const uint k_MaximumNumberOfTries = 10;
        
        public static void PlayGame()
        {
            int guessNumber = 1;
            bool isSuccessfulGuess = false;

            ushort numberOfGuesses = UI.UIManager.GetNumberOfGuesses();
            GameBoardData gameBoard = new GameBoardData(numberOfGuesses);

            while (!isSuccessfulGuess && guessNumber <= numberOfGuesses)
            {
                UI.UIManager.DisplayBoard(gameBoard);
                //// What I want GetUserGuess() to return:
                Pin[] userPinsSequence = UI.UIManager.GetUserGuess();

            }

        }


    }
}

