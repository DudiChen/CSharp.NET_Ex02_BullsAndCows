using System;

using BullsAndCows;
using BullsAndCows.GameBoard;

namespace BullsAndCows
{
     
    public class Runner
    {
        
        public static void PlayGame()
        {
            int guessNumber = 1;
            bool isSuccessfulGuess = false;

            ushort numberOfGuesses = UI.UIManager.GetNumberOfGuesses();
            GameBoardData gameBoard = new GameBoardData(numberOfGuesses);

            while (!isSuccessfulGuess && guessNumber <= numberOfGuesses)
            {
                UI.UIManager.DisplayBoard(gameBoard);
                
                Pin[] userPinsSequence = UI.UIManager.GetUserGuess();

                //gameBoard.AddTurn();

            }

        }


    }
}

